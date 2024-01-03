using System;
using System.Collections.Generic;
using System.Linq;


namespace GenericCollection
{
    /// <summary>
    /// This program demonstrates the use of generic collections in C#.
    /// It includes examples for List, Dictionary, Stack, and Queue.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region List
            // Create a list.
            List<int> lst = new List<int>();
            #region Adding
            // Add some values to the list.
            lst.Add(99);
            lst.Add(2309);
            lst.Add(15);
            lst.Add(29);
           
            //display elements of the list
            foreach (int i in lst)
            {
                Console.WriteLine(i);
            }
            #endregion Adding

            #region Contain
            //Constains() method Determines whether an element is in the List or not
            if (lst.Contains(2040))
            {
                Console.WriteLine("\nelement found \n");
            }
            else
            {
                Console.WriteLine("\nelement not found \n");
            }
            #endregion Contain

            #region Sorting
            //Sort() method Sorts the elements in the entire List
            lst.Sort();
            Console.WriteLine("Sorted Array");
            foreach (int i in lst)
            {
                Console.WriteLine(i);
            }
            #endregion Sorting

            #region SearchingIndex
            //searching method
            int index = lst.BinarySearch(99);

            if (index > 0)
            {
                Console.WriteLine("\nElement found at position {0}", index);
            }
            else
            {
                Console.WriteLine("\nElement not found");
            }
            #endregion SearchingIndex

            #region Remove Range
            //Removes a range of elements from the List
            Console.WriteLine("\nRemoveRange(2, 2)");
            lst.RemoveRange(2, 2);

            Console.WriteLine();
            foreach (int mylst in lst)
            {
                Console.WriteLine(mylst);
            }
            #endregion Remove Range

            #region Remove Last
            Console.WriteLine("Remove Last");
            lst.RemoveAt(lst.Count - 1);
            Console.WriteLine();
            foreach (int mylst in lst)
            {
                Console.WriteLine(mylst);
            }
            #endregion Remove Last

            #region Remove All
            //Removes all elements from the List.
            lst.Clear();
            Console.WriteLine("\nAfter clearing the list");
            foreach (int mylst in lst)
            {
                Console.WriteLine(mylst);
            }
            #endregion Remove All
            #endregion List

            #region Dictionary
            // Create a new dictionary of strings, with string keys.
            Dictionary<string, string> dct = new Dictionary<string, string>();
            #region Adding
            // Add some elements to the dictionary.
            dct.Add("cs", "cs.net");
            dct.Add("vb", "vb.net");
            dct.Add("or", "oracle");
            dct.Add("cplus", "c++");
            #endregion Adding

            #region KeyFound
            //TryGetValue can be efficient way to retrieve values.
            string value = "";
            if (dct.TryGetValue("ab", out value))
            {
                Console.WriteLine("For key = \"ab\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"ab\" is not found.");
            }
            #endregion KeyFound

            #region CheckAlreadyPresentKey
            // ContainsKey can be used to test keys before inserting them.
            if (!dct.ContainsKey("ht"))
            {
                dct.Add("ht", "html");
                Console.WriteLine("Value added for key = \"ht\": {0}",
                dct["ht"]);
            }
            #endregion CheckAlreadyPresentKey

            #region Display
            // When you use foreach to enumerate dictionary elements, the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in dct)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            #endregion Display

            #region DisplayValue
            // valuecollextion is used for only value
            Dictionary<string, string>.ValueCollection valueColl = dct.Values; 
            Console.WriteLine();
            foreach (string s in valueColl)
            {
                Console.WriteLine("Value = {0}", s);
            }
            #endregion DisplayValue

            #region DisplayKey
            // Keycollection is used for only keys
            Dictionary<string, string>.KeyCollection keyColl = dct.Keys;
            Console.WriteLine();
            foreach (string s in keyColl)
            {
                Console.WriteLine("Key = {0}", s);
            }
            #endregion DisplayKey

            #region Remove
            // to remove a key/value pair.
            Console.WriteLine("\nRemove(\"or\")");
            dct.Remove("or");

            if (!dct.ContainsKey("or"))
            {
                Console.WriteLine("Key \"or\" is not found.");
            }
            #endregion Remove

            #region RemoveLast
          
                Console.WriteLine("Remove Last:");
                // Get the last key using the LastOrDefault LINQ method
              
                string lastKey = dct.Keys.LastOrDefault();

                // Remove the key-value pair
                dct.Remove(lastKey);
                Console.WriteLine();
                foreach (KeyValuePair<string, string> kvp in dct)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
            
                #endregion RemoveLast

                #endregion Dictionary

                #region Stack

                #region Push
                Stack<string> stk = new Stack<string>();
            stk.Push("cs.net");
            stk.Push("vb.net");
            stk.Push("asp.net");
            stk.Push("sqlserver");

            foreach (string sub in stk)
            {
                Console.WriteLine(sub);
            }
            Console.WriteLine();
            #endregion Push

            #region Pop
            //Removes and returns the object at the top of the Stack
            Console.WriteLine("\nPopping '{0}'", stk.Pop());

            foreach (string sub in stk)
            {
                Console.WriteLine(sub);
            }
            Console.WriteLine();
            #endregion Pop

            #region Peek
            //Returns the object at the top of the Stack without removing it.
            Console.WriteLine("Top element of the stack: {0}", stk.Peek());
            #endregion Peek

            #region StackToArray
            Console.WriteLine("\nArray copied from stack");
            // Create an array of the size of the stack and copy the elements of the stack, starting at the 0th index
            string[] array = new string[stk.Count];
            stk.CopyTo(array, 0);

            foreach (string element in array)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
            #endregion StackToArray

            #region Contains ,Clear , Count
            Console.WriteLine("\nstack2.Contains(\"vb.net\") = {0}", stk.Contains("vb.net"));

            Console.WriteLine("\nstack2.Clear()");
            stk.Clear();
            Console.WriteLine("\nstack2.Count = {0}", stk.Count);

            #endregion Contains ,Clear , Count

            #endregion Stack

            #region Queue
            Queue<string> q = new Queue<string>();
            #region Enqueue

            q.Enqueue("cs.net");
            q.Enqueue("vb.net");
            q.Enqueue("asp.net");
            q.Enqueue("sqlserver");

            foreach (string s in q)
            {
                Console.WriteLine(s);
            }
            #endregion Enqueue

            #region Dequeue,Peek
            Console.WriteLine("\nDequeuing '{0}'", q.Dequeue());
            Console.WriteLine("Peek shows top element of the queue: {0}", q.Peek());

            #endregion Dequeue,Peek

            #region Copy
            // Create an array the size of the queue and copy the elements of the queue, starting at the 0th index
            string[] array2 = new string[q.Count];
            q.CopyTo(array2, 0);

            Console.WriteLine("\nContents of the array copied from queue");
            foreach (string myarray in array2)
            {
                Console.WriteLine(myarray);
            }

            #endregion Copy

            #region Contains, Clear , Count
            Console.WriteLine("\nq.Contains(\"c++\") = {0}", q.Contains("c++"));

            Console.WriteLine("q.Clear()");
            q.Clear();
            Console.WriteLine("q.Count = {0}", q.Count);

            #endregion Contains, Clear , Count

            #endregion Queue


            Console.ReadLine();
        }
    }
}
