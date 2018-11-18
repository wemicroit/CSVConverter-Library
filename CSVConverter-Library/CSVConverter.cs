using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WeMicroIt.Utils.CSVConverter
{
    public class CSVConverter: ICSVConverter
    {
        public CSVConverter()
        {

        }

        private List<MemberInfo> Columns = new List<MemberInfo>();
        private char Deliminator = ',';
        private string NewLine = "\r\n";

        public bool SetOptions()
        {
            try
            {

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
                lines.Add(SerializeHeader(Data.FirstOrDefault()))
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
            Columns = MyType.GetMembers().ToList();
            return string.Join(Deliminator, Columns.Select(x => x.Name).ToList(), NewLine);
        }

        public String SerializeLine(Object Data)
        {
            string line = "";
            Type MyType = Type.GetType(nameof(Data));
            foreach (var item in Columns)
            {
                if (item.MemberType == MemberTypes.Property)
                {
                    string.Join(Deliminator, line, MyType.GetProperty(nameof(item)).Attributes.ToString());
                }
            }
            return string.Join(line.TrimStart(Deliminator), NewLine);
        }


    }
}
