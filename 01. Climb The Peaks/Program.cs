namespace _01._Climb_The_Peaks
{
    internal class Program
    {
        static void Main()
        {
            int[] foodDailyPortion = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[] staminaDailyPortion = Console.ReadLine()
                 .Split(", ")
                 .Select(int.Parse)
                 .ToArray();
            Queue<int> stamina = new Queue<int>(staminaDailyPortion);
            Stack<int> food = new Stack<int>(foodDailyPortion);
            Dictionary<string, int> mountainPeeks = new Dictionary<string, int>
            {
                { "Vihren", 80 },
                { "Kutelo", 90 },
                { "Banski Suhodol", 100},
                { "Polezhan", 60 },
                { "Kamenitza", 70 }
            };
            Dictionary<string, int> conqueredPeeks = new Dictionary<string, int>();
            int Days = 7;
            while (food.Any() && stamina.Any() && mountainPeeks.Any() && Days != 0)
            {
                int climbPower = food.Peek() + stamina.Peek();
                Days--;
                foreach (var peek in  mountainPeeks)
                {
                    food.Pop();
                    stamina.Dequeue();
                    if (climbPower >= peek.Value)
                    {
                        conqueredPeeks.Add(peek.Key, peek.Value);
                        mountainPeeks.Remove(peek.Key);
                        break;
                    }
                    else
                    {
                        break; 
                    }
                }
            }
            if (!mountainPeeks.Any())
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }
            if (conqueredPeeks.Any())
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var peek in conqueredPeeks)
                {
                    Console.WriteLine(peek.Key);
                }
            }
        }
    }
}