using System;
using System.Collections.Generic;
using System.Text;

namespace WeMicroIt.Utils.CSVConverter.Models
{
    /// <include file='./Docs/Models.xml' path='Doc/Model[@name="Field"]/Field/*' />
    public class Fields
    {
        /// <include file='./Docs/Models.xml' path='Doc/Model[@name="Field"]/Name/*' />
        public string Name { get; set; }
        /// <include file='./Docs/Models.xml' path='Doc/Model[@name="Field"]/Type/*' />
        public Type Type { get; set; }
    }
}
