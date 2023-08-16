using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTestAutomation.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
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
            textboxCode.SendKeys("August2023");

            // Identify description textbox and enter decription
            IWebElement textboxDescription = driver.FindElement(By.Id("Description"));
            textboxDescription.SendKeys("August2023");

            // Identify price textbox and enter price
            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("23");

            // Identify and click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);

            // Check if new new record was created
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            goToLastPage.Click();
            IWebElement newRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if (newRecord.Text == "August2023")
            {
                Console.WriteLine("New Time record has been created successfully");
            }
            else
            {
                Console.WriteLine("New Time record has not been created");
            }

        }
        public void EditTimeRecord(IWebDriver driver) 
        {
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
            Thread.Sleep(2000);

            // Check if the record was edited
            IWebElement editedgoToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            editedgoToLastPage.Click();
            IWebElement editedCodeRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedDescRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPriceRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));


            if (editedCodeRecord.Text == "EditedAugust2023" && editedDescRecord.Text == "EditedAugust2023" && editedPriceRecord.Text == "$2,023.00")
            {
                Console.WriteLine("New Time record has been edited successfully");
            }
            else
            {
                Console.WriteLine("New Time record has not been edited");
            }
        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Check the Code of the last element 
            string lastRecordText = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text;

            // Click on Delete 
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(2000);

            // check if the last record was deleted
            IWebElement deleteLastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (deleteLastRecord.Text != lastRecordText)
            {
                Console.WriteLine("The record was deleted successfully");
            }
            else
            {
                Console.WriteLine("The record wasn't deleted");
            }
        }
    }
}
