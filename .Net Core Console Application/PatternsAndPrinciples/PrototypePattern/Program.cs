using PrototypePattern.CopyConstructorDemoNameSpace;
using PrototypePattern.ICloneableDemoNameSpace;
using PrototypePattern.ProtoTypeDemoNameSpace;
using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello PrototypePattern!");
            Console.WriteLine("****************************\n");

            // new ICloneableDemo();

            // new CopyConstructorDemo();

            new IProtoTypeDemo();
        }
    }
}
