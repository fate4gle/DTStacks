using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTStacks.DataType.Services
{
    [Serializable]
    public class Header
    {
        public string type;
        public string date;
        public string time;
        public char delim ;
        public char headerDelim;

        public void FeedData(string headerData)
        {
            string[] s = headerData.Split(delim);
            type = s[0];
            date = s[1];
            time = s[2];
        }
        public string GetHeaderData()
        {
            string s = type + delim + date + delim + time;
            return s;
        }
    }

}
