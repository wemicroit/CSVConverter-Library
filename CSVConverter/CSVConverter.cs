using Newtonsoft.Json;
using NotVisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using WeMicroIt.Utils.CSVConverter.Interfaces;
using WeMicroIt.Utils.CSVConverter.Models;

namespace WeMicroIt.Utils.CSVConverter
{
    public partial class CSVConverter: ICSVConverter
    {
        public CSVConverter()
        {

        }

        private List<MemberInfo> ColumnValues = new List<MemberInfo>();
        private List<string> Columns = new List<string>();
        private List<Fields> HeaderValues = new List<Fields>();
        private CSVSettings cSVSettings = new CSVSettings();

        public bool SetOptions(string options)
        {
            return options == null? SetAllOptions(null) : SetAllOptions(JsonConvert.DeserializeObject<CSVSettings>(options));
        }

        public bool SetOptions(CSVSettings options)
        {
            return SetAllOptions(options);
        }

        private bool SetAllOptions(CSVSettings options)
        {
            try
            {
                cSVSettings = options ?? throw new NullReferenceException(message: "Options Not Set.");
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        private string[] GetFields(string Data)
        {
            try
            {
                using (var csvReader = new StringReader(Data))
                {
                    using (var parser = new CsvTextFieldParser(csvReader))
                    {
                        parser.SetDelimiter(cSVSettings.Deliminator);
                        parser.TrimWhiteSpace = false;

                        return parser.ReadFields();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
