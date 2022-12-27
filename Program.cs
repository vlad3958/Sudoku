using System;

namespace Sudoku
{
    class MainGame
    {
        static Random rnd = new Random();
        public static int[,] map = new int[9, 9];

        enum eDir
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        static eDir dir;
        static int x = 0, y = 0;

        static string[,] mapNew = new string[9, 9];
        private static string f;
        public Constructor constructor;

        public static string Start()
        {
            Console.SetWindowSize(200, 50);

            string s =
                "\t\t █████████████████████████████████████████████████████████████████████████████████████████████\n" +
                "\t\t █░░░░░░░░░░░░░░█░░░░░░██░░░░░░█░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░█░░░░░░██░░░░░░█\n" +
                "\t\t █░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀░░█░░▄▀░░██░░▄▀░░█\n" +
                "\t\t █░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░▄▀▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░░░█░░▄▀░░██░░▄▀░░█\n" +
                "\t\t █░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░███░░▄▀░░██░░▄▀░░█\n" +
                "\t\t █░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░███░░▄▀░░██░░▄▀░░█\n" +
                "\t\t █░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░███░░▄▀░░██░░▄▀░░█\n" +
                "\t\t █░░░░░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░███░░▄▀░░██░░▄▀░░█\n" +
                "\t\t █████████░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░███░░▄▀░░██░░▄▀░░█\n" +
                "\t\t █░░░░░░░░░░▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░░░▄▀▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░░░█░░▄▀░░░░░░▄▀░░█\n" +
                "\t\t █░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█\n" +
                "\t\t █░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░█░░░░░░░░░░░░░░█\n" +
                "\t\t █████████████████████████████████████████████████████████████████████████████████████████████\n";
            Console.Write(s);

            Console.WriteLine("\t\t    " +
                              "Do you want to play the game or make yours Sudoku? ( 0 - make game, any other key - play)");
            f = Console.ReadLine();

            return f;
        }


        public static void Generate()
        {
            Console.WriteLine("\t\t\t\t\tChoose the level of difficulty (from 1 to 3)");
            int level = int.Parse(Console.ReadLine());
            Console.Clear();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
                }
            }

            int[,] tempMap = new int[9, 9];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    tempMap[i, j] = map[j, i];
                }
            }

            map = tempMap;


            var block = rnd.Next(0, 3);
            var row1 = rnd.Next(0, 3);
            var line1 = block * 3 + row1;
            var row2 = rnd.Next(0, 3);
            while (row1 == row2)
                row2 = rnd.Next(0, 3);
            var line2 = block * 3 + row2;
            for (int i = 0; i < 9; i++) //перемешивание строк в блоке
            {
                var temp = map[line1, i];
                map[line1, i] = map[line2, i];
                map[line2, i] = temp;
            }

            var blockNew = rnd.Next(0, 3);
            var row1New = rnd.Next(0, 3);
            var line1New = blockNew * 3 + row1New;
            var row2New = rnd.Next(0, 3);
            while (row1New == row2New)
                row2New = rnd.Next(0, 3);
            var line2New = blockNew * 3 + row2New;
            for (int i = 0; i < 9; i++) //перемешивание столбцов в блоке
            {
                var tempNew = map[i, line1New];
                map[i, line1New] = map[i, line2New];
                map[i, line2New] = tempNew;
            }

            var block1 = rnd.Next(0, 3);
            var block2 = rnd.Next(0, 3);
            while (block1 == block2)
                block2 = rnd.Next(0, 3);
            block1 *= 3;
            block2 *= 3;
            for (int i = 0; i < 9; i++)
            {
                //перемешивание блоков по горизонтали
                var k = block2;
                for (int j = block1; j < block1 + 3; j++)
                {
                    var temp = map[j, i];
                    map[j, i] = map[k, i];
                    map[k, i] = temp;
                    k++;
                }
            }

            var block1New = rnd.Next(0, 3);
            var block2New = rnd.Next(0, 3);
            while (block1New == block2New)
                block2New = rnd.Next(0, 3);
            block1New *= 3;
            block2New *= 3;
            for (int i = 0; i < 9; i++)
            {
                //перемешивание блоков по вертикали
                var k = block2New;
                for (int j = block1New; j < block1New + 3; j++)
                {
                    var temp1 = map[i, j];
                    map[i, j] = map[i, k];
                    map[i, k] = temp1;
                    k++;
                }
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    int a = rnd.Next(0, 20);
                    switch (level)
                    {
                        case 1:
                            if (a <= 6)
                            {
                                if (i == y && j == x)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(" " + "|");
                                    mapNew[i, j] = " " + "|";
                                    Console.BackgroundColor = ConsoleColor.White;

                                }
                                else
                                    Console.Write(" " + "|");

                                mapNew[i, j] = " " + "|";
                            }
                            else
                            {
                                if (i == y && j == x)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(map[i, j] + "|");
                                    mapNew[i, j] = map[i, j] + "|";
                                    Console.BackgroundColor = ConsoleColor.White;
                                }
                                else
                                    Console.Write(map[i, j] + "|");

                                mapNew[i, j] = map[i, j] + "|";
                            }

                            break;
                        case 2:
                            if (a <= 9)
                            {
                                if (i == y && j == x)
                                {

                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(" " + "|");
                                    mapNew[i, j] = " " + "|";
                                    Console.BackgroundColor = ConsoleColor.White;

                                }
                                else
                                    Console.Write(" " + "|");

                                mapNew[i, j] = " " + "|";

                            }
                            else
                            {
                                if (i == y && j == x)
                                {

                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(map[i, j] + "|");
                                    mapNew[i, j] = map[i, j] + "|";
                                    Console.BackgroundColor = ConsoleColor.White;

                                }
                                else
                                    Console.Write(map[i, j] + "|");

                                mapNew[i, j] = map[i, j] + "|";

                            }

                            break;
                        case 3:
                            if (a <= 13)
                            {
                                if (i == y && j == x)
                                {

                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(" " + "|");
                                    mapNew[i, j] = " " + "|";
                                    Console.BackgroundColor = ConsoleColor.White;

                                }
                                else
                                    Console.Write(" " + "|");

                                mapNew[i, j] = " " + "|";

                            }
                            else
                            {
                                if (i == y && j == x)
                                {

                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(map[i, j] + "|");
                                    mapNew[i, j] = map[i, j] + "|";
                                    Console.BackgroundColor = ConsoleColor.White;

                                }
                                else
                                    Console.Write(map[i, j] + "|");

                                mapNew[i, j] = map[i, j] + "|";

                            }

                            break;

                    }
                }

                Console.WriteLine();
            }
        }

        static int count = 0;

        public static void DrawLevel()
        {
            Console.Clear();

            for (int i = 0; i < mapNew.GetLength(0); i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\t\t\t\t\t\t\t");
                for (int j = 0; j < mapNew.GetLength(1); j++)
                {

                    if (i == y && j == x)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write(mapNew[i, j]);

                        if (j == 2 || j == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  |");
                        }

                        if (i == 2 && j == 8 || i == 5 && j == 8)
                        {
                            Console.WriteLine();
                        }

                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(mapNew[i, j]);
                        if (j == 2 || j == 5)
                        {
                            Console.Write("  |");
                        }

                        if (i == 2 && j == 8 || i == 5 && j == 8)
                        {
                            Console.WriteLine();
                        }
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                }
                Console.WriteLine();
            }
Console.ResetColor();
            Console.WriteLine("\n\t\t\t\t\t\t\tpress WASD keys to move");
        }

        public static void Input()
        {
            count = 0;
            var button = Console.ReadKey(true);
            if (!int.TryParse(button.KeyChar.ToString(), out var k))
            {
                switch (button.KeyChar)
                {
                    case 'w':
                        dir = eDir.UP;
                        break;
                    case 'a':
                        dir = eDir.LEFT;
                        break;
                    case 's':
                        dir = eDir.DOWN;
                        break;
                    case 'd':
                        dir = eDir.RIGHT;
                        break;
                }

                Logic();
            }
            else
            {
                Console.Clear();

                for (int i = 0; i < mapNew.GetLength(0); i++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("\t\t\t\t\t\t\t");
                    for (int j = 0; j < mapNew.GetLength(1); j++)
                    {

                        if (i == y && j == x)
                        {
                            mapNew[i, j] = button.Key.ToString().Replace("D", "") + "|";

                            if (mapNew[i, j] == map[i, j].ToString() + "|")
                            {

                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write(mapNew[i, j]);
                                if (j == 2 || j == 5)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.Write("  |");
                                }

                                if (i == 2 && j == 8 || i == 5 && j == 8)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.WriteLine();
                                }
                            }
                            else if (mapNew[i, j] != map[i, j].ToString() + "|")
                            {

                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write(mapNew[i, j]);
                                if (j == 2 || j == 5)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.Write("  |");
                                }

                                if (i == 2 && j == 8 || i == 5 && j == 8)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.WriteLine();
                                }
                            }

                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(mapNew[i, j]);
                            if (j == 2 || j == 5)
                            {
                                Console.Write("  |");
                            }

                            if (i == 2 && j == 8 || i == 5 && j == 8)
                            {
                                Console.WriteLine();
                            }

                            Console.BackgroundColor = ConsoleColor.White;
                        }
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
                Console.WriteLine("\n\t\t\t\t\t\t\tpress WASD keys to move");
                Win();
                if(count!=81)
                Input();
            }
        }
        public static void Win()
        {
            for (int p = 0; p < 9; p++)
            {
                for (int l = 0; l < 9; l++)
                {
                    if (mapNew[p, l].Replace(" ", null).Replace("  |", null).Replace("|", null)
                            .Replace(" " + "|", null) == map[p, l].ToString())
                    {
                        count++;
                    }
                }
            }
        }

        public static void Logic()
        {
            switch (dir)
            {
                case eDir.LEFT:
                    x--;
                    break;
                case eDir.RIGHT:
                    x++;
                    break;
                case eDir.UP:
                    y--;
                    break;
                case eDir.DOWN:
                    y++;
                    break;
            }
        }

        static void Main()
        {
            Start();
            if (f == "0")
            {
                Constructor.Run();
            }

            Generate();
            while (true)
            {
                DrawLevel();
                Input();
               
                if (count == 81)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n"+"\t\t\t\t\t\t\t\t"+"You won!");
                    Console.BackgroundColor = ConsoleColor.White;
                   
                    break;
                }
            }

        }
    }
}

