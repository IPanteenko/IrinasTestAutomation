using FirstTestAutomation.Pages;
using FirstTestAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirstTestAutomation.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employees_tests : CommonDriver
    {
        [SetUp]
        public void SetUpEmployee()
        {
            driver = new ChromeDriver();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeesPage(driver);
        }

        [Test]
        public void CreateEmployee_Test()
        {
            EmployeesPage employeesPageObj = new EmployeesPage();
            employeesPageObj.CreateNewEmployee(driver);
        }

        [Test]

        public void EditEmployee_Test()
        {
            EmployeesPage employeePageObj = new EmployeesPage();
            employeePageObj.EditEmployee(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            EmployeesPage employeePageObj = new EmployeesPage();
            driver.Quit();
        }
    }
}
