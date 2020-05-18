using PrototypePattern.BinarySerializationDemoNameSpace;
using PrototypePattern.CopyConstructorDemoNameSpace;
using PrototypePattern.ICloneableDemoNameSpace;
using PrototypePattern.JsonSerializationDemo2NameSpace;
using PrototypePattern.JsonSerializationDemoNameSpace;
using PrototypePattern.ProtoTypeDemoNameSpace;
using PrototypePattern.XmlSerializationDemoNameSpace;
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

            // new IProtoTypeDemo();

            // new BinarySerializationDemo();

            // new XmlSerializationDemo();

            //System.Text.Json
            // new JsonSerializationDemo();

            //
            new JsonSerializationDemo2();
        }
    }
}
