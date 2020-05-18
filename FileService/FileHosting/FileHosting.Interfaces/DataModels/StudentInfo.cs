using System;
using System.Runtime.Serialization;

namespace FileHosting.Interfaces.DataModels
{
    [DataContract]
    public class StudentInfo
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }
    }
}
