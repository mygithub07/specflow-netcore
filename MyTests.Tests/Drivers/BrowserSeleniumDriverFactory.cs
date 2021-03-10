using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Firefox;

//using TechTalk.SpecRun;

namespace MyTests.Tests.Drivers     
{
    public class BrowserSeleniumDriverFactory
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MyTests.Tests.Drivers.BrowserSeleniumDriverFactory));
      //  private readonly ConfigurationDriver _configurationDriver;
       // private readonly TestRunContext _testRunContext;    

        public BrowserSeleniumDriverFactory()
        {
           // _configurationDriver = configurationDriver;
           // _testRunContext = testRunContext;
        }

        public IWebDriver GetForBrowser(string browserId)
        {
            string lowerBrowserId = browserId.ToUpper();
            switch (lowerBrowserId)
            {
               // case "IE": return GetInternetExplorerDriver();
                case "CHROME": return GetChromeDriver();
                case "FIREFOX": return GetFirefoxDriver();
                case string browser: throw new NotSupportedException($"{browser} is not a supported browser");
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }
        
        private IWebDriver GetFirefoxDriver()
        {
            /*  return new FirefoxDriver(FirefoxDriverService.CreateDefaultService())
              {
                  Url = _configurationDriver.SeleniumBaseUrl

              } */
            FirefoxOptions firefoxOptions = new FirefoxOptions();
           // firefoxOptions.SetPreference("network.proxy.type", 1);
          //  firefoxOptions.SetPreference("network.proxy.socks", "127.0.0.1");
          //  firefoxOptions.SetPreference("network.proxy.socks_port", 9150);

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();

            IWebDriver driver = new FirefoxDriver(service, firefoxOptions);
            return driver;

        }
        private IWebDriver GetChromeDriver()
        {
            /* return new ChromeDriver(ChromeDriverService.CreateDefaultService(_testRunContext.TestDirectory))
             {
                 Url = _configurationDriver.SeleniumBaseUrl
             }; */

           // IWebDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath));

            // used specific chromedriver to be compatible with installled chrome 83
            IWebDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(@"/Users/amit/Desktop/amit/projects/specflow/SpecFlow.Plus.Examples-master/SpecFlowNetCore/MyTests.Tests/chromedriver83", "chromedriver"));
             EventFiringWebDriver eventDriver = new EventFiringWebDriver(driver);
             eventDriver.Navigated += new EventHandler<WebDriverNavigationEventArgs>(EventHandlers.OnNavigatedHandler);
             return eventDriver;
          //  return driver;
        }

       /*
        private IWebDriver GetInternetExplorerDriver()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,


            };

            return new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath), internetExplorerOptions)
            {
                Url = _configurationDriver.SeleniumBaseUrl,


            };
        }
        */

    }
}
