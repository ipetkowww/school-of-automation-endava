using AutomationForHomeworkTasks.Config;
using AutomationForHomeworkTasks.Constants;
using AutomationForHomeworkTasks.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AutomationForHomeworkTasks.RestAPI
{
    public class BaseApi
    {
        private readonly RestClient _restClient;
        private RestResponse _response;

        public BaseApi()
        {
            _restClient = new RestClient(ConfigProvider.GetConfigValue[StringConstants.RestBaseUrl]);
        }

        public int ResponseStatusCode => ((int)_response.StatusCode);
        public string ResponseMessage => _response.StatusDescription;

        public void GetRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            _response = _restClient.ExecuteAsync(request).GetAwaiter().GetResult();
        }

        public T GetResponseData<T>()
        {
            return JsonConvert.DeserializeObject<T>(_response.Content);
        }
    }
}
