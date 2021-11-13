
using task3_30;

namespace task3_30_
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            List<Sort> sortsOfCoffee = new List<Sort>();
            sortsOfCoffee.Add(new Sort(new Coffee("corn", 100), 10, "Arusha"));
            sortsOfCoffee.Add(new Sort(new Coffee("ground", 200), 10, "Arusha"));
            sortsOfCoffee.Add(new Sort(new Coffee("instant", 250), 10, "Arusha"));
            sortsOfCoffee.Add(new Sort(new Coffee("corn", 100), 20, "Benguet"));
            sortsOfCoffee.Add(new Sort(new Coffee("instant", 100), 10, "Benguet"));
            sortsOfCoffee.Add(new Sort(new Coffee("bags", 50), 15, "Benguet"));
            sortsOfCoffee.Add(new Sort(new Coffee("bags", 100), 50, "Bergendal"));
            sortsOfCoffee.Add(new Sort(new Coffee("corn", 100), 20, "Catimor"));
            sortsOfCoffee.Add(new Sort(new Coffee("instant", 300), 10, "Catimor"));
            sortsOfCoffee.Add(new Sort(new Coffee("ground", 50), 150, "Caturra"));
            sortsOfCoffee.Add(new Sort(new Coffee("bags", 200), 50, "Yirgacheffe"));

            Console.Write("Введите общий вес кофе, который помещается в фургон: ");
            string? weight = Console.ReadLine();
            int w = Convert.ToInt32(weight);

            Console.Write(" и общую цену кофе: ");
            string? price = Console.ReadLine();
            int p = Convert.ToInt32(price);

            List<Sort> van = new List<Sort>();
            van = addCoffeeToVan(van, w, p, sortsOfCoffee);


            if (van == null)
            {
                Console.WriteLine("В фургон пуст:");

            }
            else
            {
                int n = 1;
                Console.WriteLine();
                Console.WriteLine("В фургон добавлены следующие позиции:");
                foreach (Sort sort in van)
                {
                    Console.WriteLine(n + ". Название сорта: " + sort.name + ", вес: " + sort.coffee.weight + ", цена:" + countPrice(sort.coffee, sort.price));
                    n++;
                }

                Console.WriteLine();
                Console.WriteLine("Кофе отсортированный в фургоне по цене и весу: ");
                sort(van);


                Console.WriteLine();
                Console.WriteLine("Введите свойсва кофе, который бы хотели найти:");
                Console.WriteLine("Минимальная цена: ");
                string? minPrice = Console.ReadLine();
                int mp = Convert.ToInt32(minPrice);

                Console.WriteLine("Максимальная цена: ");
                string? maxPrice = Console.ReadLine();
                int maxp = Convert.ToInt32(maxPrice);

                Console.WriteLine("Минимальный вес: ");
                string? minWeight = Console.ReadLine();
                int mw = Convert.ToInt32(minWeight);

                Console.WriteLine("Максимальный вес: ");
                string? maxWeight = Console.ReadLine();
                int maxw = Convert.ToInt32(maxWeight);

                Console.WriteLine("Физическое состояние: ");
                string? condition = Console.ReadLine();

                Console.WriteLine();
                findingProduct(van, mp, maxp, mw, maxw, condition);

            }

        }

        public static List<Sort> addCoffeeToVan(List<Sort> van, int weight, int price, List<Sort> sortsOfCoffee)
        {
            int amountPrice = 0;
            int amountWeight = 0;
            foreach (Sort sort in sortsOfCoffee)
            {
                if (amountPrice < price && amountWeight < weight){

                    amountPrice += countPrice(sort.coffee, sort.price);
                    amountWeight += sort.coffee.weight;

                    if (!(amountPrice < price && amountWeight < weight))
                    {
                        amountPrice -= countPrice(sort.coffee, sort.price);
                        amountWeight -= sort.coffee.weight;

                    }
                    else
                    {
                        van.Add(sort);
                    }

                }else
                {
                    break;
                }
            }

            return van;
        }

        public static void sort(List<Sort> van)
        {
            var res = from v in van
                      orderby v.coffee.weight, countPrice(v.coffee, v.price)
                      select v;

            foreach (Sort s in res)
            {
                Console.WriteLine(s.name + ": вес - " + s.coffee.weight + ", цена - " + countPrice(s.coffee, s.price));

            }

        }
 


     

        public static void findingProduct(List<Sort> van, int minPrice, int maxPrice, int minWeight, int maxWeight, string condition)
        {
            int n = 0;
            foreach (Sort sort in van)
            {
                if (countPrice(sort.coffee, sort.price) <= maxPrice && countPrice(sort.coffee, sort.price) >= minPrice && sort.coffee.weight <= maxWeight && sort.coffee.weight >= minWeight && sort.coffee.condition == condition)
                {
                    Console.WriteLine("Найденный товар:");
                    Console.WriteLine("Название сорта кофе:" + sort.name);
                    Console.WriteLine("Вес:" + sort.coffee.weight);
                    Console.WriteLine("Цена:" + countPrice(sort.coffee, sort.price));
                    n = 1;
                    break;
                }
            }

            if (n == 0)
            {
                Console.WriteLine("Товар не найден");
            }

        }

        public static int countPrice(Coffee coffee, int price)
        {
            return coffee.weight * price;
        }

        public static void print(List<Object> list)
        {
            foreach ( Object ob in list)
            {
                Console.WriteLine(ob);
            }
        }

    }
    
}
