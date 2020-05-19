using FactoryPattern.AbstractFactoryDemo2NameSpace;
using FactoryPattern.AbstractFactoryDemoNameSpace;
using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary from enumeration AvailableDrink that maps to avalible factories
            //new AbstractFactoryDemo();

            // HotDrinkMachine using reflection, typically you would use DI to inject these
            new AbstractFactoryDemo2();
        }
    }

    public class Foo { }
}
