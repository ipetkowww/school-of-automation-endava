using AutomationForHomeworkTasks.Config;
using AutomationForHomeworkTasks.Constants;
using AutomationForHomeworkTasks.Models;
using AutomationForHomeworkTasks.RestAPI;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationForHomeworkTasks
{
    [Binding]
    public class GetAllUsersSteps
    {   
        private readonly BaseApi _baseApi;

        public GetAllUsersSteps()
        {
            _baseApi = new BaseApi();
        }

        [When(@"The user executes GET request to endpoint ""([^""]*)""")]
        public void WhenTheUserExecutesGETRequestToEndpointAsync(string endpointUrl)
        {
            _baseApi.GetRequest(endpointUrl);
        }

        [Then(@"The user verifies status code is (.*) with message ""([^""]*)""")]
        public void ThenTheUserVerifiesStatusCodeIsWithMessage(int expectedStatusCode, string expectedMessage)
        {
            int actualStatusCode = _baseApi.ResponseStatusCode;
            string actualStatusMessage = _baseApi.ResponseMessage;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedStatusCode, actualStatusCode, "Status code is not correct!");
                Assert.AreEqual(expectedMessage, actualStatusMessage, "Status message is not correct!");
            });
        }

        [Then(@"The user verifies data for the users is not null")]
        public void ThenTheUserVerifiesBodyResultOfTheGetAllUsersRequest()
        {
            _baseApi.GetRequest("/users");
            List<UserModel> users = _baseApi.GetResponseData<List<UserModel>>();

            foreach (UserModel user in users)
            {
                if (user.Is_Admin != 1)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.IsNotNull(user.First_Name, "First name is null");
                        Assert.IsNotNull(user.Sir_Name, "First name is null");
                        Assert.IsNotNull(user.Email, "Email is null");
                        Assert.IsNotNull(user.City, "City is null");
                        Assert.IsNotNull(user.Country, "Country is null");
                        Assert.IsNotNull(user.ID, "ID is null");
                        Assert.IsNotNull(user.Title, "Title is null");
                    });
                }
            }
        }
    }
}
