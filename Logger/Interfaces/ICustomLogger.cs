using System;
using System.Collections.Generic;
using System.Text;

namespace SprinterraTestAssignment.Logger.Interfaces
{
    public interface ICustomLogger
    {
        List<ILogStorage> LogStorages { get; }

        Dictionary<string, List<CustomLog>> Get();
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Debug(string message);
        void Fatal(string message);
    }
}
