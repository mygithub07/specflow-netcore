using System.Configuration;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using MyTests.Tests.Drivers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow.UnitTestProvider;
using MyTests.Tests.Helpers;
using BoDi;
using System;
using OpenQA.Selenium.Support.Events;

namespace MyTests.Tests.StepDefinitions
{
    [Binding]
    public  class Browser
    {

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MyTests.Tests.StepDefinitions.Browser));

        //private  static  BrowserDriver _browserDriver;

         public   OpenQA.Selenium.IWebDriver driver ;
       // public static dynamic driver;
        public  WebDriverWait wait;
        public static RemoteWebDriver rd;
           public   FeatureContext _featureContext;
        //   public dynamic dynamicDriver;
         public  ScenarioContext _scenarioContext;
        //    public ScenarioContext sc;
        //  public FeatureContext fc;
        //  public ContextInjection c;
       



        public   Browser(WebDriver webdriver, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            System.Diagnostics.Debugger.Break();
            //_browserDriver = browserDriver;
            // driver = browserDriver._driver;
            // wait = browserDriver._wait;
            driver = webdriver.Current;
            wait = webdriver.Wait;
           //_featureContext = featureContext;
            // System.Diagnostics.Debugger.Break();
            //    _featureContext.Add("driver", driver);
            // _featureContext.Add("testString", "test");
            
            _scenarioContext = scenarioContext;
           // _scenarioContext.Add("driver", driver);
        }



        [Given(@"I am on ""(.*)""")]
        public void goTo(string page)
        {
            // if this scenario is to be ignored then decorate scenario with  @ignore in feature file

            if (_scenarioContext.ScenarioInfo.Tags.ToString().Contains("ignore"))
            {
               var unitTestRuntimeProvider = (IUnitTestRuntimeProvider)
                _scenarioContext.GetBindingInstance((typeof(IUnitTestRuntimeProvider)));
                unitTestRuntimeProvider.TestIgnore("ignored");
            }
            

                else
           {

                //initiate 
                System.Diagnostics.Debugger.Break();
                driver.Navigate().GoToUrl(page);

                }
        }

        [Then(@"browser title should be '(.*)'")]
        public void ThenBrowserTitleIs(string expectedTitle)
        {
            System.Diagnostics.Debugger.Break();
            driver.Title.Should().Equals(expectedTitle);
        }


       //  [Given(@"we have ""(.*)""")]

         [Given(@"we have '(.*)'")] 

        public void webelements(ChromeWebElement o)
        {
        //    System.Diagnostics.Debugger.Break();
            Assert.False(o.Displayed);
        }

        [StepArgumentTransformation]
          public ChromeWebElement convertToWebElement(string c)
          {
            System.Diagnostics.Debugger.Break();

            // ChromeDriver parent = fc.Get<ChromeDriver>("driver");
            // return new ChromeWebElement(parent, c);
            log.Info("driver type:"+ driver.GetType());
           // ChromeDriver intermittentDriver = driver;
          //  IWebDriver intermittentDriver = (IWebDriver)Convert.ChangeType(driver, typeof(IWebDriver));
            
            //log.Info("driver type after cast:" + intermittentDriver.GetType());
            //  log.Info("intermittentDriver type:" + intermittentDriver.GetType());
             // ChromeDriver parent = (ChromeDriver)driver;   
            // ChromeDriver parent = (ChromeDriver)Convert.ChangeType(driver, typeof(ChromeDriver));

            ChromeDriver parent = driver as  ChromeDriver;
            //ChromeDriver parent = (ChromeDriver)driver;

            log.Info("parent type:" + parent.GetType());
             return new ChromeWebElement(parent, c);
           //return new ChromeWebElement(driver, c);
        }


        [Given(@"I have ""(.*)""")]

        public void testBindingInstance( string s)
        {
            System.Diagnostics.Debugger.Break();
            log.Info("string passed:"+ s);
        }

        [Given(@"I am on ""(.*)"" on firefox")]
        public void firefoxTest(string page)
        {
            if (_scenarioContext.ScenarioInfo.Tags.ToString().Contains("ignore"))
            {
                var unitTestRuntimeProvider = (IUnitTestRuntimeProvider)
                 _scenarioContext.GetBindingInstance((typeof(IUnitTestRuntimeProvider)));
                unitTestRuntimeProvider.TestIgnore("ignored");
            }


            else
            {
                //initiate 
                System.Diagnostics.Debugger.Break();
                driver.Navigate().GoToUrl(page);
            }
        }

        [Given(@"a string with quotes in doc string and ""(.*)"" as general parameter")]

        public void docStringTest(string st, string docString) {
            log.Info("string is:  " + st);
            log.Info("doc string is:  " + docString);
        }

        [Given(@"a string with quotes in doc string")]

        public void docStringOnlyTest(string docString)
        {
            
            log.Info("doc string is:  " + docString);
        }
    }
}
