using FirstTestAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTestAutomation.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver, string code = "August2023")
        {
            //Identify and click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            // Identify material/time drop down and choose time
            IWebElement timeMaterialDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            timeMaterialDropdown.Click();
            IWebElement timeDropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeDropdown.Click();

            // Identify Code textbox and enter code
            IWebElement textboxCode = driver.FindElement(By.Id("Code"));
            textboxCode.SendKeys(code);

            // Identify description textbox and enter decription
            IWebElement textboxDescription = driver.FindElement(By.Id("Description"));
            textboxDescription.SendKeys("August2023");

            // Identify price textbox and enter price
            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("23");

            // Identify and click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Wait.waitToBEClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]", 5);

            // Check if new new record was created
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            goToLastPage.Click();
            
            IWebElement newRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            Assert.That(newRecord.Text == code, "New Time record has not been created");
           
        }
        public void EditTimeRecord(IWebDriver driver) 
        {
      

            Thread.Sleep(2000);
            // Identify and click Edit button 
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            // Change the code
            IWebElement edittextboxCode = driver.FindElement(By.Id("Code"));
            edittextboxCode.Clear();
            edittextboxCode.SendKeys("EditedAugust2023");

            // change description
            IWebElement edittextboxDescription = driver.FindElement(By.Id("Description"));
            edittextboxDescription.Clear();
            edittextboxDescription.SendKeys("EditedAugust2023");

            //Change price
            IWebElement overlapPriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editPricetextbox = driver.FindElement(By.Id("Price"));
            overlapPriceTextbox.Click();
            editPricetextbox.Clear();
            overlapPriceTextbox.Click();
            editPricetextbox.SendKeys("2023");

            // Save
            IWebElement editedsaveButton = driver.FindElement(By.Id("SaveButton"));
            editedsaveButton.Click();

            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);

            // Check if the record was edited
        
            IWebElement editedCodeRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedDescRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPriceRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(editedCodeRecord.Text == "EditedAugust2023" &&
                editedDescRecord.Text == "EditedAugust2023" &&
                editedPriceRecord.Text == "$2,023.00",
                "New Time record has not been edited");
            
        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);

            //Check the Code of the last element 
            IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            string lastRecordText = lastRecord.Text;

            // Click on Delete 
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            driver.SwitchTo().Alert().Accept();

            var wait = new WebDriverWait(driver, new TimeSpan (0,0,5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(lastRecord));

            // check if the last record was deleted
            IWebElement deleteLastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(deleteLastRecord.Text != lastRecordText, "The record wasn't deleted");
            
        }
    }
}
