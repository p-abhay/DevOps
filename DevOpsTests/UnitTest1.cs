using System;
using System.Collections.Generic;
using System.Linq;
using DevOps.Controllers; // Replace with your actual namespace
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace DevOps.Tests
{
    [TestFixture]
    public class WeatherForecastControllerTests
    {
        private WeatherForecastController _controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(loggerMock.Object);
        }

        [Test]
        public void Get_Returns_Correct_Data()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());

            foreach (var item in result)
            {
                Assert.IsInstanceOf<WeatherForecast>(item);
                Assert.IsNotNull(item.Date);
                Assert.IsTrue(item.TemperatureC >= -20 && item.TemperatureC <= 55);
                Assert.IsNotNull(item.Summary);
            }
        }
    }
}
