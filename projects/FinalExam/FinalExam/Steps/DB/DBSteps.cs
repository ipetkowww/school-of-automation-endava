using System.Collections.Generic;
using FinalExam.Constants;
using FinalExam.DataBase.DataContext;
using FinalExam.DataBase.Entities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace FinalExam.Steps.DB
{
    [Binding]
    [Scope(Tag = "@DB")]
    public class DBSteps
    {
        private readonly LiteratureReferenceRepository _literatureReferenceRepository;
        private IEnumerable<LiteratureReferenceEntity>? _specificEntities;

        public DBSteps(FeatureContext featureContext)
        {
            _literatureReferenceRepository = featureContext
                .Get<LiteratureReferenceRepository>(AppConstants.LiteratureReferenceRepository);
        }

        [When(@"The user get all records where title contains word ""(.*)""")]
        public void WhenTheUserGetAllRecordsWhereTitleContainsWord(string word)
        {
            _specificEntities = _literatureReferenceRepository.LiteratureRefRepository
                .Get(e => e.Title!.Contains(word));
        }

        [Then(@"The user verifies all fetched data contain word ""(.*)"" in title")]
        public void ThenTheUserVerifiesAllFetchedDataContainWordInTitle(string word)
        {
            foreach (var literatureReferenceEntity in _specificEntities!)
            {
                string currentTitle = literatureReferenceEntity.Title!;
                Assert.IsTrue(currentTitle.Contains(word), 
                    $"Current title: '{currentTitle}' does not contain word: {word}");
            }
        }
    }
}