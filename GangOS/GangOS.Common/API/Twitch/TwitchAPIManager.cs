using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Newtonsoft.Json.Linq;

using GangOS.Common.API;

namespace GangOS.Common.API.Twitch
{
    public class TwitchAPIManager
    {
        private class ListAsyncResult : IAsyncResult
        {
            public ListAsyncResult(List<Livestream> list)
            {
                AsyncState = list;
            }

            public bool IsCompleted { get; private set; }
            public object AsyncState { get; private set; }
            public WaitHandle AsyncWaitHandle { get; private set; }
            public bool CompletedSynchronously { get; private set; }
        }

        private string p_APIUrl;

        public TwitchAPIManager()
        {
            p_APIUrl = "https://api.twitch.tv/kraken/";
        }

        public void GetLivestreams(int page, AsyncCallback callback)
        {
            new Thread(new ThreadStart(() =>
                {
                    var List = new List<Livestream>();

                    GangOSClient.Trace("Getting official stream if live...");

                    //Get official Stream
                    JObject query = JsonApiHelper.GetJson(string.Format("{0}streams/gangsofspace", p_APIUrl));

                    if (query == null)
                    {
                        GangOSClient.Trace(ErrorConsts.JSONDownloadError);
                        callback.Invoke(new ListAsyncResult(List));
                    }

                    if (query["stream"].HasValues)
                    {
                        List.Add(new Livestream(query["stream"]));
                        GangOSClient.Trace("Official stream is live.");
                    }
                    else
                        GangOSClient.Trace("Official stream is offline.");

                    GangOSClient.Trace(string.Format("Getting {0} livestreams from page {1}", 10 - List.Count, page));

                    //Get streams playing Gangs of Space live
                    query = JsonApiHelper.GetJson(string.Format("{0}streams?game={1}&limit={2}&offset={3}", p_APIUrl, "Gangs%20of%20Space", 10 - List.Count, page));

                    if (query == null)
                    {
                        GangOSClient.Trace(ErrorConsts.JSONDownloadError);
                        callback.Invoke(new ListAsyncResult(List));
                    }

                    GangOSClient.Trace("JSON Downloaded, parsing...");

                    var results = query["streams"];

                    foreach (var k in results)
                    {
                        List.Add(new Livestream(k));
                        GangOSClient.Trace(string.Format("Added livestream {0} with {1} viewers", List.Last().Username, List.Last().Viewers));
                    }

                    GangOSClient.Trace(string.Format("Livestream fetch complete, {0} streams returned.", List.Count));

                    callback.Invoke(new ListAsyncResult(List));
                })).Start();
        }
    }
}
