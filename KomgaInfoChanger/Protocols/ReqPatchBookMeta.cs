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

        // 호출 시 Try/Catch로 감쌀 것
        public ReqPatchBookMeta(string _bookID)
        {
            if (string.IsNullOrEmpty(_bookID))
                throw new System.Exception("Book ID is Empty");

            api += _bookID + "/metadata";

            body = new Dictionary<string, string>();
        }

        public bool Request(string _body)
        {
            body.Add("application / json", _body);
            
            string ret = RestAPI.ApiSender.Request(Method.PATCH, env.info.serverAddr, api, env.GetHeader(), null, body);

            // 어떤 값 넘어오는지 확인하기
            if (ret != null)
                return false;

            return true;
        }
    }
}
