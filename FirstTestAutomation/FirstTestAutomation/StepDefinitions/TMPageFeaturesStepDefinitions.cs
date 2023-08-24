using FirstTestAutomation.Pages;
using FirstTestAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Security.AccessControl;
using TechTalk.SpecFlow;

namespace FirstTestAutomation.StepDefinitions
{
    [Binding]
    public class TMPageFeaturesStepDefinitions: CommonDriver
    {


        [Given(@"I logged in to TurnUp portal successfully")]
        public void GivenILoggedInToTurnUpPortalSuccessfully()
        {
            driver = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }
        [Given(@"I navigated to Time&Material page")]
        public void GivenINavigatedToTimeMaterialPage()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMpage(driver);
        }

        [When(@"I create new record")]
        public void WhenICreateNewRecord()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver, "August2023");
        }

        [Then(@"the new record should be created succefssfully and appear in the table")]
        public void ThenTheNewRecordShouldBeCreatedSuccefssfullyAndAppearInTheTable()
        {
            TMPage tMPageObj = new TMPage();
            string newRecordCode = tMPageObj.GetNewRecordCode(driver);
            Assert.That(newRecordCode == "August2023", "Actual code and new code do not match");
        }
        

        [When(@"I update '([^']*)', '([^']*)', '([^']*)' in existing Time record")]
        public void WhenIUpdateInExistingTimeRecord(string p0, string p1, string p2)
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRecord(driver, p0, p1, p2);

        }

        [Then(@"the rewcord should have updated '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenTheRewcordShouldHaveUpdated(string p0, string p1, string p2)
        {
            TMPage tMPageObj = new TMPage();
            var editedRecords = tMPageObj.GetEditedRcords(driver);
            Assert.That(editedRecords.Item1 == p0, "Actual code and edited code do not match");
            Assert.That(editedRecords.Item2 == p1, "Actual description and edited description do not match");
            Assert.That(editedRecords.Item3 =="$"+p2, "Actual price and edited price do not match");
        }
        [When(@"I delete an existing record")]
        public void WhenIDeleteAnExistingRecord()
        {
            TMPage tMPageObj= new TMPage();
            TMPage.DeletedItemCode = tMPageObj.GetLastRecordText(driver);
            tMPageObj.DeleteTimeRecord(driver);
        }

        [Then(@"the record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            TMPage tMPageObj = new TMPage();
            string lastRecordText = tMPageObj.GetLastRecordText(driver);

            Assert.That(TMPage.DeletedItemCode != lastRecordText, "The record wasn't deleted");
        }

    }
}
