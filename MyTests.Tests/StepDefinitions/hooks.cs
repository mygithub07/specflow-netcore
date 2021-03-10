using System;
using BoDi;
using MyTests.Tests.Drivers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace MyTests.Tests.StepDefinitions
{
    [Binding]
    public class hooks

    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MyTests.Tests.StepDefinitions.hooks));
        private   IObjectContainer objectContainer;
        //  private static BrowserDriver browserDriver;
       
        public static  BrowserSeleniumDriverFactory bdf;
         public  static WebDriver wd;

        public BrowserSeleniumDriverFactory getBDF() {

           return new BrowserSeleniumDriverFactory();
        } 

        public hooks(IObjectContainer container)
        {
            objectContainer = container;

        }
        
       // [BeforeFeature]
        [BeforeScenario]
        public  void RunBeforeFeature()
        {
            System.Diagnostics.Debugger.Break();
            bdf = new BrowserSeleniumDriverFactory();
            wd = new WebDriver(bdf);
           //log.Info("WebDriver driver class: "+ wd);
             objectContainer.RegisterInstanceAs<WebDriver>(wd);
            //log.Info(objectContainer.IsRegistered())
        }
        
    }
}
