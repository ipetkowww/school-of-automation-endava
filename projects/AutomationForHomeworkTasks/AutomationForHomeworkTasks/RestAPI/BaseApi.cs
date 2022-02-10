using AutomationForHomeworkTasks.Config;
using AutomationForHomeworkTasks.Constants;
using AutomationForHomeworkTasks.Models;
using RestSharp;
using Newtonsoft.Json;

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
            ExecuteRequest(new RestRequest(endpoint, Method.Get));
        }

        public T GetResponseData<T>()
        {
            return JsonConvert.DeserializeObject<T>(_response.Content);
        }

        public void PostRequest(string endpoint, User user)
        {
            var userForCreation = GetUserModel(user);
            ExecuteRequest(new RestRequest(endpoint, Method.Post).AddJsonBody(userForCreation));
        }

        public void PutRequest(string endpoint, User user)
        {
            var userForEdit = GetUserModel(user);
            ExecuteRequest(new RestRequest(endpoint, Method.Put).AddJsonBody(userForEdit));
        }

        public void DeleteRequest(string endpoint)
        {
            ExecuteRequest(new RestRequest(endpoint, Method.Delete));
        }

        private static User GetUserModel(User user)
        {
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                UserStatus = user.UserStatus,
            };
        }

        private void ExecuteRequest(RestRequest request)
        {
            int attempt = 1;
            while (attempt <= 5)
            {
                _response = _restClient.ExecuteAsync(request).GetAwaiter().GetResult();
                if (_response.IsSuccessful)
                {
                    break;
                }
                attempt++;
            }
        }
    }
}