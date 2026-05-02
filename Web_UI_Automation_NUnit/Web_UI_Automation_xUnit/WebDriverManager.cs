using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Threading;

namespace Web_UI_Automation_xUnit
{
    // Патерн Singleton (Required) + елементи Factory (Optional)
    public sealed class WebDriverManager
    {
        private static readonly Lazy<WebDriverManager> _instance = new Lazy<WebDriverManager>(() => new WebDriverManager());
        private ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();
        public static WebDriverManager Instance => _instance.Value;
        public IWebDriver GetDriver()
        {
            if (_driver.Value == null)
            {
                _driver.Value = new EdgeDriver();
                _driver.Value.Manage().Window.Maximize();
            }
            return _driver.Value;
        }

        public void QuitDriver()
        {
            if (_driver.Value != null)
            {
                _driver.Value.Quit();
                _driver.Value.Dispose();
                _driver.Value = null;
            }
        }
    }
}