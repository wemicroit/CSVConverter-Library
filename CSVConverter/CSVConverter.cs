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
        private List<MemberInfo> columnValues;
        private List<string> columns;
        private List<Fields> headerValues;
        private CSVSettings settings { get; set; }

        public CSVConverter()
        {
            settings = new CSVSettings();
            headerValues = new List<Fields>();
            columns = new List<string>();
            columnValues = new List<MemberInfo>();
        }

        public bool SetOptions(string options)
        {
            return options == null? setAllOptions(null) : setAllOptions(JsonConvert.DeserializeObject<CSVSettings>(options));
        }

        public bool SetOptions(CSVSettings options)
        {
            return setAllOptions(options);
        }

        private bool setAllOptions(CSVSettings options)
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

        private string[] getFields(string data)
        {
            try
            {
                using (var csvReader = new StringReader(data))
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
