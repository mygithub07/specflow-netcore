using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyTests.Tests.Drivers
{
    public class BrowserDriver
    {
        public readonly OpenQA.Selenium.IWebDriver _driver;
        public WebDriverWait _wait;
             
        public static readonly BrowserSeleniumDriverFactory bdf;

        WebDriver webDriver = new WebDriver(bdf);

        public BrowserDriver(WebDriver webDriver)
        {
            _driver = webDriver.Current;
            _wait = webDriver.Wait;
        }

        public void goToURL(string url)
        {
            // _webDriver.Wait.Until<IResult>(d => d.Navigate().GoToUrl(url) );

            _driver.Navigate().GoToUrl(url);
        }

        public void ValidateTitleShouldBe(string expectedTitle)
        {
            string result = _wait.Until(d => d.Title);
            result.Should().Be(expectedTitle);
        }


    }
}
