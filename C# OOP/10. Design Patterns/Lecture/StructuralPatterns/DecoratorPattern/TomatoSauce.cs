using System;

namespace DecoratorPattern
{
    public class TomatoSauce : ToppingDecorator
    {
        public TomatoSauce(Pizza pizza)
            : base(pizza)
        {
            Console.WriteLine("Adding Tomato sauce");
        }

        public override string GetDescription()
        {
            return basePizza.GetDescription() + ", Tomato Sauce";
        }

        public override decimal GetPrice()
        {
            return basePizza.GetPrice() + 0.60M;
        }
    }
}