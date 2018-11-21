using System;
using System.Collections.Generic;
using System.Text;

namespace WeMicroIt.Utils.CSVConverter.Models
{
    public class CSVSettings
    {
        public char Deliminator { get; set; }
        public string NewLine { get; set; }

        public CSVSettings()
        {
            Deliminator = ',';
            NewLine  = "\r\n";
        }
    }

}
