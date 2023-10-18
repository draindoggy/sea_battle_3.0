using System;
using System.Collections.Generic;

class Ship
{
    public int X { get; set; }
    public int Y { get; set; }
    public Ship(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class GameField
{
    private int[,] mas1;
    private int[,] mas2;
    private List<string> movesHistory;
    private int hitCount;

    public GameField()
    {
        mas1 = new int[10, 10];
        mas2 = new int[10, 10];
        movesHistory = new List<string>();
        hitCount = 0;
    }

    public void Initialize()
    {
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if ((i % 2) == 0)
                {
                    mas1[i, j] = rand.Next(0, 2);
                }
                else
                {
                    mas1[i, j] = 0;
                }
            }
        }
    }

    public void DrawField()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write("[ ]");
            }
            Console.WriteLine();
        }
    }

    public void PlaceShips()
    {
        int x, y;

        for (int t = 0; t < 50; t++)
        {
            Console.WriteLine("введите координаты корабля через Enter:");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            y--;
            x--;
            Console.Clear();

            if (x >= 0 && x < 10 && y >= 0 && y < 10)
            {
                if (mas1[x, y] == 1)
                {
                    mas2[x, y] = 1;
                    hitCount++;
                    movesHistory.Add($"ход {t + 1}: игрок попал в корабль по координатам [{x + 1}, {y + 1}]");
                }
                else
                {
                    mas2[x, y] = 2;
                    movesHistory.Add($"ход {t + 1}: игрок промахнулся по координатам [{x + 1}, {y + 1}]");
                }
            }
            else
            {
                movesHistory.Add($"ход {t + 1}: игрок ввел недопустимые координаты [{x + 1}, {y + 1}]");
                Console.WriteLine("вы ввели недействительные координаты корабля. Попробуйте еще раз.");
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas2[i, j] == 0)
                    {
                        Console.Write("[ ]");
                    }
                    if (mas2[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[x]");
                        Console.ResetColor();
                    }
                    if (mas2[i, j] == 2)
                    {
                        Console.Write("[o]");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("количество попаданий: " + hitCount);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nистория ходов игрока:");
            foreach (var move in movesHistory)
            {
                Console.WriteLine(move);
            }
            Console.ResetColor();
        }
        Console.Read();
    }
}

class Program
{
    static void Main(string[] args)
    {
        GameField gameField = new GameField();
        gameField.Initialize();
        gameField.DrawField();
        gameField.PlaceShips();
    }
}
