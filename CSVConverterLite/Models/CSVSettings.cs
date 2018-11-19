using System;
using System.Collections.Generic;
using System.Text;

namespace WeMicroIt.Utils.CSVConverterLite.Models
{
    public class CSVSettings
    {
        public char Deliminator { get; set; } = ',';
        public string NewLine { get; set; } = "\r\n";
    }
}
