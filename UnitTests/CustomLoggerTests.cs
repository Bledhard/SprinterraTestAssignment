using Microsoft.VisualStudio.TestTools.UnitTesting;
using SprinterraTestAssignment.Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using SprinterraTestAssignment.Logger.Interfaces;
using SprinterraTestAssignment.Logger;
using SprinterraTestAssignment.Logger.Enumerators;

namespace SprinterraTestAssignment.UnitTests
{
    [TestClass]
    public class CustomLoggerTests
    {
        private Mock<ILogStorage> logStorageMock;
        private CustomLogger _logger;

        public CustomLoggerTests()
        {
            logStorageMock = new Mock<ILogStorage>();
            _logger = new CustomLogger(logStorageMock.Object);
        }

        [TestMethod]
        public void Log_MethodAddIsCalled()
        {
            // Arrange
            var testCustomLog = new CustomLog
            {
                LogLevel = CustomLogLevel.Info,
                Message = "test string - log message",
                DateTime = DateTime.Now
            };

            // Act
            _logger.Log(testCustomLog.Message, testCustomLog.LogLevel);

            // Assert
            logStorageMock.Verify(logStorage => logStorage.Add(It.IsAny<CustomLog>()), Times.Once);
        }
    }
}
