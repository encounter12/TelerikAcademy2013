namespace DecoratorPattern
{
    public class ToppingDecorator : Pizza
    {
        protected Pizza basePizza;

        public ToppingDecorator(Pizza pizza)
        {
            basePizza = pizza;
        }

        public override string GetDescription()
        {
            return basePizza.GetDescription();
        }

        public override decimal GetPrice()
        {
            return basePizza.GetPrice();
        }
    }
}