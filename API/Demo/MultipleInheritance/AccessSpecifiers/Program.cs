using System;


namespace AccessSpecifiers
{
    /// <summary>
    /// This program demonstrates the use of different access specifiers in C# and their visibility in various scenarios.
    /// </summary>
    public class BaseClass
    {
        private string privateVariable = "PrivateVariable";
        protected string protectedVariable = "ProtectedVariable";
        internal string internalVariable = "InternalVariable";
        protected internal string protectedInternalVariable = "ProtectedInternalVariable";
        public string publicVariable = "PublicVariable";

        public void TestAccess()
        {
            //Accessible
            Console.WriteLine(privateVariable);
            Console.WriteLine(protectedVariable);
            Console.WriteLine(internalVariable);
            Console.WriteLine(protectedInternalVariable);
            Console.WriteLine(publicVariable);

        }
    }
    class DeriveClass : BaseClass
    {
        public void TestDeriveAccess()
        {
            //not Accessible
            //Console.WriteLine(privateVariable);

            //Accessible
            Console.WriteLine(protectedVariable);
            Console.WriteLine(internalVariable);
            Console.WriteLine(protectedInternalVariable);
            Console.WriteLine(publicVariable);

        }
    }
    class OtherBaseClass
    {
        public void TestAccess()
        {
            BaseClass objBase = new BaseClass();
            // Not Accessible
            //Console.WriteLine(objBase.privateVariable);
            //Console.WriteLine(objBase.protectedVariable);

            //Accessible
            Console.WriteLine(objBase.internalVariable);
            Console.WriteLine(objBase.protectedInternalVariable);
            Console.WriteLine(objBase.publicVariable);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Same Class:");
            Console.WriteLine();
            BaseClass objBase = new BaseClass();
            objBase.TestAccess();
            Console.WriteLine();

            Console.WriteLine("Derive Class:");
            Console.WriteLine();
            DeriveClass objDerive = new DeriveClass();
            objDerive.TestAccess(); // calling base class method
            Console.WriteLine();
            objDerive.TestDeriveAccess(); //calling derive class method

            Console.WriteLine();
            Console.WriteLine("Other Class:");
            Console.WriteLine();

            OtherBaseClass oobjBase = new OtherBaseClass();
            oobjBase.TestAccess();

            Console.ReadLine();
        }
    }
}
