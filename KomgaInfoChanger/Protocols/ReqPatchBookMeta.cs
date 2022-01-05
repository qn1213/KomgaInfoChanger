using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace KomgaInfoChanger.Protocols
{
    internal class ReqPatchBookMeta
    {
        private string api = "/api/v1/books/";
        private Dictionary<string, string> body;

        public ReqPatchBookMeta()
        {
            body = new Dictionary<string, string>();
        }

        public bool Request(string bookID ,string _body)
        {
            body.Clear();

            api = "/api/v1/books/" + bookID + "/metadata";

            body.Add("application/json", _body);
            
            string ret = RestAPI.ApiSender.Request(Method.PATCH, env.info.serverAddr, api, env.GetHeader(), null, body);
 
            if (!string.IsNullOrEmpty(ret))
            {
                env.logger.AddLog(ret);
                return false;
            }

            return true;
        }
    }
}
