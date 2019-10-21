using Castle.Core.Logging;
using DotNetCoreWebApi;
using DotNetCoreWebApi.Controllers;
using DotNetCoreWebApi.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DotNetCoreWebApiTests
{
    [TestClass]
    public class WeatherForecastControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            var mockRepo = new Mock<IRepo>();
            var controller = new WeatherForecastController(mockLogger.Object, mockRepo.Object);

            string getResponse = controller.Get();

            Assert.AreEqual(getResponse, "Welcome to DotNetTutorial");
        }
    }
}
