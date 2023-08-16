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

// Navigate to Administration
IWebElement administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
administration.Click();

// Choose Time&Materials from drop down menu
IWebElement timeManagment = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")); 
timeManagment.Click();

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



// Identify and click Edit button 
IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
editButton.Click();

// Change the code
IWebElement edittextboxCode = driver.FindElement(By.Id("Code"));
edittextboxCode.Clear();
edittextboxCode.SendKeys("EditedAugust2023");

// Save
IWebElement editedsaveButton = driver.FindElement(By.Id("SaveButton"));
editedsaveButton.Click();
Thread.Sleep(2000);

// Check if the record was edited
IWebElement editedgoToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
editedgoToLastPage.Click();
IWebElement editedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if (editedRecord.Text == "EditedAugust2023")
{
    Console.WriteLine("New Time record has been edited successfully");
}
else
{
    Console.WriteLine("New Time record has not been edited");
}


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





