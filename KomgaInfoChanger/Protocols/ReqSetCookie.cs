using RestSharp;
using Newtonsoft.Json.Linq;
using System.Windows.Media;

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
            {
                env.logger.AddLog("로그인 성공");
                env.mainWindow.SetColorLoginStatusLamp(Colors.SpringGreen);
                return true;
            }
            else
            {
                JObject obj = JObject.Parse(ret);
                env.mainWindow.SetColorLoginStatusLamp(Colors.OrangeRed);

                // 에러 났을 경우 그냥 로그에 기록.
                env.logger.AddLog(obj.ToString());
                return false;
            }
        }
    }
}
