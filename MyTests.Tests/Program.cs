using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Logging;

namespace MyTests.Tests
{
    public class Program
    {
        //for log4net config load log4net.config file in assembly.info

        // for adding assembly.info , add this to csproj <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
        //to avoid duplicate assembly.info , as .net core automatically generates assembly.info, which is not visible in sol explorer


        private static readonly ILog log = LogManager.GetLogger(typeof(MyTests.Tests.Program));

        //if we are adding a main method and Program.cs, we should add <GenerateProgramFile>false</GenerateProgramFile> in csproj
        // to avoid generating double entry point

        public static void Main  (string[] args   )

        {
           
            Console.WriteLine("*********Program started*******");
          
            log.Info("********fromlog4net*****");
        }
    }
}
