namespace _02._Navy_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] battleField = new char[fieldSize, fieldSize];

            int submarineRowIndex = 0;
            int submarineColIndex = 0;
            int mineHits = 0;
            int cruisers = 3;

            for (int rows = 0; rows < battleField.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine().ToArray();


                for (int cols = 0; cols < battleField.GetLength(1); cols++)
                {
                    battleField[rows, cols] = col[cols];
                    if (col[cols] == 'S')
                    {
                        submarineRowIndex = rows;
                        submarineColIndex = cols;
                        battleField[rows, cols] = '-';
                    }
                }
            }
            
            while (cruisers != 0 && mineHits != 3)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                            submarineRowIndex--;
                        (mineHits, cruisers, battleField) = PositionActions(submarineRowIndex, submarineColIndex, battleField, mineHits, cruisers);
                        break;
                    case "down":
                            submarineRowIndex++;
                        (mineHits, cruisers, battleField) = PositionActions(submarineRowIndex, submarineColIndex, battleField, mineHits, cruisers);


                        break;
                    case "right":
                        
                            submarineColIndex++;
                        (mineHits, cruisers, battleField) = PositionActions(submarineRowIndex, submarineColIndex, battleField, mineHits, cruisers);

                        break;
                    case "left":
                            submarineColIndex--;
                        (mineHits, cruisers, battleField) = PositionActions(submarineRowIndex, submarineColIndex, battleField, mineHits, cruisers);
                        break;
                }
            }
            battleField[submarineRowIndex, submarineColIndex] = 'S';
            if (cruisers == 0)
            {
                
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            }
            else
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRowIndex}, {submarineColIndex}]!");
            }
            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                for (int col = col = 0; col < battleField.GetLength(1); col++)
                {
                    Console.Write($"{battleField[row, col]}");
                }
                Console.WriteLine();
         }
        }
        public static Tuple<int, int, char[,]> PositionActions(int row, int col, char[,] battleField, int mineHits, int cruiser)
        {
            if (battleField[row, col] == '*')
            {
                mineHits++;
                battleField[row, col] = '-';
            }
            else if (battleField[row, col] == 'C')
            {
                cruiser--;
                battleField[row, col] = '-';
            }
            return Tuple.Create(mineHits, cruiser, battleField);
        }
    }
}