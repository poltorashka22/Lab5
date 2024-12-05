using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Log
    {
        private string _logFileName;
        private bool _add;

        public Log(string logFileName, bool add)
        {
            _logFileName = logFileName;
            _add = add;

            if (!_add)
            {
                File.WriteAllText(_logFileName, string.Empty);
            }
        }


        public void Write(string message)
        {
            if (_add)
            {
                File.AppendAllText(_logFileName, message + "\n");
            }
            else
            {
                File.WriteAllText(_logFileName, message + "\n");
                _add = true;
            }
        }
    }
}

