using System;
using System.Collections.Generic;
using System.Text;

namespace WeMicroIt.Utils.CSVConverter.Models
{
    /// <include file='./Docs/Models.xml' path='Doc/Model[@name="CSVSettings"]/CSVSettings/*' />
    public class CSVSettings
    {
        /// <include file='./Docs/Models.xml' path='Doc/Model[@name="CSVSettings"]/Deliminator/*' />
        public char Deliminator { get; set; }
        /// <include file='./Docs/Models.xml' path='Doc/Model[@name="CSVSettings"]/NewLine/*' />
        public string NewLine { get; set; }

        /// <include file='./Docs/Models.xml' path='Doc/Model[@name="CSVSettings"]/Constructor/*' />
        public CSVSettings()
        {
            Deliminator = ',';
            NewLine  = "\r\n";
        }
    }

}
