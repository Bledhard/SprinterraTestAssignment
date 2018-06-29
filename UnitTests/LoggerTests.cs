using Microsoft.VisualStudio.TestTools.UnitTesting;
using SprinterraTestAssignment.Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SprinterraTestAssignment.UnitTests
{
    [TestClass]
    public class LoggerTests
    {
        private CustomLogger _logger;
        public LoggerTests()
        {
            _logger = new CustomLogger(new TxtLogStorage());
        }

        [TestMethod]
        public void Add_ValidString_Success()
        {
            // Arrange
            var logFilePath = _logger.LogStorages.First().SavePath;         
            var testString = "Testing Logger with TxtLogStorage";

            // Act
            _logger.Info(testString);
            string text = System.IO.File.ReadAllText(logFilePath);

            // Asert
            Assert.AreEqual("Info: " + testString, text);
        }
    }
}
