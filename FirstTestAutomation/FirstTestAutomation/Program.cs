using FirstTestAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

internal class Program
{
    public static void Main(string[] args)
    {
        // Open the Browser
        IWebDriver driver = new ChromeDriver();

        // Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        // Home page object initialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.GoToTMpage(driver);

        // Time&material page initialization and definition
        TMPage tMPage = new TMPage();
        tMPage.CreateTimeRecord(driver);

        tMPage.EditTimeRecord(driver);

        tMPage.DeleteTimeRecord(driver);
    }
}