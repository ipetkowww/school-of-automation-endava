using System;
using FinalExam.Pages;
using FinalExam.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FinalExam.Steps.UI
{
    [Binding]
    public class UpdateProfileSteps
    {
        private readonly UpdateProfilePage _updateProfilePage;
        private UserTestData? _editedUser;

        public UpdateProfileSteps(IWebDriver driver)
        {
            _updateProfilePage = new UpdateProfilePage(driver);
        }

        [When(@"The user updates the profile with the following data:")]
        public void WhenTheUserUpdatesTheProfileWithTheFollowingData(Table table)
        {
            _editedUser = table.CreateInstance<UserTestData>();
            _updateProfilePage.EnterFirstName(_editedUser.FirstName!);
            _updateProfilePage.EnterLastName(_editedUser.LastName!);
            _updateProfilePage.EnterAddress(_editedUser.Address!);
            _updateProfilePage.EnterCity(_editedUser.City!);
            _updateProfilePage.EnterState(_editedUser.State!);
            _updateProfilePage.EnterZipcode(_editedUser.Zipcode!);
            _updateProfilePage.ClickUpdateProfileButton();
        }

        [Then(@"The user verifies profile info is updated")]
        public void ThenTheUserVerifiesProfileInfoIsUpdated()
        {
            var successfulMessageForUpdate = _updateProfilePage.GetSuccessfulMessageForUpdate();
            const string expectedMessage = "Your updated address and phone number have been added to the system.";
            _updateProfilePage.AccountServicesSection.ClickUpdateContactInfo();

            Assert.IsTrue(_updateProfilePage.IsUpdateFormDisplayed(), "Update Profile form is not displayed");
            Assert.Multiple(() =>
            {
                Assert.AreEqual(successfulMessageForUpdate, expectedMessage, "Profile update not successful");
                Assert.AreEqual(_updateProfilePage.FirstNameValue, _editedUser!.FirstName, 
                    "First Name updated value is not correct");
                Assert.AreEqual(_updateProfilePage.LastNameValue, _editedUser.LastName, 
                    "Last Name updated value is not correct");
                Assert.AreEqual(_updateProfilePage.AddressValue, _editedUser.Address, 
                    "Address updated value is not correct");
                Assert.AreEqual(_updateProfilePage.CityValue, _editedUser.City, 
                    "City updated value is not correct");
                Assert.AreEqual(_updateProfilePage.StateValue, _editedUser.State, 
                    "State updated value is not correct");
                Assert.AreEqual(_updateProfilePage.ZipcodeValue, _editedUser.Zipcode, 
                    "Zipcode updated value is not correct");
            });
        }
    }
}