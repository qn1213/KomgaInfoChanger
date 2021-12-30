using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace KomgaInfoChanger.Protocols
{
    internal class ReqSetCookie
    {
        private const string api = "/api/v1/login/set-cookie";

        public Result_ReqSetCookie response;
        private Dictionary<string, string> header;

        public ReqSetCookie()
        {
            env.basicAuthInfo = Helper.GetBasicAuthBase64(env.info.serverID, env.info.serverPW);

            header = new Dictionary<string, string>();
            header.Add(env.AUTH_PREFIX_, env.basicAuthInfo);

            response = new Result_ReqSetCookie();
        }

        public bool Request()
        {
            Logger log = Logger.GetInstance;
            string ret = RestAPI.ApiSender.Request(Method.GET, env.info.serverAddr, api, header);

            if (string.IsNullOrEmpty(ret))
            {
                log.AddLog("로그인 성공");
                return true;
            }
            else
            {
                JObject obj = JObject.Parse(ret);
                response.status = Helper.GetInt(obj.GetValue("status").ToString());
                response.error = obj.GetValue("error").ToString();
                response.message = obj.GetValue("message").ToString();

                log.AddLog(response.status + " : " + response.error + " :" + response.message);
#if DEBUG
                System.Console.WriteLine(response.status+"\n"+response.error+"\n"+response.message);
#endif
                return false;
            }
        }
    }

    internal class Result_ReqSetCookie
    {
        public int status;
        public string error;
        public string message;
    }
}
