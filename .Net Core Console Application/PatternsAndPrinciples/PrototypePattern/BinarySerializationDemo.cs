using PrototypePattern.JsonSerializationDemo2NameSpace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrototypePattern.BinarySerializationDemoNameSpace
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin); // Rewind the stream with offset of 0 from the begining

                object copy = formatter.Deserialize(stream);
                stream.Close();
                return (T)copy;
            }
        }
    }

    [Serializable]
    public class Person
    {
        public string FirstName;
        public Address Address;
        private IList<InvoiceLineModel> _lineItems { get; set; }

        public Person(string firstName, Address address)
        {
            FirstName = firstName;
            Address = address;

            _lineItems = new List<InvoiceLineModel>
            {
                new InvoiceLineModel
                {
                    InvoiceLineId = 1,
                    Description = "foo",
                    Quantity = 123,
                    Cost = 100
                }
            };
        }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(Address)}: {Address}";
        }
    }

    [Serializable]
    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public class BinarySerializationDemo
    {
        public BinarySerializationDemo() 
        {
            Console.WriteLine("using BinaryFormatter\n");
            var carl = new Person("Carl", new Address("Sale Street", 66));

            Console.WriteLine("Initial Object:");
            Console.WriteLine(carl);
            Console.WriteLine("-----------------------");

            var john = carl.DeepCopy();
            john.FirstName = "John";
            john.Address.HouseNumber = 789;
            john.Address.StreetName = "Foo Street";

            Console.WriteLine("Initial Object & Copy:");
            Console.WriteLine(carl);
            Console.WriteLine(john);
        }
    }
}
