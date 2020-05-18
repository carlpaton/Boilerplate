using System;
using System.Text.Json;

namespace PrototypePattern.JsonSerializationDemoNameSpace
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var json = JsonSerializer.Serialize(self);
            return JsonSerializer.Deserialize<T>(json);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public Address Address { get; set; }

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
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

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

    public class JsonSerializationDemo
    {
        public JsonSerializationDemo() 
        {
            Console.WriteLine("using JSON (System.Text.Json)\n");
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
