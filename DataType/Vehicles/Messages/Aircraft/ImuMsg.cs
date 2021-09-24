using DTStacks.DataType.Services;
using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Vehicles.Airplane.Messages
{
    [System.Serializable]
    public class IMUData : Message
    {
        public Header header;
        public float Roll;
        public float Pitch;
        public float Yaw;

        public float q1;
        public float q2;
        public float q3;
        public float q4;

        private char delim;

        public void FeedDataFromString(string data, char _delim)
        {
            string[] s = data.Split(header.headerDelim);
            string[] sd;
            if (s.Length > 1)
            {
                header.FeedData(s[0]);
                sd = s[1].Split(_delim);
            }
            else
            {
                sd = s[0].Split(_delim);
            }
            try
            {
                Roll = float.Parse(s[0]);
                Pitch = float.Parse(s[1]);
                Yaw = float.Parse(s[2]);


                q1 = float.Parse(s[3]);
                q2 = float.Parse(s[4]);
                q3 = float.Parse(s[5]);
                q4 = float.Parse(s[6]);

            }
            catch { }
        }

        public void FeedDataFromString(string data)
        {
            string[] s = data.Split(header.headerDelim);
            string[] sd;
            if (s.Length > 1)
            {
                header.FeedData(s[0]);
                sd = s[1].Split(delim);
            }
            else
            {
                sd = s[0].Split(delim);
            }
            try
            {
                Roll = float.Parse(sd[0]);
                Pitch = float.Parse(sd[1]);
                Yaw = float.Parse(sd[2]);

                q1 = float.Parse(sd[3]);
                q2 = float.Parse(sd[4]);
                q3 = float.Parse(sd[5]);
                q4 = float.Parse(sd[6]);

            }
            catch { }
        }
        public string MakeDataPackage()
        {
            string s;
            if (header.type != null)
            {
                s = header.type + delim +
                    header.date + delim +
                    header.time + header.headerDelim +
                    Roll.ToString() + delim +
                    Pitch.ToString() + delim +
                    Yaw.ToString() + delim +
                    q1.ToString() + delim +
                    q2.ToString() + delim +
                    q3.ToString() + delim +
                    q4.ToString();
            }
            else
            {
                s = Roll.ToString() + delim +
                    Pitch.ToString() + delim +
                    Yaw.ToString() + delim +
                    q1.ToString() + delim +
                    q2.ToString() + delim +
                    q3.ToString() + delim +
                    q4.ToString();
            }
            return s;
        }
    }
}
