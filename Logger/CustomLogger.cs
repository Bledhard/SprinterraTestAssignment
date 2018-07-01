using SprinterraTestAssignment.Logger.Enumerators;
using SprinterraTestAssignment.Logger.Interfaces;
using System;
using System.Collections.Generic;

namespace SprinterraTestAssignment.Logger.Models
{
    public class CustomLogger : ICustomLogger
    {
        private List<ILogStorage> _logStorages;

        public CustomLogger(ILogStorage logStorage)
        {
            _logStorages = new List<ILogStorage>
            {
                logStorage
            };
        }
        public CustomLogger(List<ILogStorage> logStorages)
        {
            _logStorages = logStorages;
        }

        public List<ILogStorage> LogStorages
        {
            get => _logStorages;
            private set => _logStorages = value;
        }

        public Dictionary<string, List<CustomLog>> Get()
        {
            var logs = new Dictionary<string, List<CustomLog>>();
            LogStorages.ForEach(l => logs.Add(l.GetType().Name, l.Get()));
            return logs;
        }

        public List<ILogStorage> AddStorages(List<ILogStorage> logStorages)
        {
            var val = LogStorages;
            val.AddRange(logStorages);
            LogStorages = val;
            return val;
        }

        public void Log(string message, CustomLogLevel logLevel)
        {
            var log = new CustomLog
            {
                LogLevel = logLevel,
                Message = "test string - log message",
                DateTime = DateTime.Now
            };

            _logStorages.ForEach(ls => ls.Add(log));
        }


        public void Info(string message) =>
            Log(message, CustomLogLevel.Info);

        public void Warn(string message) =>
            Log(message, CustomLogLevel.Warn);

        public void Error(string message) =>
            Log(message, CustomLogLevel.Error);

        public void Debug(string message) =>
            Log(message, CustomLogLevel.Debug);

        public void Fatal(string message) =>
            Log(message, CustomLogLevel.Fatal);
    }
}
