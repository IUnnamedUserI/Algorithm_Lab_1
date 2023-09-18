using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            Cell[,] Field = new Cell[20, 20];
            int[,] MaxMoney = new int[20, 20];
            int[,] MinMoney = new int[20, 20];

            StreamReader Path = new StreamReader($@"C:\\Users\\PackardBell\\Desktop\\L18.txt");
            string Text = Path.ReadToEnd();
            string[] Line = Text.Split('\n');
            for (int i = 0; i < 20; i++)
            {
                string[] strCell = Line[i].Split(' ');
                for (int j = 0; j < 20; j++) Field[i, j] = new Cell(int.Parse(strCell[j]));
            }

            for (int y = 1; y <= 8; y++) Field[1, y].Blocked = Cell.Block.Right;
            for (int y = 4; y <= 13; y++) Field[3, y].Blocked = Cell.Block.Right;
            for (int y = 9; y <= 13; y++) Field[5, y].Blocked = Cell.Block.Right;
            for (int y = 5; y <= 13; y++) Field[11, y].Blocked = Cell.Block.Right;
            for (int y = 8; y <= 17; y++) Field[14, y].Blocked = Cell.Block.Right;
            for (int x = 3; x <= 7; x++) Field[x, 1].Blocked = Cell.Block.Bottom;
            for (int x = 8; x <= 13; x++) Field[x, 16].Blocked = Cell.Block.Bottom;

            for (int i = 1; i < 20; i++)
            {
                MaxMoney[i, 0] = MaxMoney[i - 1, 0] + Field[i, 0].Money;
                MinMoney[i, 0] = MinMoney[i - 1, 0] + Field[i, 0].Money;

                MaxMoney[0, i] = MaxMoney[0, i - 1] + Field[0, i].Money;
                MinMoney[0, i] = MinMoney[0, i - 1] + Field[0, i].Money;
            }

            for (int i = 1; i < 20; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    if (Field[i, j].Blocked == Cell.Block.None)
                    {
                        MaxMoney[i, j] = Math.Max(MaxMoney[i - 1, j], MaxMoney[i, j - 1]) + Field[i, j].Money;
                        MinMoney[i, j] = Math.Min(MinMoney[i - 1, j], MinMoney[i, j - 1]) + Field[i, j].Money;
                    }
                    else if (Field[i, j].Blocked == Cell.Block.Right)
                    {
                        MaxMoney[i, j] = MaxMoney[i, j - 1] + Field[i, j].Money;
                        MinMoney[i, j] = MinMoney[i, j - 1] + Field[i, j].Money;
                    }
                    else if (Field[i, j].Blocked == Cell.Block.Bottom)
                    {
                        MaxMoney[i, j] = MaxMoney[i - 1, j] + Field[i, j].Money;
                        MinMoney[i, j] = MinMoney[i - 1, j] + Field[i, j].Money;
                    }
                }
            }
            Console.WriteLine("Максимальное количество монет: " + MaxMoney[14, 14].ToString());
            Console.WriteLine("Минимальное количество монет: " + MinMoney[14, 14].ToString());
            Console.ReadKey();
        }
    }

    class Cell
    {
        public enum Block
        {
            None,
            Right,
            Bottom
        }

        public Block Blocked;
        public int Money;

        public Cell(int Money)
        {
            Blocked = Block.None;
            this.Money = Money;
        }
    }
}
