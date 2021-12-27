using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //bodyParameter = new Dictionary<string, string>();
            //bodyParameter.Add("application/json", _body);
            //RestAPI.ApiSender.Request(Method.PATCH, env.info.serverAddr, api, env.GetHeader(),null,bodyParameter);

            body.Add("application / json", _body);

            string ret = RestAPI.ApiSender.Request(Method.PATCH, env.info.serverAddr, api, env.GetHeader(), null, body);


            //RestClient client = new RestClient(env.info.serverAddr + api);
            //client.Timeout = -1;
            //RestRequest request = new RestRequest(Method.PATCH);
            //request.AddHeader(env.AUTH_PREFIX_, env.basicAuthInfo);
            ////request.AddHeader("Content-Type", "application/json");

            //request.AddParameter("application/json", _body, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            //Console.WriteLine(response.ResponseStatus + " - " + response.StatusCode);
        }
    }
}