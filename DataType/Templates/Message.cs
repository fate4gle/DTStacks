using System;
using UnityEngine;

namespace DTStacks.DataType.Templates
{
    [Serializable]
    public class Message
    {
        /// <summary>
        /// Overwrite the properties of the derived Message of type <c>DTStacks.DataType.Templates.Message</c>
        /// </summary>
        /// <param name="s">The JSON string</param>
        public void FeedDataFromJSON(string s)
        {
            JsonUtility.FromJsonOverwrite(s, this);
        }
        /// <summary>
        /// Generates a JSON-string based on the properties of the class derived from <c>DTStacks.DataType.Templates.Message</c>
        /// </summary>
        /// <returns name = "jsonString">The JSON-string containing all data in hierachical order</returns>
        public string CreateJSONFromData()
        {
            string jsonString = JsonUtility.ToJson(this);
            return jsonString;
        }
    }
}
