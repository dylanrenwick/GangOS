using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace GangOS.Common
{
    public class Gang
    {
        public string ID { get; private set; }
        public string Name { get; private set; }
        public List<string> Members { get; private set; }
        public List<string> Admins { get; private set; }
        public Image Flag { get; private set; }
        public string Empire { get; private set; }
        public DateTime Birth { get; private set; }
        public TimeSpan Age
        {
            get
            {
                return DateTime.UtcNow.Subtract(Birth);
            }
        }

        public Gang(JToken json)
        {
            ID = json["id"].ToString();

            Name = json["name"].ToString();

            Birth = GangOSClient.ParseTime(json["createdAt"].ToString());

            Flag = GangOSClient.GetImageFromURL(json["flagUrl"].ToString(), Name, string.Format("{0}\\Gang_{1}_Flag.png", "GangFlags", Name), new Size(20, 14));

            GetMembers(json);

            switch(json["empire"].ToString())
            {
                case "Empire Alpha":
                    Empire = "Alpha";
                    break;
                case "Empire Beta":
                    Empire = "Beta";
                    break;
                default:
                    Empire = String.Empty;
                    break;
            }
        }

        private void GetMembers(JToken json)
        {
            Members = new List<string>();

            foreach (var m in json["members"])
            {
                Members.Add(m["nickname"].ToString());
                try
                {
                    if (m["admin"].ToString() == "true")
                    { Admins.Add(m["nickname"].ToString()); }
                }
                catch { }
            }
        }
    }
}
