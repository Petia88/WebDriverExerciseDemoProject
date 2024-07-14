using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HandlingFormInputs
{
    public class HandlingFormInputTests
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
        

        [Test]
        public void HandlingFormInputs()
        {
            //click on my account
            var myAccountButton = driver.FindElements(By.XPath("//span[@class='ui-button-text']"))[2];
            myAccountButton.Click();

            //click continue button
            driver.FindElement(By.LinkText("Continue")).Click();

            //click male radio button
            driver.FindElement(By.XPath("//input[@type='radio'][@value='m']")).Click();

            //field value first name field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='firstname']")).SendKeys("Petia");

            //field value last name field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='lastname']")).SendKeys("Bogdanova");

            //field the date input
            driver.FindElement(By.Id("dob")).SendKeys("07/13/2024");

            //generate random email
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999);
            string email = "petia" + randomNumber.ToString() + "@gmail.com";

            //fill email field
            driver.FindElement(By.Name("email_address")).SendKeys(email);

            //fill company field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='company']")).SendKeys("SoftUni");

            //fill street address field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='street_address']")).SendKeys("Petar Nikov 12");

            //fill suburb field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='suburb']")).SendKeys("Sofia");

            //fill postal code field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='postcode']")).SendKeys("1000");

            //fill city field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='city']")).SendKeys("Sofia");

            //fill state field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='state']")).SendKeys("Sofia");

            //select country drop-down field
            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("Bulgaria");

            //fill telephone field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='telephone']")).SendKeys("0898912");

            //click newsletter checkbox
            driver.FindElement(By.XPath("//input[@name='newsletter']")).Click();

            //fill password field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='password']")).SendKeys("secret_Password");

            //fill confirm password field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='confirmation']")).SendKeys("secret_Password");

            //click continue button
            driver.FindElement(By.Id("tdb4")).Click();

            //assert success message
            Assert.AreEqual(driver.FindElement(By.XPath("//div[@id='bodyContent']//h1")).Text, "Your Account Has Been Created!");

            //click log off button
            driver.FindElement(By.LinkText("Log Off")).Click();

            //click continue button
            driver.FindElement(By.LinkText("Continue")).Click();

            Console.WriteLine("User Created Successfully!");
        }
    }
}