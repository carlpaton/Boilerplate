using System;
using System.Collections.Generic;

namespace FactoryPattern.AbstractFactoryDemo2NameSpace
{
    public class AbstractFactoryDemo2
    {
        #region Interfaces
        public interface IHotDrink
        {
            void Consume();
        }

        public interface IHotDrinkFactory
        {
            IHotDrink Prepare(int amount);
        }
        #endregion

        #region Factories
        internal class TeaFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                Console.WriteLine($"Process to make TEA. Amount was {amount} ml.");
                return new Tea();
            }
        }
        internal class CoffeeFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                Console.WriteLine($"Process to make COFFEE. Amount was {amount} ml.");
                return new Coffee();
            }
        }
        #endregion

        #region Rules that implement IHotDrink
        internal class Tea : IHotDrink
        {
            public void Consume()
            {
                Console.WriteLine("Consume Tea");
            }
        }

        internal class Coffee : IHotDrink
        {
            public void Consume()
            {
                Console.WriteLine("Consume Coffee");
            }
        }
        #endregion

        #region HotDrinkMachine using reflection, typically you would use DI to inject these
        public class HotDrinkMachine
        {
            private List<Tuple<string, IHotDrinkFactory>> namedFactories = new List<Tuple<string, IHotDrinkFactory>>();

            public HotDrinkMachine()
            {
                // get all types from the hot drink assembly
                foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
                {
                    if (typeof(IHotDrinkFactory).IsAssignableFrom(t) // test if the interface is implemented 
                        && !t.IsInterface) // exclude the interface itself
                    {
                        namedFactories.Add(Tuple.Create(
                          t.Name.Replace("Factory", string.Empty), 
                          (IHotDrinkFactory)Activator.CreateInstance(t)));
                    }
                }
            }

            public IHotDrink MakeDrink()
            {
                Console.WriteLine("Available drinks");
                for (var index = 0; index < namedFactories.Count; index++)
                {
                    var tuple = namedFactories[index];
                    Console.WriteLine($"{index}: {tuple.Item1}");
                }

                while (true)
                {
                    string s;
                    if ((s = Console.ReadLine()) != null
                        && int.TryParse(s, out int i)
                        && i >= 0
                        && i < namedFactories.Count)
                    {
                        Console.Write("Specify amount: ");
                        s = Console.ReadLine();
                        if (s != null
                            && int.TryParse(s, out int amount)
                            && amount > 0)
                        {
                            return namedFactories[i].Item2.Prepare(amount);
                        }
                    }
                    Console.WriteLine("Incorrect input, try again.");
                }
            }
        }
        #endregion

        public AbstractFactoryDemo2()
        {
            var machine = new HotDrinkMachine();
            IHotDrink drink = machine.MakeDrink();
            drink.Consume();
        }
    }
}
