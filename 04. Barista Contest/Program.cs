namespace _04._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coffeeQuantities = Console.ReadLine()
                 .Split(", ")
                 .Select(int.Parse)
                 .ToArray();
            int[] milkQuantities = Console.ReadLine()
               .Split(", ")
               .Select(int.Parse)
               .ToArray();
            
            Queue<int> coffee = new Queue<int>(coffeeQuantities);
            Stack<int> milk = new Stack<int>(milkQuantities);

            Dictionary<string, int> drinksCrafted = new Dictionary<string, int>
            {
                { "Cortado", 0 },
                { "Espresso", 0 },
                { "Capuccino", 0},
                { "Americano", 0 },
                { "Latte", 0 }
            };
            while (coffee.Any() && milk.Any())
            {
                int combination = coffee.Peek() + milk.Peek();
                
                if (combination == 50)
                {
                    drinksCrafted["Cortado"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }
                else if (combination == 75)
                {
                    drinksCrafted["Espresso"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }
                else if (combination == 100)
                {
                    drinksCrafted["Capuccino"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }
                else if (combination == 150)
                {
                    drinksCrafted["Americano"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }
                else if (combination == 200)
                {
                    drinksCrafted["Latte"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }
                else
                {
                    coffee.Dequeue();
                    int tempMilkQuantity = milk.Pop();
                    milk.Push(tempMilkQuantity - 5);
                }
            }
            if (!coffee.Any() && !milk.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            if (coffee.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }
            if (milk.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }
            foreach(var drink in drinksCrafted.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if (drink.Value > 0)
                {
                    Console.WriteLine($"{drink.Key}: {drink.Value}");
                }
                
            }
        }
    }
}