using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace LuisBot.Utilities
{
    public static class LuisProcessor
    {
        private static string uri =
            ConfigurationManager.AppSettings["LuisAPIHostName"] +
            ConfigurationManager.AppSettings["LuisAppId"] + "?";
        public static string GetLuisIntent(string userStringQuery)
        {
            System.Collections.Specialized.NameValueCollection queryString = GetLuisQueryString(userStringQuery);
            string jsonResponse = GetHttpResponse.GetJsonResponse(uri, queryString);
            if(jsonResponse == "")
            {
                //jsonResponse = File.ReadAllText("~\\OfflineData\\dummyLuis.json");
            }
            return jsonResponse;
        }

        private static System.Collections.Specialized.NameValueCollection GetLuisQueryString(string userStringQuery)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["q"] = HttpUtility.UrlEncode(userStringQuery);
            queryString["subscription-key"] = ConfigurationManager.AppSettings["LuisSubscriptionKey"];
            queryString["timezoneOffset"] = "0";
            queryString["verbose"] = "false";
            queryString["spellCheck"] = "false";
            queryString["staging"] = "false";
            return queryString;
        }

    }
}