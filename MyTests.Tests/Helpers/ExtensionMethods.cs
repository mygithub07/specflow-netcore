using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace MyTests.Tests.Helpers
{
    public static class ExtensionMethods
    {
        public static Boolean webelementEnabledExtension(this RemoteWebElement element)
        {
            return element.Enabled;
        }

    }
}
