using System;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace UrbanPiper
{
    [DataContract]
    public class JsonDataContractObject
    {
        public string ToJson()
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
            Stream s = new MemoryStream();
            ser.WriteObject(s, this);
            s.Position = 0;
            StreamReader sr = new StreamReader(s);
            return sr.ReadToEnd();
        }
    }
}
