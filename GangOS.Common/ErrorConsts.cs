using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangOS.Common
{
    public static class ErrorConsts
    {
        public static readonly string APIConnectionError = "ERROR: Could not connect to API! The server may be down or there may be a problem with your internet connection.";
        public static readonly string JSONDownloadError = "ERROR: Could not download JSON data from URL! The server may be down or there may be a problem with your internet connection.";
        public static readonly string AuthInvalidError = "ERROR: Authorization failed! Please ensure you enterred the correct API Auth Code!";
    }
}
