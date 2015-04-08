using System.Net;
using System.IO;
using System;
using System.Threading;

using Newtonsoft.Json.Linq;

namespace GangOS.Common.API
{
    public static class JsonApiHelper
    {
        private class JsonAsyncResult : IAsyncResult
        {
            public JsonAsyncResult(JObject jo)
            {
                AsyncState = jo;
            }

            public bool IsCompleted { get; private set; }
            public object AsyncState { get; private set; }
            public WaitHandle AsyncWaitHandle { get; private set; }
            public bool CompletedSynchronously { get; private set; }
        }

        public static JObject GetJson(string url)
        {
            try
            {
                var json_data = DownloadText(url);

                return JObject.Parse(json_data);
            }
            catch
            {
                return null;
            }
        }
        public static void GetJson(string url, AsyncCallback callback)
        {
            new Thread(new ThreadStart(() =>
                {
                    callback.Invoke(new JsonAsyncResult(GetJson(url)));
                })).Start();
        }
        private static string DownloadText(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        private static void EndDownload(IAsyncResult ar)
        {

        }
    }
}