using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyTests.Tests.Drivers
{
    public class WebDriver : IDisposable
    {
        private readonly BrowserSeleniumDriverFactory _browserSeleniumDriverFactory;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;

        private readonly IWebDriver _currentWebDriver;
        private readonly WebDriverWait _wait;

        private readonly Lazy<WebDriverWait> _waitLazy;
        private readonly TimeSpan _waitDuration = TimeSpan.FromSeconds(10);
        private bool _isDisposed;

        public WebDriver(BrowserSeleniumDriverFactory browserSeleniumDriverFactory)
        {
            _browserSeleniumDriverFactory = new BrowserSeleniumDriverFactory();
            // _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
            _currentWebDriver = GetWebDriver();
            _wait = GetWebDriverWait();
        }

      //  public IWebDriver Current => _currentWebDriverLazy.Value;

        public IWebDriver Current => _currentWebDriver;

       // public WebDriverWait Wait => _waitLazy.Value;

        public WebDriverWait Wait => _wait;

        private WebDriverWait GetWebDriverWait()
        {
            return new WebDriverWait(Current, _waitDuration);
        }

        private IWebDriver GetWebDriver()
        {
           // string testBrowserId = Environment.GetEnvironmentVariable("Test_Browser");
            //return _browserSeleniumDriverFactory.GetForBrowser("CHROME");
            return _browserSeleniumDriverFactory.GetForBrowser("FIREFOX");
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}
