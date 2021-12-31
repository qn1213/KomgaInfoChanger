using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace KomgaInfoChanger.Protocols
{
    internal class ReqPatchBooksMeta
    {
        private const string api = "/api/v1/books/metadata";
        private Dictionary<string, string> body;

        public ReqPatchBooksMeta()
        {
            body = new Dictionary<string, string>();            
        }

        public void Request(string _body)
        {            
            body.Add("application / json", _body);

            string ret = RestAPI.ApiSender.Request(Method.PATCH, env.info.serverAddr, api, env.GetHeader(), null, body);

            // TODO
            // 에러 처리
        }
    }
}