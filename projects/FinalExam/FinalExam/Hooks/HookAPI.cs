using FinalExam.Constants;
using FinalExam.RestAPI;
using TechTalk.SpecFlow;

namespace FinalExam.Hooks
{
    [Binding]
    public class HookApi
    {
        private BaseApi _baseApi;
        private ScenarioContext _scenarioContext;

        private HookApi(BaseApi baseApi, ScenarioContext scenarioContext)
        {
            _baseApi = baseApi;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("api")]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _baseApi = new BaseApi();
            _scenarioContext = scenarioContext;
            _scenarioContext.Add(AppConstants.BaseApi, _baseApi);
        }

        [AfterScenario("api")]
        public void AfterScenario()
        {
            var id = _scenarioContext.Get<int>(AppConstants.UserIdForDeletion);
            _baseApi.DeleteRequest($"{AppConstants.UsersEndpoint}/{id}");
        }
    }
}