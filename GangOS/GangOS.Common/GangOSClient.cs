using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using GangOS.Common.API;
using GangOS.Common.API.Twitch;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;

namespace GangOS.Common
{
    public static class GangOSClient
    {
        public static event EventHandler PlayersUpdated;
        public static event EventHandler LivestreamsUpdated;

        public static bool IsDebug;
        public static List<Player> PlayerList;
        public static List<Gang> GangList;

        public static List<Livestream> Livestreams
        {
            get
            {
                return livestreams != null ? livestreams : new List<Livestream>();
            }
        }
        public static List<Livestream> livestreams;
        public static int LivestreamPage;

        private static APIManager API;
        private static TwitchAPIManager TwitchAPI;

        public const int DefaultDpi = 96;

        public static void Initialize()
        {
            Trace("GangOSClient.Initialize - Begin");
            API = new APIManager();
            TwitchAPI = new TwitchAPIManager();
            PlayerList = new List<Player>();
            GangList = new List<Gang>();

            Trace("GangOSClient.Initialize - Check API is Live");
            if (!API.APIIsOnline)
                Trace(ErrorConsts.APIConnectionError);
            else
                Trace("GOS API is online!");

            if (!Directory.Exists("TwitchAvatars"))
                Directory.CreateDirectory("TwitchAvatars");
            if (!Directory.Exists("temp"))
                Directory.CreateDirectory("temp");
            if (!Directory.Exists("GangFlags"))
                Directory.CreateDirectory("GangFlags");

            Trace("Getting Livestreams...");
            LivestreamPage = 0;
            UpdateLivestreams();

            Trace("GangOSClient.Initialize - End");
        }

        public static void AddPlayer(string auth)
        {
            Trace("Downloading player JSON");
            API.GetPlayerData(auth, new AsyncCallback(AddPlayerCallback));
        }
        private static void AddPlayerCallback(IAsyncResult ar)
        {
            var PlayerJson = (JObject)((object[])ar.AsyncState)[0];
            string auth = (string)((object[])ar.AsyncState)[1];

            if (PlayerJson == null)
            {
                Trace(ErrorConsts.JSONDownloadError);
                return;
            }
            Trace("JSON Downloaded");

            if (PlayerJson["meta"]["auth"].ToString() == "false")
            {
                Trace(ErrorConsts.AuthInvalidError);
                return;
            }

            Trace("Adding Player");
            Player newPlayer = new Player(PlayerJson, auth);

            string gangName;

            try
            { 
                gangName = PlayerJson["gang"]["name"].ToString();
                Trace(string.Format("Adding Player's Gang: {0}", gangName));
                Gang playerGang = GetGangByName(gangName);
                if (playerGang != null)
                {
                    Trace(string.Format("{0} is already recorded", gangName));
                    newPlayer.gang = playerGang;
                }
                else
                {
                    playerGang = new Gang(PlayerJson["gang"]);
                    newPlayer.gang = playerGang;
                    GangList.Add(playerGang);
                    Trace(string.Format("Gang {0} added", gangName));
                }
            }
            catch(Exception e)
            { 
                Trace("Player has no gang");
                Trace(e.Message);
                throw e;
            }
            finally 
            {
                PlayerList.Add(newPlayer);
                if (PlayersUpdated != null)
                    PlayersUpdated(null, new EventArgs());
                Trace("Player Added");
            }
        }

        public static void UpdateLivestreams()
        {
            TwitchAPI.GetLivestreams(LivestreamPage, new AsyncCallback(UpdateLivestreamsCallback));
        }
        private static void UpdateLivestreamsCallback(IAsyncResult ar)
        {
            livestreams = (List<Livestream>)ar.AsyncState;

            if (LivestreamsUpdated != null)
                LivestreamsUpdated(null, new EventArgs());
        }

        public static Gang GetGangByName(string name)
        {
            List<Gang> temp = new List<Gang>(GangList);
            foreach (var gang in temp)
            {
                if (gang.Name == name)
                    return gang;
            }

            return null;
        }

        public static DateTime ParseTime(string time)
        {
            var dt = new DateTime();

            var Date = time.Split(' ')[0].Split('/');
            var Time = time.Split(' ')[1].Substring(0, 8).Split(':');

            return DateTime.Parse(time);

            dt.AddYears(int.Parse(Date[0]));
            dt.AddMonths(int.Parse(Date[1]));
            dt.AddDays(int.Parse(Date[2]));

            dt.AddHours(int.Parse(Time[0]));
            dt.AddMinutes(int.Parse(Time[1]));
            dt.AddSeconds(int.Parse(Time[2]));

            return dt;
        }

        public static Image GetImageFromURL(string url, string name, string path, Size size)
        {
            string FilePath;
            Image img;

            using (var w = new WebClient())
            {
                try
                {
                    w.DownloadFile(new Uri(url), string.Format(path, name));
                    FilePath = string.Format(path, name);

                    img = ResizeImage(Image.FromFile(FilePath), size.Width, size.Height, false);
                    img.Save(FilePath);
                }
                catch
                {
                    try
                    { File.Delete(string.Format(path, name)); }
                    catch { }

                    return null;
                }
            }

            return img;
        }
        public static Image GetImageFromURL(string url, string name, string path)
        {
            string FilePath;
            Image img;

            using (var w = new WebClient())
            {
                try
                {
                    w.DownloadFile(new Uri(url), string.Format(path, name));
                    FilePath = string.Format(path, name);

                    img = Image.FromFile(FilePath);
                }
                catch
                {
                    try
                    { File.Delete(string.Format(path, name)); }
                    catch { }

                    return null;
                }
            }

            return img;

        }

        public static Bitmap ResizeImage(Image image, int width, int height, bool pixelPerfect)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                if (!pixelPerfect)
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                }
                else
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.Default;
                    graphics.SmoothingMode = SmoothingMode.None;
                    graphics.PixelOffsetMode = PixelOffsetMode.None;
                }

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static void Trace(string text)
        {
            string msg = string.Format("[{0}] > {1}", DateTime.UtcNow.ToString("hh:mm:ss"), text);

            Console.WriteLine(msg);
            System.Diagnostics.Trace.WriteLine(msg);
        }

        [Conditional("DEBUG")]
        public static void CheckDebug()
        { IsDebug = true; }
    }
}
