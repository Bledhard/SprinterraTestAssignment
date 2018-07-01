using SprinterraTestAssignment.Logger.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace SprinterraTestAssignment.Logger
{
    public class CustomLog
    {
        public CustomLogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public static explicit operator CustomLog(string logString)
        {
            var pattern = @"((: )|( \()|(\).))";
            var regex = new Regex(pattern);
            var properties = Regex.Split(logString, pattern);
            var list = new List<string>(properties);
            list.RemoveAll(s => regex.IsMatch(s));
            DateTime.TryParse(list[2], out DateTime temp);

            var log = new CustomLog
            {
                LogLevel = (CustomLogLevel)Enum.Parse(typeof(CustomLogLevel), list[0]),
                Message = list[1],
                DateTime = temp
            };

            return log;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1} ({2}).", LogLevel.ToString(), Message, DateTime.ToString());
        }
    }
}
