using OpenQA.Selenium;

namespace Web_UI_Automation_xUnit
{
    public class EhuHomePage
    {
        private readonly IWebDriver _driver;
        private readonly By _aboutButton = By.XPath("//a[@href='https://en.ehuniversity.lt/about/']");
        private readonly By _searchDiv = By.CssSelector(".header-search");
        private readonly By _searchInput = By.CssSelector("[plerdy-tracking-id='30561103501']");
        private readonly By _searchButton = By.CssSelector("[plerdy-tracking-id=\"66179574101\"]");
        public EhuHomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void Open()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");
        }
        public void ClickAbout()
        {
            _driver.FindElement(_aboutButton).Click();
        }
        public void SearchFor(string text)
        {
            _driver.FindElement(_searchDiv).Click();
            _driver.FindElement(_searchInput).SendKeys(text);
            _driver.FindElement(_searchButton).Click();
        }
    }
}