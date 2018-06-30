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
            _savePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\logs\\staLog.txt";
        }

        public string SavePath
        {
            get => _savePath;
            private set => _savePath = value;
        }

        public void Get()
        {
            using (var bs = new BufferedStream(new FileStream(SavePath, FileMode.Open, FileAccess.Read)))
            {
                byte[] ba = new byte[bs.Length];
                bs.Position = 0;
                bs.Read(ba, 0, (int)bs.Length);
                var logFile = ba.ToString();
            }
        }

        public void Add(string log)
        {
            using (var bs = new BufferedStream(new FileStream(SavePath, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                foreach (var c in log)
                {
                    bs.WriteByte((byte)c);
                }
            }
        }
    }
}
