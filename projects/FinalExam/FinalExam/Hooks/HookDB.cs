using FinalExam.Constants;
using FinalExam.DataBase.DataContext;
using TechTalk.SpecFlow;

namespace FinalExam.Hooks
{
    [Binding]
    [Scope(Feature = "DatabaseTests")]
    public class HookDb
    {
        [BeforeFeature]
        public static void FeatureSetUp(FeatureContext featureContext)
        {
            featureContext.Add(AppConstants.LiteratureReferenceRepository, new LiteratureReferenceRepository());
        }
    }
}