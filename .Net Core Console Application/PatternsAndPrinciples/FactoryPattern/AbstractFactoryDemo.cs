using System;
using System.Collections.Generic;

namespace FactoryPattern.AbstractFactoryDemoNameSpace
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

    #region HotDrinkMachine using enum
    public class HotDrinkMachine
    {
        public enum AvailableDrink // violates open-closed
        {
            Coffee, Tea
        }

        // Dictionary from enumeration AvailableDrink that maps to avalible factories
        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var typeName = $"FactoryPattern.AbstractFactoryDemoNameSpace.{Enum.GetName(typeof(AvailableDrink), drink)}Factory";
                var type = Type.GetType(typeName);
                var factory = (IHotDrinkFactory)Activator.CreateInstance(type);

                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }
    #endregion

    public class AbstractFactoryDemo
    {   
        public AbstractFactoryDemo() 
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 250);
            drink.Consume();
        }
    }
}
