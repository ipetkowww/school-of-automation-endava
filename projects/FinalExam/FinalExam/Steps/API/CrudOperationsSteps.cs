using FinalExam.Constants;
using FinalExam.Models;
using FinalExam.RestAPI;
using FinalExam.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FinalExam.Steps.API
{
    [Binding]
    public class CrudOperationsSteps
    {
        private readonly BaseApi _baseApi;
        private readonly ScenarioContext _scenarioContext;

        public CrudOperationsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _baseApi = _scenarioContext.Get<BaseApi>(AppConstants.BaseApi);
        }

        [When(@"The user executes ""([^""]*)"" request to endpoint ""([^""]*)"" with body:")]
        public void WhenTheUserExecutesRequestToEndpointWithBody(string requestType, string endpoint, Table table)
        {
            if (requestType.Equals("POST"))
            {
                var creationUser = table.CreateInstance<User>();
                _baseApi.PostRequest(endpoint, creationUser);
                var createdUser = _baseApi.GetResponseData<CreatedUser>();
                _scenarioContext.Add(AppConstants.UserForCreation, creationUser);
                _scenarioContext.Add(AppConstants.CreatedUser, createdUser);
                _scenarioContext.Add(AppConstants.UserIdForDeletion, createdUser.Id);
            }
            else
            {
                var createdUser = _scenarioContext.Get<CreatedUser>(AppConstants.CreatedUser);
                var userForEdit = table.CreateInstance<User>();
                if (userForEdit.Email!.Equals(AppConstants.RandomEmail))
                {
                    userForEdit.Email = Helper.GetRandomEmail();
                }
                _baseApi.PatchRequest($"{endpoint}/{createdUser.Id}", userForEdit);
                _scenarioContext.Add(AppConstants.UserForEdit, userForEdit);
            }
        }

        [When(@"The user executes GET request to endpoint ""([^""]*)""")]
        public void WhenTheUserExecutesGetRequestToEndpoint(string endpointUrl)
        {
            _baseApi.GetRequest(endpointUrl);
        }

        [Then(@"The user verifies status code is (.*) with message ""([^""]*)""")]
        public void ThenTheUserVerifiesStatusCodeIsWithMessage(int expectedStatusCode, string expectedMessage)
        {
            var actualStatusCode = _baseApi.ResponseStatusCode;
            var actualStatusMessage = _baseApi.ResponseMessage;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedStatusCode, actualStatusCode, "Status code is not correct!");
                Assert.AreEqual(expectedMessage, actualStatusMessage, "Status message is not correct!");
            });
        }

        [Then(@"The user verifies that user with email ""(.*)"" is successfully created")]
        public void ThenTheUserVerifiesThatUserWithEmailIsSuccessfullyCreated(string email)
        {
            var createdUser = _scenarioContext.Get<CreatedUser>(AppConstants.CreatedUser);
            WhenTheUserExecutesGetRequestToEndpoint($"{AppConstants.UsersEndpoint}/{createdUser.Id}");
            var actualUserData = _baseApi.GetResponseData<CreatedUser>();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(actualUserData.Email, email, "User Email is not correct.");
                Assert.AreEqual(createdUser.Gender, actualUserData.Gender, "User Gender is not correct.");
                Assert.AreEqual(createdUser.Name, actualUserData.Name, "User Name is not correct.");
                Assert.AreEqual(createdUser.Status, actualUserData.Status, "User Status is not correct.");
                Assert.AreEqual(createdUser.Id, actualUserData.Id, "User ID is not correct.");
            });
        }

        [Then(@"The user verifies that user data is successfully edited")]
        public void ThenTheUserVerifiesThatUserDataIsSuccessfullyEdited()
        {
            var expectedEditedUserData  = _scenarioContext.Get<User>(AppConstants.UserForEdit);
            var actualEditedUserData = _baseApi.GetResponseData<CreatedUser>();
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedEditedUserData.Email, actualEditedUserData.Email, "User Email is not correct.");
                Assert.AreEqual(expectedEditedUserData.Gender, actualEditedUserData.Gender, "User Gender is not correct.");
                Assert.AreEqual(expectedEditedUserData.Name, actualEditedUserData.Name, "User Name is not correct.");
                Assert.AreEqual(expectedEditedUserData.Status, actualEditedUserData.Status, "User Status is not correct.");
            });
        }
    }
}