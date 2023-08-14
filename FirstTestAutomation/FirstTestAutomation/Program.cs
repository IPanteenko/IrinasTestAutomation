using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Open the Browser
IWebDriver driver = new ChromeDriver();

// Launch Turnup portal and navigate to Login page
driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

// Identify username textbox and enter valid user name
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

// Identify password texbox and enter valid password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

// Identify Login button and click on the button
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click();

// Check if user logged in successfully
// Sidenote: decided to rely on page title here
// because username can change, but page title looks more stable 
if (driver.Title == "Dashboard - Dispatching System")
{
    Console.WriteLine("Login successfull");
}
else
{
    Console.WriteLine("Login unsuccessfull");
}