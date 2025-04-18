using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            var knownTypes = new List<Type> { typeof(SLL), typeof(Node), typeof(User) };
            DataContractSerializer serializer = new DataContractSerializer(typeof(ILinkedListADT), knownTypes);

            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            var knownTypes = new List<Type> { typeof(SLL), typeof(Node), typeof(User) };
            DataContractSerializer serializer = new DataContractSerializer(typeof(ILinkedListADT), knownTypes);

            using (FileStream stream = File.OpenRead(fileName))
            {
                return (ILinkedListADT)serializer.ReadObject(stream);
            }
        }
    }
}
