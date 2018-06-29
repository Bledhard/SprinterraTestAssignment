using System;
using System.Collections.Generic;
using System.Text;

namespace SprinterraTestAssignment.Logger.Interfaces
{
    public interface ILogStorage
    {
        string SavePath { get; }
        void Get();
        void Add(string log);
    }
}
