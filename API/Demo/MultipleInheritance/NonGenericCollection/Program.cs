using System;
using System.Collections;


namespace NonGenericCollection
{
    /// <summary>
    /// Prints the values of the given IEnumerable collection.
    /// </summary>
    /// <param name="myList">The IEnumerable collection to print.</param>
    class Program
    {
        #region Method:PrintValues
        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
            {
                Console.Write("   {0}", obj);
            }
            Console.WriteLine();
        }
        #endregion Method:PrintValues
        static void Main(string[] args)
        {
            #region ArrayList
            // Creates and initializes a new ArrayList.
            ArrayList al = new ArrayList();
            string str = "Ishika Jethwa";
            int x = 7;
            double d = 15.12;
            al.Add(str);
            al.Add(x);
            al.Add(d);


            // Displays the properties and values of the ArrayList.
            Console.WriteLine("    Count:    {0}", al.Count);
            Console.WriteLine("    Capacity: {0}", al.Capacity);
            Console.Write("    Values:");
            PrintValues(al);

            #endregion ArrayList

            #region Stack

            // Creates and initializes a new Stack.
            Stack stk = new Stack();
            stk.Push("cs.net");
            stk.Push("vb.net");
            stk.Push("asp.net");
            stk.Push("sqlserver");

            // Displays the properties and values of the Stack.
            Console.WriteLine("Count:    {0}", stk.Count);
            Console.Write("Values:\t");
            PrintValues(stk);

            //remove element from the stack
            Console.Write("Values:\t");
            stk.Pop();
            PrintValues(stk);
            #endregion Stack

            #region Queue
            // Creates and initializes a new Queue.
            Queue q = new Queue();
            q.Enqueue("cs.net");
            q.Enqueue("vb.net");
            q.Enqueue("asp.net");
            q.Enqueue("sqlserver");

            // Displays the properties and values of the Queue.
            Console.WriteLine("Count:    {0}", q.Count);
            Console.Write("Values:");
            PrintValues(q);

            //peek returns the oldest element that is at the start of the Queue
            Console.WriteLine("oldest element:    {0}", q.Peek());

            //Dequeue removes the oldest element from the start of the Queue.
            q.Dequeue();

            Console.Write("Values:");
            PrintValues(q);

            #endregion Queue

            #region Hashtable

            // Create a new hash table. Add some elements to the hash table.
            Hashtable ht = new Hashtable();
            ht.Add("ora", "oracle");
            ht.Add("vb", "vb.net");
            ht.Add("cs", "cs.net");
            ht.Add("asp", "asp.net");

            // ContainsKey can be used to test keys before inserting them.
            if (!ht.ContainsKey("cplus"))
            {
                ht.Add("cplus", "c++");
                Console.WriteLine("Value added for key = \"cplus\": {0}", ht["cplus"]);
            }

            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (DictionaryEntry de in ht)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }

            // to remove a key/value pair.
            Console.WriteLine("\n Remove(\"vb\")");
            ht.Remove("vb");

            if (!ht.ContainsKey("vb"))
            {
                Console.WriteLine("Key \"vb\" is not found.");
            }
            #endregion Hashtable

            Console.ReadLine();
        }
    }
}

