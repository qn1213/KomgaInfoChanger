using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace KomgaInfoChanger.Protocols
{
    internal class ReqSetCookie
    {
        private const string api = "/api/v1/login/set-cookie";

        public ResSetCookie_test res;
        private Dictionary<string, string> header;

        public ReqSetCookie()
        {
            env.basicAuthInfo = Helper.GetBasicAuthBase64(env.info.serverID, env.info.serverPW);

            header = new Dictionary<string, string>();
            header.Add(env.AUTH_PREFIX_, env.basicAuthInfo);

            res = new ResSetCookie_test();
        }

        public bool Request()
        {
            string ret = RestAPI.ApiSender.Request(Method.GET, env.info.serverAddr, api, header);

            if (string.IsNullOrEmpty(ret))
                return true;
            else
            {
                JObject obj = JObject.Parse(ret);
                res.status = Helper.GetInt(obj.GetValue("status").ToString());
                res.error = obj.GetValue("error").ToString();
                res.message = obj.GetValue("message").ToString();
                return false;
            }
        }
    }

    internal class ResSetCookie_test
    {
        public int status;
        public string error;
        public string message;
    }
}
