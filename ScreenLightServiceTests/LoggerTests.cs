using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenLightService.Classes;
using System.IO;

namespace ScreenLightServiceTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void LogTest_LogAppException_FileWithException()
        {
            var exceptionString = "test exception";
            var ex = new Exception(exceptionString);

            Logger.Log(ex);

            Assert.AreEqual(true, File.Exists("log.log"));
            using (var sr = new StreamReader("log.log"))
            {
                var readed = sr.ReadToEnd();
                Assert.AreEqual(true, readed.Contains(exceptionString));
            }
        }

        [TestMethod]
        public void LogTest_LogString_FileWithException()
        {
            var exceptionString = "test exception";
            
            Logger.Log(exceptionString);
            
            Assert.AreEqual(true, File.Exists("log.log"));
            using (var sr = new StreamReader("log.log"))
            {
                var readed = sr.ReadToEnd();
                Assert.AreEqual(true, readed.Contains(exceptionString));
            }
        }
    }
}
