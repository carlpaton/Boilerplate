using System;
using System.IO;
using System.Xml.Serialization;

namespace PrototypePattern.XmlSerializationDemoNameSpace
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stream, self);
                stream.Position = 0; // same as `stream.Seek(0, SeekOrigin.Begin);`

                return (T) xmlSerializer.Deserialize(stream);
            }
        }
    }

    public class Person
    {
        public string FirstName;
        public Address Address;

        public Person() 
        { 
        }

        public Person(string firstName, Address address)
        {
            FirstName = firstName;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(Address)}: {Address}";
        }
    }

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address()
        {
        }

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

    public class XmlSerializationDemo
    {
        public XmlSerializationDemo() 
        {
            Console.WriteLine("using XMlSerializer\n");
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
