using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KomgaInfoChanger.Protocols;

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

            var response = restClient.Execute(request);
            if (response.IsSuccessful == false && response.Content == "")
            {
                JObject json = new JObject();
                json.Add("status", "404");
                json.Add("error", Protocol.SERVER_ADDR_ERROR.ToString());
                json.Add("message", response.ErrorMessage);

                response.Content = json.ToString();
            }

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
    }
}
