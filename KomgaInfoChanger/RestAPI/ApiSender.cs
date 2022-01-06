using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using KomgaInfoChanger.Protocols;
using System;

namespace KomgaInfoChanger.RestAPI
{
    internal static class ApiSender
    {
        public static string Request(Method method, string baseUrl, string subUrl, Dictionary<string, string> header = null, Dictionary<string, string> queryParameter = null, Dictionary<string, string> bodyParameter = null)
        {
            var restClient = new RestClient(baseUrl);
            var request = new RestRequest(subUrl, method);

            restClient.Timeout = -1;

            if (header != null)
                request.AddHeaders(header);

            // link.test/user?[player=1234] player, 1234 => 여기에 들어갈 변수
            if (queryParameter != null)
            {
                foreach (var pair in queryParameter)
                    request.AddQueryParameter(pair.Key, pair.Value);
            }

            // 서버에 데이터를 보낼 때 xml, json데이터를 넣어서 보냄.
            // key = 데이터 타입, value = 값
            if (method != Method.GET && bodyParameter != null)
            {
                foreach (var pair in bodyParameter)
                    request.AddParameter(pair.Key, pair.Value, ParameterType.RequestBody);
            }

            IRestResponse response = restClient.Execute(request);

            if (response.ContentType != "" && response.ContentType != "application/json")
            {
                JObject json = new JObject();
                json.Add("status", "1000");
                json.Add("error", Protocol.NOT_JSON_TYPE.ToString());
                json.Add("message", response.ErrorMessage);

                response.Content = json.ToString();
            }
            else if (response.IsSuccessful == false && response.Content == "")
            {
                JObject json = new JObject();
                json.Add("status", "404");
                json.Add("error", Protocol.SERVER_ADDR_ERROR.ToString());
                json.Add("message", response.ErrorMessage);

                response.Content = json.ToString();
            }

            Console.WriteLine(response.ResponseStatus + " - " + response.StatusCode);

            return response.Content;

        }

        public static T Request<T>(Method method, string baseUrl, string subUrl, Dictionary<string, string> header = null, Dictionary<string, string> queryParameter = null, Dictionary<string, string> bodyParameter = null)
        {
            var restClient = new RestClient(baseUrl);
            var request = new RestRequest(subUrl, method);

            restClient.Timeout = -1;

            if (header != null)
                request.AddHeaders(header);

            if (queryParameter != null)
            {
                foreach (var pair in queryParameter)
                    request.AddQueryParameter(pair.Key, pair.Value);
            }

            if (method != Method.GET && bodyParameter != null)
            {
                foreach (var pair in bodyParameter)
                    request.AddParameter(pair.Key, pair.Value);
            }

            var response = restClient.Execute<T>(request);

            return response.Data;
        }

        // 쿠키까지 응답값의 상세 값이 필요하다면 이걸로
        //public static IRestResponse Request(Method method, string baseUrl, string subUrl, Dictionary<string, string> header = null, Dictionary<string, string> queryParameter = null, Dictionary<string, string> bodyParameter = null)
        //{
        //    var restClient = new RestClient(baseUrl);
        //    var request = new RestRequest(subUrl, method);

        //    restClient.Timeout = -1;

        //    if (header != null)
        //        request.AddHeaders(header);

        //    if (queryParameter != null)
        //    {
        //        foreach (var pair in queryParameter)
        //            request.AddQueryParameter(pair.Key, pair.Value);
        //    }

        //    if (method != Method.GET && bodyParameter != null)
        //    {
        //        foreach (var pair in bodyParameter)
        //            request.AddParameter(pair.Key, pair.Value);
        //    }

        //    var response = restClient.Execute(request);
        //    if (response.ContentType != "application/json")
        //    {
        //        JObject json = new JObject();
        //        json.Add("status", "1000");
        //        json.Add("error", Protocol.NOT_JSON_TYPE.ToString());
        //        json.Add("message", response.ErrorMessage);

        //        response.Content = json.ToString();
        //    }
        //    else if (response.IsSuccessful == false && response.Content == "")
        //    {
        //        JObject json = new JObject();
        //        json.Add("status", "404");
        //        json.Add("error", Protocol.SERVER_ADDR_ERROR.ToString());
        //        json.Add("message", response.ErrorMessage);

        //        response.Content = json.ToString();
        //    }

        //    return response;
        //}
    }
}
