using Reqnroll;
using Web_UI_Automation_xUnit;
using Xunit;

namespace Web_UI_Automation_xUnit.StepDefinitions
{
    [Binding]
    public class EhuSteps
    {
        private readonly EhuHomePage _homePage;
        private readonly OpenQA.Selenium.IWebDriver _driver;

        public EhuSteps()
        {
            _driver = WebDriverManager.Instance.GetDriver();
            _homePage = new EhuHomePage(_driver);
        }

        [Given(@"I open the EHU home page")]
        public void GivenIOpenTheEHUHomePage()
        {
            _homePage.Open();
        }

        [When(@"I click on the About link")]
        public void WhenIClickOnTheAboutLink()
        {
            _homePage.ClickAbout();
        }

        [Then(@"the page title should contain ""(.*)""")]
        public void ThenThePageTitleShouldContain(string expectedTitleSubstring)
        {
            Assert.Contains(expectedTitleSubstring, _driver.Title);
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string searchWord)
        {
            _homePage.SearchFor(searchWord);
        }

        [Then(@"the page URL should end with ""(.*)""")]
        public void ThenThePageUrlShouldEndWith(string expectedUrl)
        {
            Assert.EndsWith(expectedUrl, _driver.Url);
        }
    }
}