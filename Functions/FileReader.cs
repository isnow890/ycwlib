using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ChanWooLib.Functions
{
    public static class FileReader
    {
        public static string Reader(string filepath)
        {
            return System.IO.File.ReadAllText(filepath);
        }
    }
}
