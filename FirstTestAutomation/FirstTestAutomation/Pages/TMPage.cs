using FirstTestAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirstTestAutomation.Pages
{
    public class TMPage
    {
        public static string DeletedItemCode { get; set; }

        public void CreateTimeRecord(IWebDriver driver, string code)
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

            // Check if new record was created
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            goToLastPage.Click();      
        }

        public string GetNewRecordCode(IWebDriver driver)
        {
            IWebElement newRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newRecordCode.Text;
        }

        public void EditTimeRecord(IWebDriver driver, string code, string description, string price) 
        {
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            goToLastPage.Click();  

            // Identify and click Edit button 
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            // Change the code
            IWebElement editTextboxCode = driver.FindElement(By.Id("Code"));
            editTextboxCode.Clear();
            editTextboxCode.SendKeys(code);

            // change description
            IWebElement editTextboxDescription = driver.FindElement(By.Id("Description"));
            editTextboxDescription.Clear();
            editTextboxDescription.SendKeys(description);

            //Change price
            IWebElement overlapPriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editPriceTextbox = driver.FindElement(By.Id("Price"));
            overlapPriceTextbox.Click();
            editPriceTextbox.Clear();
            overlapPriceTextbox.Click();
            editPriceTextbox.SendKeys(price);

            // Save
            IWebElement editedsaveButton = driver.FindElement(By.Id("SaveButton"));
            editedsaveButton.Click();

            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]", 5);

            IWebElement goToLastPageAgain = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            goToLastPageAgain.Click();
        }
       
        public Tuple<string, string, string> GetEditedRcords(IWebDriver driver) 
        {
            IWebElement editedCodeRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedDescRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPriceRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return new Tuple<string, string, string>(editedCodeRecord.Text, editedDescRecord.Text, editedPriceRecord.Text);
        }


        public void DeleteTimeRecord(IWebDriver driver)
        {
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            goToLastPage.Click();

            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);

            //Check the Code of the last element
            IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            // Click on Delete 
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            driver.SwitchTo().Alert().Accept();

            var wait = new WebDriverWait(driver, new TimeSpan (0,0,5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(lastRecord));
        }

        public string GetLastRecordText(IWebDriver driver)
        {
            Wait.waitIsVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);
            return driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text;
        }

            
    }
}
