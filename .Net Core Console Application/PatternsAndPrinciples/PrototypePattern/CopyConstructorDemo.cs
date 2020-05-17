using System;

namespace PrototypePattern.CopyConstructorDemoNameSpace
{
    public class Person
    {
        public string FirstName;
        public Address Address;

        public Person(Person other)
        {
            FirstName = other.FirstName;
            Address = new Address(other.Address);
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

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
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

    public class CopyConstructorDemo
    {
        public CopyConstructorDemo() 
        {
            Console.WriteLine("CopyConstructorDemo");
            Console.WriteLine("----------------------------\n");

            var carl = new Person("Carl", new Address("Sale Street", 66));
            var john = new Person(carl)
            {
                FirstName = "John",
            };
            john.Address.HouseNumber = 123;
            john.Address.StreetName = "Foo Street";

            Console.WriteLine(carl);
            Console.WriteLine(john);
        }
    }
}
