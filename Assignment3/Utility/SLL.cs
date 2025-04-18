using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using Assignment3.Utility;

namespace Assignment3
{

    [DataContract]
    [KnownType(typeof(Node))]
    [KnownType(typeof(User))]
    public class SLL : ILinkedListADT
    {
        [DataMember] 
        private Node head;
        [DataMember] 
        private int size;

        public SLL()
        {
            head = null;
            size = 0;
        }

        public bool IsEmpty() => size == 0;

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public void AddLast(User value)
        {
            Utility.Node newNode = new Utility.Node(value);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                Utility.Node current = head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = newNode;
            }
            size++;
        }

        public void AddFirst(User value)
        {
            Utility.Node newNode = new Utility.Node(value);
            newNode.Next = head;
            head = newNode;
            size++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
                throw new IndexOutOfRangeException();
            if (index == 0) { AddFirst(value); return; }
            if (index == size) { AddLast(value); return; }

            Utility.Node newNode = new Utility.Node(value);
            Utility.Node current = head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;
            newNode.Next = current.Next;
            current.Next = newNode;
            size++;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            Utility.Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            current.Data = value;
        }

        public int Count() => size;

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot remove from empty list.");
            head = head.Next;
            size--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot remove from empty list.");
            if (size == 1)
            {
                head = null;
            }
            else
            {
                Utility.Node current = head;
                while (current.Next.Next != null)
                    current = current.Next;
                current.Next = null;
            }
            size--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            if (index == 0) { RemoveFirst(); return; }
            if (index == size - 1) { RemoveLast(); return; }

            Utility.Node current = head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;
            current.Next = current.Next.Next;
            size--;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            Utility.Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            return current.Data;
        }

        public int IndexOf(User value)
        {
            Utility.Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(User value) => IndexOf(value) != -1;

        public void Reverse()
        {
            Utility.Node prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }
    }
}
