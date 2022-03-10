using System;
using FinalExam.Configuration;
using FinalExam.Constants;
using FinalExam.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FinalExam.RestAPI
{
    public class BaseApi
    {
        private readonly RestClient _restClient;
        private RestResponse? _response;

        public BaseApi()
        {
            _restClient = new RestClient(ConfigurationProvider.GetConfigurationValue[AppConstants.RestBaseUrl]
                                         ?? throw new InvalidOperationException());
        }

        public int ResponseStatusCode => ((int) _response!.StatusCode);
        public string ResponseMessage => _response!.StatusDescription!;

        public void GetRequest(string endpoint)
        {
            ExecuteRequest(new RestRequest(endpoint));
        }

        public T GetResponseData<T>()
        {
            var content = _response!.Content;
            return content != null
                ? JsonConvert.DeserializeObject<T>(content)
                : JsonConvert.DeserializeObject<T>("null");
        }

        public void PostRequest(string endpoint, User user)
        {
            var userForCreation = new User()
            {
                Name = user.Name,
                Gender = user.Gender,
                Email = user.Email,
                Status = user.Status
            };
            ExecuteRequest(new RestRequest(endpoint, Method.Post).AddJsonBody(userForCreation));
        }

        public void PatchRequest(string endpoint, User user)
        {
            var userForEdit = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Status = user.Status,
                Gender = user.Gender
            };
            ExecuteRequest(new RestRequest(endpoint, Method.Patch).AddJsonBody(userForEdit));
        }

        public void DeleteRequest(string endpoint)
        {
            ExecuteRequest(new RestRequest(endpoint, Method.Delete));
        }

        private void ExecuteRequest(RestRequest request)
        {
            var attempt = 1;
            while (attempt <= 5)
            {
                _response = _restClient.ExecuteAsync(request
                        .AddHeader("Authorization", AppConstants.BearerToken))
                    .GetAwaiter()
                    .GetResult();
                if (_response.IsSuccessful)
                {
                    break;
                }

                attempt++;
            }
        }
    }
}