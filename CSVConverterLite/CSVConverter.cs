using NotVisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using WeMicroIt.Utils.CSVConverter.Interfaces;
using WeMicroIt.Utils.CSVConverter.Models;

namespace WeMicroIt.Utils.CSVConverter
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

        public List<string> SerializeBlock<T>(List<T> Data)
        {
            return SerializeBlock(Data, null);
        }

        public List<string> SerializeBlock<T>(List<T> Data, string Header)
        {
            try
            {
                if (Data == null)
                {
                    throw new NullReferenceException();
                }
                List<string> lines = new List<string>();
                lines.Add(SerializeHeader<T>(Data.FirstOrDefault(), Header));
                lines.AddRange(SerializeLines<T>(Data));
                return lines;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> SerializeLines<T>(List<T> Data)
        {
            try
            {
                if (Data == null)
                {
                    throw new NullReferenceException();
                }
                List<string> lines = new List<string>();
                foreach (var item in Data)
                {
                    lines.Add(SerializeLine(item));
                }
                return lines;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string SerializeHeader<T>(T Data)
        {
            try
            {
                if (Data == null)
                {
                    throw new NullReferenceException();
                }
                Type MyType = Type.GetType(nameof(Data));
                ColumnValues = MyType.GetMembers().ToList();
                return string.Join(cSVSettings.Deliminator, ColumnValues.Select(x => x.Name).ToList(), cSVSettings.NewLine);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string SerializeHeader<T>(T Data, string Header)
        {   
            if (string.IsNullOrEmpty(Header))
            {
                return SerializeHeader(Data);
            }
            else
            {
                return Header;
            }
        }

        public string SerializeLine<T>(T Data)
        {
            try
            {
                if (Data == null)
                {
                    throw new NullReferenceException();
                }
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
            catch (Exception)
            {
                return null;
            }
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
            try
            {
                if (Data == null)
                {
                    throw new NullReferenceException();
                }
                List<T> Parsed = new List<T>();
                foreach (var item in Data)
                {
                    Parsed.Add(DeserialiseLine<T>(item));
                }
                return Parsed;
            }
            catch (Exception)
            {
                return null;
            }
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
            try
            {
                if (string.IsNullOrEmpty(Data))
                {
                    throw new NullReferenceException();
                }
                if (HeaderValues.Count < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                dynamic line = new ExpandoObject();
                string[] con = GetFields(Data);
                if (con.Length < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                int i = 0;
                while (i < HeaderValues.Count && i < con.Length)
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
            catch (Exception)
            {
                return default(T);
            }
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
