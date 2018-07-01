using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprinterraTestAssignment.Logger.Interfaces;

namespace SprinterraTestAssignment.Logger.Models
{
    public class TxtLogStorage : ILogStorage
    {        
        private string _savePath;

        public TxtLogStorage()
        {
            var fullPath = @"D:\SprinterraTestAssignment_logs\";
            Directory.CreateDirectory(fullPath);
            _savePath = fullPath + "\\staLog.txt";
        }

        public string SavePath
        {
            get => _savePath;
            private set => _savePath = value;
        }

        public List<CustomLog> Get()
        {
            using (var bs = new BufferedStream(new FileStream(SavePath, FileMode.Open, FileAccess.Read)))
            using (StreamReader streamReader = new StreamReader(bs))
            {
                var logFile = streamReader.ReadToEnd();
                var logs = new List<CustomLog>();
                var list = logFile
                    .Split('\n').ToList();
                list.RemoveAll(s => s == "");
                list.ForEach(s => logs.Add((CustomLog)s));
                return logs;
            }
        }

        public void Add(CustomLog log)
        {
            using (var bs = new BufferedStream(new FileStream(SavePath, FileMode.Append, FileAccess.Write)))
            using (StreamWriter writer = new StreamWriter(bs))
            {
                    writer.WriteLine(log.ToString());
            }
        }
    }
}
