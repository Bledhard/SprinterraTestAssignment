using System.Collections.Generic;

namespace SprinterraTestAssignment.Logger.Interfaces
{
    public interface ILogStorage
    {
        string SavePath { get; }
        List<CustomLog> Get();
        void Add(CustomLog log);
    }
}
