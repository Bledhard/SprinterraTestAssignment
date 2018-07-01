using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SprinterraTestAssignment.Logger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SprinterraTestAssignment.WebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using SprinterraTestAssignment.Logger.Interfaces;
using SprinterraTestAssignment.Logger;
using SprinterraTestAssignment.Logger.Enumerators;
using Microsoft.AspNetCore.Http;
using SprinterraTestAssignment.WebApplication.Models;

namespace SprinterraTestAssignment.UnitTests
{
    [TestClass]
    public class HomeControllerTests
    {
        private Mock<ICustomLogger> loggerMock;
        private HomeController controller;

        public HomeControllerTests()
        {
            loggerMock = new Mock<ICustomLogger>();
            controller = new HomeController(loggerMock.Object);
        }

        [TestMethod]
        public void Index_ReturnsView()
        {
            // Arrange

            // Act
            var result = controller.Index();

            // Asert
            Assert.IsInstanceOfType(result, typeof(IActionResult));
        }

        [TestMethod]
        public void Logger_NoSearchString_ReturnsView()
        {
            // Arrange

            // Act
            var result = controller.Logger();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IActionResult));
        }

        [TestMethod]
        public void Logger_NoSearchString_ReturnsViewWithAllMockedLogs()
        {
            // Arrange
            var mockedLogList = new List<CustomLog>
            {
                new CustomLog { LogLevel = CustomLogLevel.Info, Message = "Test without search string", DateTime = DateTime.Now },
                new CustomLog { LogLevel = CustomLogLevel.Warn, Message = "Test without search string", DateTime = DateTime.Now },
            };

            loggerMock
                .Setup(logger => logger.Get())
                .Returns(new Dictionary<string, List<CustomLog>>{ { "mockStorage", mockedLogList } });

            // Act
            var result = (ViewResult)controller.Logger();

            // Assert
            var logs = (Dictionary<string, List<CustomLog>>)result.ViewData["logs"];
            Assert.AreEqual(mockedLogList, logs["mockStorage"]);
        }

        [TestMethod]
        public void Logger_SearchStringInfo_ReturnsViewWithMockedInfoLogs()
        {
            // Arrange
            var mockedLogList = new List<CustomLog>
            {
                new CustomLog { LogLevel = CustomLogLevel.Info, Message = "Test with search string", DateTime = DateTime.Now },
                new CustomLog { LogLevel = CustomLogLevel.Warn, Message = "Test with search string", DateTime = DateTime.Now },
            };

            loggerMock
                .Setup(logger => logger.Get())
                .Returns(new Dictionary<string, List<CustomLog>> { { "mockStorage", mockedLogList } });

            // Act
            var result = (ViewResult)controller.Logger("Info");

            // Assert
            var logs = (Dictionary<string, List<CustomLog>>)result.ViewData["logs"];
            Assert.AreEqual(mockedLogList.Where(l => l.LogLevel == CustomLogLevel.Info).First(), logs["mockStorage"][0]);
        }
        
        [TestMethod]
        public void CalculateFigureArea_NonValidArea_ReturnsExpectedAnswer()
        {
            // Arrange
            var mockedFigurePointList = new List<FigurePoint>
            {
                new FigurePoint { X = 75, Y = 50 },
                new FigurePoint { X = 100, Y = 75 },
                new FigurePoint { X = 100, Y = 25 },
            };
            var expectedContentType = "application/json";
            var expectedAnswer = "{ \"isValidArea\":false, \"value\": \"6562.5 / 3750\"}";

            // Act
            var result = controller.CalculateFigureArea(mockedFigurePointList);

            // Assert
            Assert.AreEqual(expectedContentType, result.ContentType);
            Assert.AreEqual(expectedAnswer, result.Content);
        }
    }
}
