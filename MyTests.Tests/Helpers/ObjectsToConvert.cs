using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace MyTests.Tests.Helpers
{

    public class ObjectsToConvert
    {

        public webelement Field { get; set; }
        public Uri Field2 { get; set; }


        // public string Element { get; set; }
        public ObjectsToConvert ()
        {
            Field = new webelement();

            }
    }
}
