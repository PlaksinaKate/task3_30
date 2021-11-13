

namespace task3_30
{
    internal class Sort
    {
        public Coffee coffee;
        public int price;
        public string name;

        public Sort(Coffee coffee, int price, string name)
        {
            this.coffee = coffee;
            this.price = price;
            this.name = name;
        }



        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Coffee Coffee
        {
            get {  return coffee; }
            set { coffee = value; }
        }

        
    }
}
