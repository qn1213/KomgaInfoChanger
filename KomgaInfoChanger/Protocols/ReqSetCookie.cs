using RestSharp;
using Newtonsoft.Json.Linq;

namespace KomgaInfoChanger.Protocols
{
    internal class ReqSetCookie
    {
        private const string api = "/api/v1/login/set-cookie";

        public ReqSetCookie()
        {
            env.basicAuthInfo = Helper.GetBasicAuthBase64(env.info.serverID, env.info.serverPW);
        }

        public bool Request()
        {
            string ret = RestAPI.ApiSender.Request(Method.GET, env.info.serverAddr, api, env.GetHeader());

            if (string.IsNullOrEmpty(ret))
                return true;
            else
            {
                JObject obj = JObject.Parse(ret);

                // 에러 났을 경우 그냥 로그에 기록.
                env.logger.AddLog(obj.ToString());
                return false;
            }
        }
    }
}
