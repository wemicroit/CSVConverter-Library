using NotVisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using WeMicroIt.Utils.CSVConverterLite.Interfaces;

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
        private char Deliminator = ',';
        private string NewLine = "\r\n";

        public bool SetOptions()
        {
            try { 
            
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<String> SerializeBlock(List<Object> Data)
        {
            return SerializeBlock(Data, false);
        }

        public List<String> SerializeBlock(List<Object> Data, bool Headers)
        {
            List<string> lines = new List<string>();
            if (Headers)
            {
                lines.Add(Data.FirstOrDefault().ToString());
                Data.RemoveAt(0);
            }
            else
            {
                lines.Add(SerializeHeader(Data.FirstOrDefault()));
            }
            foreach (var item in Data)
            {
                lines.Add(SerializeLine(item));
            }
            return lines;
        }

	    public String SerializeHeader(Object Data)
        {
            Type MyType = Type.GetType(nameof(Data));
            ColumnValues = MyType.GetMembers().ToList();
            return string.Join(Deliminator, ColumnValues.Select(x => x.Name).ToList(), NewLine);
        }

        public String SerializeLine(Object Data)
        {
            string line = "";
            Type MyType = Type.GetType(nameof(Data));
            foreach (var item in ColumnValues)
            {
                if (item.MemberType == MemberTypes.Property)
                {
                    string.Join(Deliminator, line, MyType.GetProperty(nameof(item)).Attributes.ToString());
                }
            }
            return string.Join(line.TrimStart(Deliminator), NewLine);
        }








        public List<Object> DeserialiseBlock(string Data)
        {
            return DeserialiseBlock(Data, false);
        }

        public List<Object> DeserialiseBlock(string Data, bool Headers)
        {
            return DeserialiseLines(Data.Split(NewLine).ToList(), Headers);
        }

        public List<Object> DeserialiseLines(List<String> Data)
        {
            if (HeaderValues.Count< 1)
            {
                int i = 0;
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    HeaderValues.Add(new FieldInfo() { Name = c.ToString(), Type = typeof(string) });
                    i++;
                    if (i >= GetFields(Data.FirstOrDefault()).Length)
                    {
                        break;
                    }
                }
            }
            List<object> list = new List<object>();
            foreach (var item in Data)
            {
                list.Add(DeserialiseLine(item));
            }
            return list;
        }

        public List<Object> DeserialiseLines(List<String> Data, bool Headers)
        {
            List<Object> list = new List<object>();
            if (Headers)
            {
                DeserialiseHeader(Data.FirstOrDefault());
                Data.RemoveAt(0);
            }
            return DeserialiseLines(Data);
        }

        public Object DeserialiseHeader(string Data)
        {

            var cells = Data.Split(Deliminator).ToList();
            dynamic sampleObject = new ExpandoObject();
            foreach (var item in GetFields(Data))
            {
                sampleObject.item = "";
                HeaderValues.Add(new FieldInfo { Name = item});
            }
            return sampleObject;
        }

        public Object DeserialiseLine(string Data)
        {
            var cells = Data.Split(Deliminator).ToList();
            dynamic sampleObject = new ExpandoObject();
            for (int i = 0; i < Data.Split(Deliminator).Count(); i++)
            {
                sampleObject.HeaderValues[i].Name = Data[i];
            }
            return sampleObject;
        }



        public List<T> DeserialiseBlock<T>(string Data)
        {
            return DeserialiseBlock<T>(Data, false);
        }

        public List<T> DeserialiseBlock<T>(string Data, bool Headers)
        {
            return DeserialiseLines<T>(Data.Split(NewLine).ToList(), Headers);
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
                parser.SetDelimiter(Deliminator);
                parser.TrimWhiteSpace = false;

                return parser.ReadFields();
            }

        }
    }
}
