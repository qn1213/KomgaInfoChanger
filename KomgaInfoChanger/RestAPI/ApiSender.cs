using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KomgaInfoChanger.RestAPI
{
    internal static class ApiSender
    {
        public static void Send()
        {
            var client = new RestClient("주소!");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            //request.AddHeader("Authorization", "Basic 토큰!");
            //request.AddHeader("Cookie", "토큰!");
            IRestResponse response = client.Execute(request);

            JObject jObject = null;
            if (response.Content != null)
                jObject = JObject.Parse(response.Content);
            else
                return; // 성공 했을 때

            string status = jObject.GetValue("status").ToString();
            string error = jObject.GetValue("error").ToString();
            string message = jObject.GetValue("message").ToString();

            Console.WriteLine(status + ", " + error + ", " + message);
        }


        // 제네릭을 이용하여 Response 객체를 넘기면 자동으로 해당 객체로 변환하여 Return해줌
        public static T Request<T>(Method method, string baseUrl, string subUrl, Dictionary<string, string> header = null, Dictionary<string, string> queryParameter = null, Dictionary<string, string> bodyParameter = null)
        {
            var restClient = new RestClient(baseUrl);
            var request = new RestRequest(subUrl, method);

            // Timeout을 -1로 설정하면 무제한으로 설정한다는 뜻입니다.
            restClient.Timeout = -1;

            if (header != null)
            {
                request.AddHeaders(header);
            }

            if (queryParameter != null)
            {
                foreach (var pair in queryParameter)
                {
                    request.AddQueryParameter(pair.Key, pair.Value);
                }
            }

            if (method != Method.GET && bodyParameter != null)
            {
                foreach (var pair in bodyParameter)
                {
                    request.AddParameter(pair.Key, pair.Value);
                }
            }

            // Response를 자동으로 T Type으로 변환해줍니다.
            var response = restClient.Execute<T>(request);

            return response.Data;
        }

        /*
        public static T Request<T>(Method method, string baseUrl, string subUrl, Dictionary<string, string> header = null, Dictionary<string, string> queryParameter = null, Dictionary<string, string> bodyParameter = null)
        {
            var restClient = new RestClient(baseUrl);
            var request = new RestRequest(subUrl, method);

            // Timeout을 -1로 설정하면 무제한으로 설정한다는 뜻입니다.
            restClient.Timeout = -1;

            if (header != null)
            {
                request.AddHeaders(header);
            }

            if (queryParameter != null)
            {
                foreach (var pair in queryParameter)
                {
                    request.AddQueryParameter(pair.Key, pair.Value);
                }
            }

            if (method != Method.GET && bodyParameter != null)
            {
                foreach (var pair in bodyParameter)
                {
                    request.AddParameter(pair.Key, pair.Value);
                }
            }

            // Response를 자동으로 T Type으로 변환해줍니다.
            var response = restClient.Execute<T>(request);

            return response.Data;
        }
         */
    }
}
