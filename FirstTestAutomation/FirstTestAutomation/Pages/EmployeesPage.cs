using FirstTestAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTestAutomation.Pages
{
    public class EmployeesPage
    {
        public void CreateNewEmployee(IWebDriver driver)
        {
            //Identify and click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Identify and enter Name
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.SendKeys("Jack");

            //Identify and enter username
            IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
            usernameTextbox.SendKeys("JackAugust2023");

            //Identify and enter password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("Qw!12345");

            //Identify and enter RetypePassword
            IWebElement retypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            retypePasswordTextbox.SendKeys("Qw!12345");

            // Identify and click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            // Check if new Employee was created 
            IWebElement backToListbutton = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backToListbutton.Click();

            Wait.waitToBEClickable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[4]/a[4]/span", 10);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement createdName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(createdName.Text == "Jack", $"New Employee has not been created. Actual: {createdName.Text}");

        }
        public void EditEmployee(IWebDriver driver)
        {
            Wait.waitToBEClickable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[4]/a[4]/span", 5);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            editButton.Click();

            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.Clear();
            nameTextbox.SendKeys("JackEdited");

            IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
            usernameTextbox.Clear();
            usernameTextbox.SendKeys("JackAugustEdited");
            
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();


            IWebElement backToListbutton = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backToListbutton.Click();

            IWebElement goToLastPageButtonEdited = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonEdited.Click();

            // Wait.waitIsVisible(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]", 10);
            Thread.Sleep(2000);

            IWebElement editedName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedUsername = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));

            Assert.That(editedName.Text == "JackEdited"&&
                        editedUsername.Text == "JackAugustEdited", $"Employee record has NOT been edited successfully. {editedName.Text} {editedUsername.Text}");


        }
        public void DeleteEmployee(IWebDriver driver) 
        {
        
        }
    }
}
