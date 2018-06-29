using SprinterraTestAssignment.Logger.Interfaces;
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

        public List<ILogStorage> AddStorages(List<ILogStorage> logStorages)
        {
            var val = LogStorages;
            val.AddRange(logStorages);
            LogStorages = val;
            return val;
        }

        public void Log(string message, string LogLevel) =>
            _logStorages.ForEach(ls => ls.Add(LogLevel + ": " + message));

        public void Info(string message) =>
            Log(message, "Info");

        public void Warn(string message) =>
            Log(message, "Warn");

        public void Error(string message) =>
            Log(message, "Error");

        public void Debug(string message) =>
            Log(message, "Debug");

        public void Fatal(string message) =>
            Log(message, "Fatal");
    }
}
