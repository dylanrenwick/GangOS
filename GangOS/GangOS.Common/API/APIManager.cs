using System;
using System.Net;
using System.Threading;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GangOS.Common.API
{
    public class APIManager
    {
        private class JsonAsyncResult : IAsyncResult
        {
            public JsonAsyncResult(JObject json, string auth)
            {
                AsyncState = new object[] {json, auth};
            }

            public bool IsCompleted { get; private set; }
            public object AsyncState { get; private set; }
            public WaitHandle AsyncWaitHandle { get; private set; }
            public bool CompletedSynchronously { get; private set; }
        }

        public bool APIIsOnline { get; private set; }

        private string p_apiURL;
        private string p_gangs;
        private string p_universe;
        private string p_ladder;
        private string p_player;

        public APIManager()
        {
            p_apiURL = "https://api.gangsofspace.com";
            p_gangs = "/gangs";
            p_universe = "/universe";
            p_ladder = "/ladder";
            p_player = "/me";

            APIIsOnline = IsOnline();
        }

        public void GetPlayerData(string auth, AsyncCallback callback)
        {
            new Thread(new ThreadStart(() =>
                {
                    string url = string.Format("{0}{1}?token={2}", p_apiURL, p_player, auth);
                    GangOSClient.Trace(string.Format("Downloading JSON Data from {0}", url));
                    callback.Invoke(new JsonAsyncResult(JsonApiHelper.GetJson(url), auth));
                })).Start();
        }

        private bool IsOnline()
        {
            return true;

            try
            {
                using (var wc = new WebClient())
                {
                    var tempString = wc.DownloadString(p_apiURL);

                    GangOSClient.Trace(string.Format("{0} [{1}]", tempString.Substring(0, 15), tempString.Length));

                    bool live = !String.IsNullOrWhiteSpace(tempString);

                    if (live)
                    {
                        live = !tempString.StartsWith("<!DOCTYPE");
                    }

                    return live;
                }
            }
            catch (Exception e)
            {
                GangOSClient.Trace(e.Message);
                return false;
            }
        }
    }
}
