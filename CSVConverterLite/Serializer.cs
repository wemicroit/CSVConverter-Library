using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using WeMicroIt.Utils.CSVConverter.Interfaces;

namespace WeMicroIt.Utils.CSVConverter
{
    public partial class CSVConverter : ICSVConverter
    {
        public List<string> SerializeBlock<T>(List<T> Data)
        {
            return SerializeBlock(Data, null);
        }

        public List<string> SerializeBlock(List<object> Data)
        {
            return SerializeBlock(Data, null);
        }

        public List<string> SerializeBlock(List<object> Data, string Header)
        {
            return SerializeBlock<object>(Data, Header);
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

        public List<string> SerializeLines(List<object> Data)
        {
            return SerializeLines<object>(Data);
        }

        public string SerializeHeader<T>(T Data)
        {
            try
            {
                if (Data == null)
                {
                    throw new NullReferenceException();
                }
                Type MyType = typeof(T);
                ColumnValues = MyType.GetMembers().ToList();
                if (ColumnValues == null || ColumnValues.Count < 1)
                {
                    return null;
                }
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
                return SerializeHeader<T>(Data);
            }
            else
            {
                return Header;
            }
        }

        public string SerializeHeader(object Data)
        {
            return SerializeHeader<object>(Data);
        }

        public string SerializeHeader(object Data, string Header)
        {
            try
            {
                if (Data == null)
                {
                    throw new NullReferenceException();
                }
                //to be worked out
                return null;

                //return string.Join(cSVSettings.Deliminator, ColumnValues.Select(x => x.Name).ToList(), cSVSettings.NewLine);
            }
            catch (Exception)
            {
                return null;
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

        public string SerializeLine(object Data)
        {
            return SerializeLine<object>(Data);
        }
    }
}
