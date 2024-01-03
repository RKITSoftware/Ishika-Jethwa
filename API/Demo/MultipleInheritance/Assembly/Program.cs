using System;
using AccessSpecifiers;

namespace Assembly
{
    /// <summary>
    /// This class demonstrates the accessibility of variables in a derived class from a different assembly.
    /// </summary>
    public class AssemblyDeriveClass : BaseClass
    {
        /// <summary>
        /// This method tests the accessibility of variables in a derived class from a different assembly.
        /// </summary>
        public void AssemblyTestAccess()
        {
            //Not Accessible

            //Console.WriteLine(privateVariable);
            //Console.WriteLine(internalVariable);

            //Accessible

            Console.WriteLine(protectedVariable);
            Console.WriteLine(protectedInternalVariable);
            Console.WriteLine(publicVariable);

        }
    }
    /// <summary>
    /// This class demonstrates the accessibility of variables in another class from a different assembly.
    /// </summary>
    public class AssemblyOtherClass 
    {
        /// <summary>
        /// This method tests the accessibility of variables in another class from a different assembly.
        /// </summary>
        public void AssemblyOtherTestAccess()
        {
            AssemblyDeriveClass objDerive = new AssemblyDeriveClass();

            //Not Accessible

            //Console.WriteLine(objDerive.privateVariable);
            //Console.WriteLine(objDerive.internalVariable);
            //Console.WriteLine(objDerive.protectedVariable);
            //Console.WriteLine(objDerive.protectedInternalVariable);

            //Accessible
            Console.WriteLine(objDerive.publicVariable);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyDeriveClass obj = new AssemblyDeriveClass();
            Console.WriteLine("Different Assembly  Derive class:");
            Console.WriteLine();
            obj.AssemblyTestAccess();

            Console.WriteLine();
            Console.WriteLine("Different Assembly  other class:");
            AssemblyOtherClass objOther = new AssemblyOtherClass();
            objOther.AssemblyOtherTestAccess();
            

            Console.ReadLine();
        }
    }
}
