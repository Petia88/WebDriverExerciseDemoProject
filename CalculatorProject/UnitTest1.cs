using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalculatorProject
{
    public class Tests
    {
        WebDriver driver;
        IWebElement textBoxNumber1;
        IWebElement textBoxNumber2;
        IWebElement dropDownOperations;
        IWebElement calcButton;
        IWebElement resetButton;
        IWebElement divResult;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [SetUp]
        public void Setup()
        {
            
            textBoxNumber1 = driver.FindElement(By.Id("number1"));
            textBoxNumber2 = driver.FindElement(By.Id("number2"));
            dropDownOperations = driver.FindElement(By.Id("operation"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));
            divResult = driver.FindElement(By.Id("result"));

        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public void PerformTestLogic(string firstNumber, string secondNumber, string operation, string expected)
        {
            if (!string.IsNullOrEmpty(firstNumber))
            {
                textBoxNumber1.SendKeys(firstNumber);
            }

            if (!string.IsNullOrEmpty(secondNumber))
            {
                textBoxNumber2.SendKeys(secondNumber);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropDownOperations).SelectByText(operation);
            }

            calcButton.Click();

            Assert.That(divResult.Text, Is.EqualTo(expected));
            resetButton.Click();
        }


            [Test]
        [TestCase("5", "10", "+ (sum)", "Result: 15")]
        [TestCase("3.5", "1.2", "- (subtract)", "Result: 2.3")]
        [TestCase("200", "1.5", "* (multiply)", "Result: 300")]
        [TestCase("invalid", "10", "+ (sum)", "Result: invalid input")]
        [TestCase("", "10", "+ (sum)", "Result: invalid input")]
        [TestCase("", "10", "* (multiply)", "Result: invalid input")]
        [TestCase("", "10", "/ (divide)", "Result: invalid input")]
        [TestCase("150", "10", "/ (divide)", "Result: 15")]
        [TestCase("", "10", "- (subtract)", "Result: invalid input")]
        [TestCase("5", "", "* (multiply)", "Result: invalid input")]
        [TestCase("5", "abvgflnhfv", "* (multiply)", "Result: invalid input")]
        [TestCase("5", "", "- (subtract)", "Result: invalid input")]
        [TestCase("5", "0", "/ (divide)", "Result: Infinity")]
        [TestCase("1", "infinity", "+ (sum)", "Result: invalid input")]
        [TestCase("1", "infinity", "- (subtract)", "Result: invalid input")]
        [TestCase("3", "infinity", "* (multiply)", "Result: invalid input")]
        [TestCase("infinity", "infinity", "* (multiply)", "Result: invalid input")]
        [TestCase("infinity", "infinity", "/ (divide)", "Result: invalid input")]

        public void Test1(string firstNumber, string secondNumber, string operation, string expected)
        {
            PerformTestLogic(firstNumber, secondNumber, operation, expected);
        }
    }
}