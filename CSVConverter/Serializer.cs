using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
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
                List<string> lines = new List<string>
                {
                    SerializeHeader<T>(Data.FirstOrDefault(), Header)
                };
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
                if (typeof(T) == typeof(object))
                {
                    var tTarget = Data as IDynamicMetaObjectProvider;

                    if (tTarget != null)
                    {
                        columns = tTarget.GetMetaObject(Expression.Constant(tTarget)).GetDynamicMemberNames().ToList();
                        if (columns == null || columns.Count < 1)
                        {
                            return null;
                        }
                    }
                    else
                    {
                        /*if (ComObjectType != null && ComObjectType.IsInstanceOfType(Data) && ComBinder.IsAvailable)

                        {
                            tList.AddRange(ComBinder.GetDynamicDataMemberNames(target));
                        }*/
                    }
                    return string.Join(settings.Deliminator, columns.ToArray());
                }
                else
                {
                    Type myType = typeof(T);
                    columnValues = myType.GetMembers().Where(x => x.MemberType == MemberTypes.Property).ToList();
                    if (columnValues == null || columnValues.Count < 1)
                    {
                        return null;
                    }
                    return string.Join(settings.Deliminator, columnValues.Select(x => x.Name).ToArray());
                }
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
                return SerializeHeader<object>(Data, Header);
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
                Type mytype = Type.GetType(nameof(Data));
                if ((columnValues == null || columnValues.Count < 1) && (columns == null || columns.Count < 1))
                {
                    SerializeHeader<T>(Data);
                }
                if (columnValues != null && columnValues.Count > 0)
                {
                    foreach (var item in columnValues)
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            line = mytype.GetProperty(nameof(item)).Attributes.ToString();
                        }
                        else
                        {
                            line = string.Join(settings.Deliminator, line);
                        }
                    }
                }
                else if (columns != null && columns.Count > 0)
                {
                    dynamic obj = Data;
                    foreach (var item in columns)
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            line = obj[item];
                        }
                        else
                        {
                            line = string.Join(settings.Deliminator, line, obj[item]);
                        }
                    }
                }

                return line;
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
