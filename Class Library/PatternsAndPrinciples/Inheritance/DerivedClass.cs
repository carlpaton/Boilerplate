using System;

namespace Inheritance
{
    public class DerivedClass : BaseClass
    {
        public override void Method1()
        {
            Console.WriteLine("DerivedClass - override Method1");
        }
    }

    public class DerivedClassAbstract : BaseClassAbstract
    {
        public override void Method1()
        {
            Console.WriteLine("DerivedClassAbstract - override Method1");
        }
    }
}
