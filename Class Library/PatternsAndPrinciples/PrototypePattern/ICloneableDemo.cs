using System;

namespace PrototypePattern.ICloneableDemoNameSpace
{
    public class Person : ICloneable
    {
        public string FirstName;
        public Address Address;

        public Person(string firstName, Address address)
        {
            FirstName = firstName;
            Address = address;
        }

        public object Clone()
        {
            return new Person(FirstName, (Address)Address.Clone());
        }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(Address)}: {Address}";
        }
    }

    public class Address : ICloneable
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public class ICloneableDemo
    {
        public ICloneableDemo() 
        {
            Console.WriteLine("ICloneableDemo");
            Console.WriteLine("----------------------------\n");

            var carl = new Person("Carl", new Address("Sale Street", 66));

            // This will fail, this assigned the reference
            var john = carl;
            john.FirstName = "John One";
            Console.WriteLine("This will fail, this assigned the reference:");
            Console.WriteLine(carl);
            Console.WriteLine(john);
            Console.WriteLine("----------------------------");

            // Although this will work its a shallow copy
            var carl2 = new Person("Carl", new Address("Sale Street", 66));
            var john2 = (Person)carl2.Clone();
            john2.FirstName = "John Two";
            john2.Address.HouseNumber = 111;
            john2.Address.StreetName = "Foo Street";
            Console.WriteLine(carl2);
            Console.WriteLine(john2);

        }
    }
}
