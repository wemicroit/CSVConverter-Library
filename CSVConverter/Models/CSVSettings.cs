using System;
using System.Collections.Generic;
using System.Text;

namespace WeMicroIt.Utils.CSVConverter.Models
{
    /// <include file='./Docs/Models.xml' path='Doc/Model[@name="CSVSettings"]/CSVSettings/*' />
    public class CSVSettings
    {
        private char deliminator;
        private string newLine;

        /// <include file='./Docs/Models.xml' path='Doc/Model[@name="CSVSettings"]/Constructor/*' />
        public CSVSettings()
        {
            deliminator = ',';
            newLine  = "\r\n";
        }

        /// <include file='./Docs/Models.xml' path='Doc/Model[@name="CSVSettings"]/Deliminator/*' />
        public char Deliminator
        {
            get
            {
                return deliminator;
            }
            set
            {
                deliminator = value;
            }
        }

        /// <include file='./Docs/Models.xml' path='Doc/Model[@name="CSVSettings"]/NewLine/*' />
        public string NewLine
        {
            get
            {
                return newLine;
            }
            set
            {
                newLine = value;
            }
        }
    }

}
