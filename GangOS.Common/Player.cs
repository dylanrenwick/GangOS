using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GangOS.Common
{
    public class Player
    {
        public string Auth;
        public string ID;
        public string Username;

        public int DNA;
        public int Medals;

        public DateTime Birth;
        public DateTime LastLogin;
        public TimeSpan Age
        {
            get
            {
                return DateTime.UtcNow.Subtract(Birth);
            }
        }

        public Gang gang;

        public Player(JToken json, string auth)
        {
            Auth = auth;

            JToken JSON = json["account"];

            ID = JSON["id"].ToString();
            Username = JSON["nickname"].ToString();

            DNA = int.Parse(JSON["dna"].ToString());
            Medals = int.Parse(JSON["medal"].ToString());

            Birth = GangOSClient.ParseTime(JSON["createdAt"].ToString());
            LastLogin = GangOSClient.ParseTime(JSON["updatedAt"].ToString());
        }
    }
}
