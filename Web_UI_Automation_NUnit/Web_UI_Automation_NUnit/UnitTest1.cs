using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Threading;

// Цей рядок включає паралельне виконання тестів
[assembly: Parallelizable(ParallelScope.All)]

namespace Web_UI_Automation_NUnit
{
    [TestFixture]
    public class UnitTest1
    {
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>()!;

        [SetUp]
        public void Setup()
        {
            driver.Value = new EdgeDriver();
            driver.Value.Manage().Window.Maximize();
        }

        [Test]
        [Category("Navigation")]
        public void task1()
        {
            driver.Value.Navigate().GoToUrl("https://en.ehu.lt/");
            IWebElement about_button = driver.Value.FindElement(By.XPath("//a[@href='https://en.ehuniversity.lt/about/']"));
            about_button.Click();
            Assert.That(driver.Value.Title, Does.Contain("About"));
        }

        [TestCase("study programs", "?s=study+programs")]
        [TestCase("admissions", "?s=admissions")]
        [Category("Search")]
        public void task2(string searchWord, string expectedUrl)
        {
            driver.Value.Navigate().GoToUrl("https://en.ehu.lt/");
            IWebElement searchDiv = driver.Value.FindElement(By.CssSelector(".header-search"));
            IWebElement searchInput = driver.Value.FindElement(By.CssSelector("[plerdy-tracking-id='30561103501']"));
            IWebElement searchButton = driver.Value.FindElement(By.CssSelector("[plerdy-tracking-id=\"66179574101\"]"));

            searchDiv.Click();
            searchInput.SendKeys(searchWord); 
            searchButton.Click();

            Assert.That(driver.Value.Url, Does.EndWith(expectedUrl));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Value.Quit();
        }
    }
}