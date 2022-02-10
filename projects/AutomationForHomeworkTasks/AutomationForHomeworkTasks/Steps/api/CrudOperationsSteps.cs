using AutomationForHomeworkTasks.Constants;
using AutomationForHomeworkTasks.Models;
using AutomationForHomeworkTasks.RestAPI;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationForHomeworkTasks
{
    [Binding]
    public class CrudOperationsSteps
    {
        private readonly BaseApi _baseApi;
        private readonly ScenarioContext _scenarioContext;

        public CrudOperationsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _baseApi = _scenarioContext.Get<BaseApi>("baseApi");
        }

        [When(@"The user executes ""([^""]*)"" request to endpoint ""([^""]*)"" with body:")]
        public void WhenTheUserExecutesRequestToEndpointWithBody(string requestType, string endpoint, Table table)
        {
            if (requestType.Equals("POST"))
            {
                User user = table.CreateInstance<User>();
                _baseApi.PostRequest(endpoint, user);
                _scenarioContext.Add(StringConstants.UserForCreation, user);
            }
            else
            {
                User userForEdit = table.CreateInstance<User>();
                _baseApi.PutRequest(endpoint, userForEdit);
                _baseApi.DeleteRequest($"/user/{_scenarioContext.Get<User>(StringConstants.UserForCreation).Username}");
                _scenarioContext.Add(StringConstants.UserForEdit, userForEdit);
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
            int actualStatusCode = _baseApi.ResponseStatusCode;
            string actualStatusMessage = _baseApi.ResponseMessage;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedStatusCode, actualStatusCode, "Status code is not correct!");
                Assert.AreEqual(expectedMessage, actualStatusMessage, "Status message is not correct!");
            });
        }

        [Then(@"The user verifies that user with id (.*) and username ""([^""]*)"" is successfully created")]
        public void ThenTheUserVerifiesThatUserWithIdAndUsernameIsSuccessfullyCreated(int id, string username)
        {
            WhenTheUserExecutesGetRequestToEndpoint($"/user/{username}");
            User createdUser = _baseApi.GetResponseData<User>();
            User userForCreation = _scenarioContext.Get<User>(StringConstants.UserForCreation);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(createdUser.Id, id, "User ID is not correct.");
                Assert.AreEqual(createdUser.Username, username, "Username is not correct.");
                Assert.AreEqual(createdUser.FirstName, userForCreation.FirstName, "FirstName is not correct.");
                Assert.AreEqual(createdUser.LastName, userForCreation.LastName, "LastName is not correct.");
                Assert.AreEqual(createdUser.Email, userForCreation.Email, "Email is not correct.");
                Assert.AreEqual(createdUser.Password, userForCreation.Password, "Password is not correct");
                Assert.AreEqual(createdUser.Phone, userForCreation.Phone, "Phone is not correct");
                Assert.AreEqual(createdUser.UserStatus, userForCreation.UserStatus, "UserStatus is not correct");
            });

            _scenarioContext.Add(StringConstants.UsernameForDeletion, createdUser.Username);
        }

        [Then(@"The user verifies that user data for username ""([^""]*)"" is successfully edited")]
        public void ThenTheUserVerifiesThatUserDataForUsernameIsSuccessfullyEdited(string username)
        {
            WhenTheUserExecutesGetRequestToEndpoint($"/user/{username}");
            User editedUser = _baseApi.GetResponseData<User>();
            User userForEdit = _scenarioContext.Get<User>(StringConstants.UserForEdit);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(editedUser.Id, userForEdit.Id, "User ID is not correct.");
                Assert.AreEqual(editedUser.Username, username, "Username is not correct.");
                Assert.AreEqual(editedUser.FirstName, userForEdit.FirstName, "FirstName is not correct.");
                Assert.AreEqual(editedUser.LastName, userForEdit.LastName, "LastName is not correct.");
                Assert.AreEqual(editedUser.Email, userForEdit.Email, "Email is not correct.");
                Assert.AreEqual(editedUser.Password, userForEdit.Password, "Password is not correct");
                Assert.AreEqual(editedUser.Phone, userForEdit.Phone, "Phone is not correct");
                Assert.AreEqual(editedUser.UserStatus, userForEdit.UserStatus, "UserStatus is not correct");
            });

            _scenarioContext.Add(StringConstants.UsernameForDeletion, editedUser.Username);
        }
    }
}