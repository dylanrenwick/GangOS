using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using Newtonsoft.Json.Linq;

namespace GangOS.Common.API.Twitch
{
    public class Livestream
    {
        private readonly string DefaultImg = @"TwitchAvatars\Twitch_Logo_Default.png";

        public string Username { get; private set; }
        public string URL
        {
            get
            {
                return string.Format("http://www.twitch.tv/{0}", Username.ToLower());
            }
        }
        public int Viewers { get; private set; }
        public int Followers { get; private set; }
        public Image Avatar { get; private set; }

        public Livestream(JToken json)
        {
            Username = json["channel"]["name"].ToString();
            Viewers = int.Parse(json["viewers"].ToString());
            try
            {
                Followers = int.Parse(json["channel"]["followers"].ToString());
            }
            catch
            {
                Followers = 0;
            }

            string imgUrl = json["channel"]["logo"].ToString();

            Avatar = GangOSClient.GetImageFromURL(imgUrl, Username, string.Format("{0}\\Twitch_{1}_Logo.png", "TwitchAvatars", Username), new Size(86, 86));

        }
    }
}
