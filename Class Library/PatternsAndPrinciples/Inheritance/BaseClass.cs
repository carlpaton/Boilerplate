using System;

//https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance
namespace Inheritance
{
    public class BaseClass
    {
        //Derived classes can also override inherited members by providing an alternate implementation.
        public virtual void Method1()
        {
            Console.WriteLine("DerivedClass behavior");
        }
    }

    public abstract class BaseClassAbstract
    {
        //Base class members marked with the abstract keyword require that derived classes override them.
        public abstract void Method1();
    }
}
