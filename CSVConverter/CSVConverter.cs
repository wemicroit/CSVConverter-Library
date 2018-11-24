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
        private List<MemberInfo> ColumnValues { get; set; }
        private List<string> Columns { get; set; }
        private List<Fields> HeaderValues { get; set; }
        public CSVSettings settings { get; set; }

        public CSVConverter()
        {
            settings = new CSVSettings();
            HeaderValues = new List<Fields>();
            Columns = new List<string>();
            ColumnValues = new List<MemberInfo>();
        }

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
                settings = options ?? throw new NullReferenceException(message: "Options Not Set.");
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
                        parser.SetDelimiter(settings.Deliminator);
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
