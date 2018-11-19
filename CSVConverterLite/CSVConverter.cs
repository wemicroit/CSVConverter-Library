using NotVisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using WeMicroIt.Utils.CSVConverterLite.Interfaces;
using WeMicroIt.Utils.CSVConverterLite.Models;

namespace WeMicroIt.Utils.CSVConverterLite
{
    public class FieldInfo
    {
        public string Name { get; set; }
        public Type Type { get; set; }
    }

    public class CSVConverter: ICSVConverter
    {
        public CSVConverter()
        {

        }

        private List<MemberInfo> ColumnValues = new List<MemberInfo>();
        private List<FieldInfo> HeaderValues = new List<FieldInfo>();
        private CSVSettings cSVSettings = new CSVSettings();

        public bool SetOptions(CSVSettings options)
        {
            try {
                cSVSettings = options;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<String> SerializeBlock<T>(List<T> Data)
        {
            return SerializeBlock(Data, null);
        }

        public List<String> SerializeBlock<T>(List<T> Data, string Header)
        {
            List<string> lines = new List<string>();
            if (Header == null)
            {
                lines.Add(SerializeHeader(Data.FirstOrDefault()));
            }
            else
            {
                lines.Add(Header);
            }
            foreach (var item in Data)
            {
                lines.Add(SerializeLine(item));
            }
            return lines;
        }

        public List<String> SerializeLines<T>(List<T> Data)
        {
            List<string> lines = new List<string>();
            foreach (var item in Data)
            {
                lines.Add(SerializeLine(item));
            }
            return lines;
        }

        public String SerializeHeader<T>(T Data)
        {
            Type MyType = Type.GetType(nameof(Data));
            ColumnValues = MyType.GetMembers().ToList();
            return string.Join(cSVSettings.Deliminator, ColumnValues.Select(x => x.Name).ToList(), cSVSettings.NewLine);
        }

        public String SerializeLine<T>(T Data)
        {
            string line = "";
            Type MyType = Type.GetType(nameof(Data));
            foreach (var item in ColumnValues)
            {
                if (item.MemberType == MemberTypes.Property)
                {
                    string.Join(cSVSettings.Deliminator, line, MyType.GetProperty(nameof(item)).Attributes.ToString());
                }
            }
            return string.Join(line.TrimStart(cSVSettings.Deliminator), cSVSettings.NewLine);
        }



        public List<T> DeserialiseBlock<T>(string Data)
        {
            return DeserialiseBlock<T>(Data, false);
        }

        public List<T> DeserialiseBlock<T>(string Data, bool Headers)
        {
            return DeserialiseLines<T>(Data.Split(cSVSettings.NewLine).ToList(), Headers);
        }

        public List<T> DeserialiseLines<T>(List<string> Data)
        {
            List<T> Parsed = new List<T>();
            foreach (var item in Data)
            {
                Parsed.Add(DeserialiseLine<T>(item));
            }
            return Parsed;
        }

        public List<T> DeserialiseLines<T>(List<string> Data, bool Headers)
        {
            if (Headers)
            {
                Data.RemoveAt(0);
            }
            return DeserialiseLines<T>(Data);
        }

        public T DeserialiseLine<T>(string Data)
        {
            dynamic line = new ExpandoObject();
            string[] con = GetFields(Data);
            int i = 0;
            while (i <HeaderValues.Count && i < con.Length)
            {
                line.HeaderValues[i] = con[i];
                i++;
            }
            while (i < HeaderValues.Count)
            {
                line.HeaderValues[i] = null;
                i++;
            }
            return line;
        }

        private string[] GetFields(string Data)
        {
            using (var csvReader = new StringReader(Data))
            using (var parser = new CsvTextFieldParser(csvReader))
            {
                parser.SetDelimiter(cSVSettings.Deliminator);
                parser.TrimWhiteSpace = false;

                return parser.ReadFields();
            }

        }
    }
}
