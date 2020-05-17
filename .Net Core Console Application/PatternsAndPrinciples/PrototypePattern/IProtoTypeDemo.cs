using System;

namespace PrototypePattern.ProtoTypeDemoNameSpace
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Person : IPrototype<Person>
    {
        public string FirstName;
        public Address Address;

        public Person(string firstName, Address address)
        {
            FirstName = firstName;
            Address = address;
        }

        public Person DeepCopy()
        {
            return new Person(FirstName, Address.DeepCopy());
        }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(Address)}: {Address}";
        }
    }

    public class Address : IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public class IProtoTypeDemo
    {
        public IProtoTypeDemo() 
        {
            Console.WriteLine("IProtoTypeDemo");
            Console.WriteLine("----------------------------\n");

            var carl = new Person("Carl", new Address("Sale Street", 66));
            var john = carl.DeepCopy();
            john.FirstName = "John";
            john.Address.HouseNumber = 456;
            john.Address.StreetName = "Hoe Street";

            Console.WriteLine(carl);
            Console.WriteLine(john);
        }
    }
}
