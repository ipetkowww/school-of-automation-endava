using AutomationForHomeworkTasks.Constants;
using AutomationForHomeworkTasks.RestAPI;
using TechTalk.SpecFlow;

namespace AutomationForHomeworkTasks.Steps.Hooks
{
    [Binding]
    public class HookApi
    {
        private BaseApi _baseApi;
        private ScenarioContext _scenarioContext;

        [BeforeScenario("api")]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _baseApi = new BaseApi();
            _scenarioContext = scenarioContext;
            _scenarioContext.Add("baseApi", _baseApi);
        }

        [AfterScenario("api")]
        public void AfterScenario()
        {
            string username = _scenarioContext.Get<string>(StringConstants.UsernameForDeletion);
            _baseApi.DeleteRequest($"/user/{username}");
        }
    }
}