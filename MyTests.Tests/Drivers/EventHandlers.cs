using System;
using OpenQA.Selenium.Support.Events;

namespace MyTests.Tests.Drivers
{
    public static class EventHandlers
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MyTests.Tests.Drivers.EventHandlers));

        public static void OnNavigatedHandler(object sender, WebDriverNavigationEventArgs e)
        {
            log.Info("navigated to "+ e.Url);
        }

        public  static void OnElementClicked(object sender, WebElementEventArgs e)
        {
            log.Info("clicked element"+ e.Element.Text);
        }

        //add more
    }
}
