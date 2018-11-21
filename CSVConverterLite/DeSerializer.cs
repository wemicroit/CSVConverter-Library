﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using WeMicroIt.Utils.CSVConverter.Interfaces;

namespace WeMicroIt.Utils.CSVConverter
{
    public partial class CSVConverter : ICSVConverter
    {
        public List<object> DeSerializeBlock(string Data)
        {
            return DeSerializeBlock(Data, false);
        }

        public List<T> DeSerializeBlock<T>(string Data)
        {
            return DeSerializeBlock<T>(Data, false);
        }

        public List<object> DeSerializeBlock(string Data, bool Headers)
        {
            if (Data == null)
            {
                return null;
            }
            return DeSerializeLines(Data.Split(cSVSettings.NewLine).ToList(), Headers);
        }

        public List<T> DeSerializeBlock<T>(string Data, bool Headers)
        {
            return DeSerializeLines<T>(Data.Split(cSVSettings.NewLine).ToList(), Headers);
        }

        public List<object> DeSerializeLines(List<string> Data)
        {
            return DeSerializeLines<object>(Data);
        }

        public List<T> DeSerializeLines<T>(List<string> Data)
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
                    Parsed.Add(DeSerializeLine<T>(item));
                }
                return Parsed;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<object> DeSerializeLines(List<string> Data, bool Headers)
        {
            return DeSerializeLines<object>(Data, Headers);
        }

        public List<T> DeSerializeLines<T>(List<string> Data, bool Headers)
        {
            if (Headers)
            {
                Data.RemoveAt(0);
            }
            return DeSerializeLines<T>(Data);
        }

        public object DeSerializeLine(string Data)
        {
            var result = DeSerializeLine<object>(Data);
            return result == default(object) ? null : result;
        }

        public T DeSerializeLine<T>(string Data)
        {
            try
            {
                if (string.IsNullOrEmpty(Data))
                {
                    throw new NullReferenceException();
                }
                dynamic line = new ExpandoObject();
                string[] con = GetFields(Data);
                if (con.Length < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                /*if (HeaderValues.Count < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }*/
                int i = 0;
                while (i < HeaderValues.Count && i < con.Length)
                {
                    line./*HeaderValues[*/i/*]*/ = con[i];
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
    }
}
