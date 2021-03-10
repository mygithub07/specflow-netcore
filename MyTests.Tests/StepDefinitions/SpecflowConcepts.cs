using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MyTests.Tests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Remote;
using MyTests.Tests.Drivers;


namespace MyTests.Tests.StepDefinitions
{

    [Binding]
    public class SpecflowConcepts
    
        
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MyTests.Tests.StepDefinitions.SpecflowConcepts));

        private readonly BrowserDriver _browserDriver;
        public readonly OpenQA.Selenium.IWebDriver driver;
        public DateTime datetime , d;
        public webelement element;
        public ObjectsToConvert obj;
        public webelement webelem;
        public RemoteWebDriver remoteDriver;

        public SpecflowConcepts(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
            driver = _browserDriver._driver;
           
        }

        [Given(@"the time now is ""(.*)""")]
        
 /*
        public void currentDatetime(DateTime dt)
        {
           // Console.WriteLine("current time: " + datetime);
            //Console.WriteLine("current date: " + datetime.Date);

            log.Info("from log4net current time: " + dt);
            log.Info("from log4net current date: " + dt.Date);
        }

*/

 /*       [StepArgumentTransformation]
        public DateTime convertToDatetime(string c)
        {
            datetime = DateTime.Now;
            return datetime;
        }
        */


        [Given(@"I verify fields")]

        public void convertToWebElement(ObjectsToConvert e)
        {

            Assert.IsNotNull(e.Field2);

        }

       /* [StepArgumentTransformation(@".*")]
        public ObjectsToConvert convert(Table input)
        {

            var row = input.Rows[0];
            return new ObjectsToConvert();
           

        } */

        [StepArgumentTransformation(@".*")]
        public IEnumerable<ObjectsToConvert> TransformIdentifiers(Table identifiers)
        {
            return identifiers.Rows.Select(row => new ObjectsToConvert
            {
               // Field = new webelement(),
                Field2 = new Uri(row["Field2"])

            }); 
        }
        /*
        public void convertToWebElement(Table table)
        {
            //IEnumerable<ObjectsToConvert> objects = table.CreateSet<ObjectsToConvert>();
            
            /*
            var  objects = table.CreateSet<ObjectsToConvert>();



            //  var objects = table.CreateInstance<MyTests.Tests.Helpers.ObjectsToConvert>();
            //  Assert.False(objects.Element.Enabled);

            using (var sequenceEnum = objects.GetEnumerator())
            {
                while (sequenceEnum.MoveNext())
                {
                    if (sequenceEnum.Current.Element == null)
                    {
                        log.Info("null..");
                    }
                    else
                    {
                        //Assert.False(sequenceEnum.Current.Element.Enabled);
                       Assert.AreEqual(sequenceEnum.Current.Element, "Gmail");
                    }
                }
            }
            */

        /*
            if (objects == null)
        {
            log.Info("null..");
        }
        else
        {
            foreach (ObjectsToConvert obj in objects)
            {
                Assert.False(obj.Element.Enabled);
            }
        }


    }  */

        [Given(@"we have ""(.*)""")]
        
       // [Given(@"we have '(.*)'")]

        public void webelements(Boolean b)
        {
            // log.Info("datetime"+ elem); 
            //elem = obj;
            // log.Info("field..." + o.Size);
            //Assert.False(o.Field.Displayed);
            // Assert.False(o.Enabled);
            Assert.False(b);

        }  


        [StepArgumentTransformation]
        public Boolean convertToWebElement(string c)
        {

            //d = DateTime.Now;
            // return d;
            // IConvertible convertible = c as IConvertible;
            var type = Type.GetType(c);
            //  IWebElement e = (IWebElement)Convert.ChangeType(c, typeof(IWebElement));
            RemoteWebElement e = (RemoteWebElement)Convert.ChangeType(type, typeof(RemoteWebElement));
           
            log.Info("value of e..");
            // return new ObjectsToConvert();
            // return new RemoteWebElement(remoteDriver,  "sometext");

            //   log.Info("obj.." + obj);
            //  return obj;
            return ExtensionMethods.webelementEnabledExtension(e);
        }



    }
}
