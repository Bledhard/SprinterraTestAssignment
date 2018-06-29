﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SprinterraTestAssignment.Logger.Interfaces
{
    public interface ICustomLogger
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Debug(string message);
        void Fatal(string message);
    }
}
