using Newtonsoft.Json;
using System;

namespace PrototypePattern.JsonSerializationDemo2NameSpace
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var json = JsonConvert.SerializeObject(self);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    public class Person
    {
        public string FirstName;
        public Address Address;
        public string SomeField;

        public Person(string firstName, Address address)
        {
            FirstName = firstName;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(SomeField)}: {SomeField}, {nameof(Address)}: {Address}";
        }
    }

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

    public class JsonSerializationDemo2
    {
        public JsonSerializationDemo2() 
        {
            Console.WriteLine("using JSON (Newtonsoft.Json)\n");
            var carl = new Person("Carl", new Address("Sale Street", 66))
            {
                SomeField = "foo"
            };

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
