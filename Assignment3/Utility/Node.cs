using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Assignment3.Utility
{
    [DataContract]

    public class Node
    {
        [DataMember] 
        public User Data { get; set; }
        [DataMember] 
        public Node Next { get; set; }

        public Node(User data)
        {
            Data = data;
            Next = null;
        }
    }
}