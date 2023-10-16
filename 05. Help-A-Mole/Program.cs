namespace _05._Help_A_Mole
{
    public class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];

            int moleRowIndex = 0;
            int moleColIndex = 0;
            int[] teleport1 = new int[2];            
            int[] teleport2 = new int[2];
            int molePoints = 0;
            for (int rows = 0; rows < field.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine().ToArray();


                for (int cols = 0; cols < field.GetLength(1); cols++)
                {
                    field[rows, cols] = col[cols];
                    if (col[cols] == 'M')
                    {
                        moleRowIndex = rows;
                        moleColIndex = cols;
                        field[rows, cols] = '-';
                    }
                    else if (col[cols] ==  'S')
                    {
                        if (teleport1[0] == 0 && teleport1[1] == 0)
                        {
                            teleport1[0] = rows;
                            teleport1[1] = cols;
                        }
                        else
                        {
                            teleport2[0] = rows;
                            teleport2[1] = cols;
                        }
                        
                    }
                }
            } 
            
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                if (molePoints >= 25)
                {
                    break;
                }
                switch (command)
                {
                    case "up":
                        if (BoundsCheck(moleRowIndex - 1, moleColIndex, field))
                        {
                            moleRowIndex--;
                            (moleRowIndex, moleColIndex, molePoints, field) =
                                PositionActions(moleRowIndex, moleColIndex, field, molePoints, teleport1, teleport2);
                        }
                        
                        
                        break;
                    case "down":
                        if (BoundsCheck(moleRowIndex + 1, moleColIndex, field))
                        {
                                moleRowIndex++;
                            (moleRowIndex, moleColIndex, molePoints, field) =
                                PositionActions(moleRowIndex, moleColIndex, field, molePoints, teleport1, teleport2);
                        }
                        break;
                    case "right":
                        if (BoundsCheck(moleRowIndex, moleColIndex + 1, field))
                        {
                            moleColIndex++;
                            (moleRowIndex, moleColIndex, molePoints, field) =
                                PositionActions(moleRowIndex, moleColIndex, field, molePoints, teleport1, teleport2);
                        }

                        break;
                    case "left":
                        if (BoundsCheck(moleRowIndex, moleColIndex - 1, field))
                        {
                            moleColIndex--;
                            (moleRowIndex, moleColIndex, molePoints, field) =
                                PositionActions(moleRowIndex, moleColIndex, field, molePoints, teleport1, teleport2);
                        }
                        break;
                }
            }
            field[moleRowIndex, moleColIndex] = 'M';
            if (molePoints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {molePoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {molePoints} points.");
            }
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]}");
                }
                Console.WriteLine();
            }

        }
        public static Tuple<int,int, int, char[,]> PositionActions(int row, int col, char[,] field, int points, int[] teleport1, int[] teleport2)
        {
            if (char.IsDigit(field[row, col]))
            {
                int pointss = int.Parse(field[row, col].ToString());
                points += pointss;
                field[row, col] = '-';
            }
            else if (field[row, col] == 'S')
            {
                
                if (row == teleport1[0] && col == teleport1[1])
                {
                    field[teleport1[0], teleport1[1]] = '-';
                    field[teleport2[0], teleport2[1]] = '-';
                    row = teleport2[0];
                    col = teleport2[1];
                }
                else
                {

                    field[teleport1[0], teleport1[1]] = '-';
                    field[teleport2[0], teleport2[1]] = '-';
                    row = teleport1[0];
                    col = teleport1[1];
                }
                points -= 3;
                
            }
            return Tuple.Create(row,col, points, field);
        }
        public static bool BoundsCheck(int rowIndex, int colIndex, char[,] matrix)
        {
            if (rowIndex >= 0 && colIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Don't try to escape the playing field!");
                return false;
            }

        }
    }
}