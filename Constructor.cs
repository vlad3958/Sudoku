using System.Runtime.CompilerServices;

namespace Sudoku;

public class Constructor
{
   
        static string[,] mapCon =
        new string[9, 9];
        enum eDir
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        static eDir dir;
        static int x =
        0, y = 0;

        public static void Construct()
        {
            Console.Clear();
            for (int i = 0; i < mapCon.GetLength(0); i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\t\t\t\t\t\t\t");
                Console.BackgroundColor = ConsoleColor.White;
                for (int j = 0; j < mapCon.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;

                    var a = Console.ReadKey(true);

                    if (a.KeyChar.ToString() == "0")
                    {
                        Console.Write(" " + "|");
                        mapCon[i, j] = mapCon[i, j] + " " + "|";
                        if (j == 2 || j == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  |");
                        }

                        if (i == 2 && j == 8 || i == 5 && j == 8)
                        {
                            Console.WriteLine();
                        }

                        continue;
                    }

                    mapCon[i, j] = a.KeyChar + "|";
                    Console.Write(mapCon[i, j]);
                    if (j == 2 || j == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  |");
                    }

                    if ((i == 2 && j == 8) || (i == 5 && j == 8))
                    {
                        Console.WriteLine();
                    }

                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }

            Console.Clear();
            for (int i = 0; i < mapCon.GetLength(0); i++)
            {
                for (int j = 0; j < mapCon.GetLength(1); j++)
                {
                    Console.Write(mapCon[i, j]);
                }

                Console.WriteLine();
            }
        }


    public static ConsoleKeyInfo a;
   static string[] arrI = new string[9];
   static string[] arrJ = new string[9];
   static string[] block = new string[9];
    public static void Check()
    {
        for (int i = 0; i < mapCon.GetLength(0); i++)
        {
            for (int j = 0; j < mapCon.GetLength(1); j++)
            {
                arrI[j] = mapCon[i, j].Replace("0", null).Replace("|", null).Replace("  |", null).Replace(" ", null);
                arrJ[j] = mapCon[j, i].Replace("0", null).Replace("|", null).Replace("  |", null).Replace(" ", null);
            }
                int r = 0;
                for (int u = 0; u <= 2; u++)
                {
                    for (int t = 0; t <= 2; t++)
                    {
                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                        .Replace("  |", null).Replace(" ", null);
                    r++;
                    }
                }
                Check2();  if(a.KeyChar.ToString()=="y")
                    break;
                r = 0;
               
                for (int u = 0; u <= 2; u++)
                {
                    for (int t = 3; t <= 5; t++)
                    {
                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                            .Replace("  |", null).Replace(" ", null);
                        r++;
                    }
                } Check2(); if(a.KeyChar.ToString()=="y")
                    break;
                r = 0;
                
                for (int u = 0; u <= 2; u++)
                {
                    for (int t = 6; t <= 8; t++)
                    {
                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                            .Replace("  |", null).Replace(" ", null);
                        r++;
                    }
                } Check2(); if(a.KeyChar.ToString()=="y")
                    break;
                r = 0;
                for (int u = 3; u <= 5; u++)
                {
                    for (int t = 0; t <= 2; t++)
                    {
                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                            .Replace("  |", null).Replace(" ", null);
                        r++;
                    }
                } Check2(); if(a.KeyChar.ToString()=="y")
                    break;
                r = 0;
                for (int u = 3; u <= 5; u++)
                {
                    for (int t = 3; t <= 5; t++)
                    {
                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                            .Replace("  |", null).Replace(" ", null);
                        r++;
                    }
                }Check2();  if(a.KeyChar.ToString()=="y")
                    break;
                r = 0;
                for (int u = 3; u <= 5; u++)
                {
                    for (int t = 6; t <= 8; t++)
                    {
                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                            .Replace("  |", null).Replace(" ", null);
                        r++;
                    }
                } Check2(); if(a.KeyChar.ToString()=="y")
                    break;
                r = 0;
                for (int u = 6; u <= 8; u++)
                {
                    for (int t = 0; t <= 2; t++)
                    {
                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                            .Replace("  |", null).Replace(" ", null);
                        r++;
                    }
                } Check2(); if(a.KeyChar.ToString()=="y")
                    break;
                r = 0;
                for (int u = 6; u <= 8; u++)
                {
                    for (int t = 3; t <= 5; t++)
                    {
                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                            .Replace("  |", null).Replace(" ", null);
                        r++;
                    }
                } Check2();if(a.KeyChar.ToString()=="y")
                    break; 
                r = 0;
                for (int u = 6; u <= 8; u++)
                {
                    for (int t = 6; t <= 8; t++)
                    {
                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                            .Replace("  |", null).Replace(" ", null);
                        r++;
                    }
                }   Check2(); if(a.KeyChar.ToString()=="y")
                    break;
              
        }
    }

    public static ConsoleKeyInfo Check2()
    {
        var newblock = string.Concat(block);
        var newarr = string.Concat(arrI);
        var newarrJ = string.Concat(arrJ);

        if (newarr.Length != newarr.Distinct().Count()|| newblock.Length != newblock.Distinct().Count()||newarrJ.Length != newarrJ.Distinct().Count())
        {
            Console.WriteLine("Sudoku contains duplicates");

            Console.WriteLine("Do you want to remake Sudoku?(y/n)");
            a = Console.ReadKey(true);
           
        }
        return a;
    }
    public static void DrawLevel()
    {
        Console.Clear();

        for (int i = 0; i < mapCon.GetLength(0); i++)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t\t\t");
            for (int j = 0; j < mapCon.GetLength(1); j++)
            {

                if (i == y && j == x)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write(mapCon[i, j]);
                    if (j == 2 || j == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  |");
                    }

                    if (i == 2 && j == 8 || i == 5 && j == 8)
                    {
                        Console.WriteLine(" ");
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(mapCon[i, j]);
                    if (j == 2 || j == 5)
                    {
                        Console.Write("  |");
                    }

                    if (i == 2 && j == 8 || i == 5 && j == 8)
                    {
                        Console.WriteLine(" ");
                    }
                }

                Console.BackgroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
        }
    }

    public static void Input()
    {
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

            for (int i = 0; i < mapCon.GetLength(0); i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\t\t\t\t\t\t\t");

                for (int j = 0; j < mapCon.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    if (i == y && j == x)
                    {
                        mapCon[i, j] = button.KeyChar.ToString() + "|";

                        string[] arrI = new string[9];
                        string[] arrJ = new string[9];
                        string[] block = new string[9];
                        for (int l = 0; l < mapCon.GetLength(1); l++)
                        {
                            arrI[l] = mapCon[i, l].Replace("0", null).Replace("|", null).Replace("  |", null)
                                .Replace(" ", null);
                            arrJ[l] = mapCon[l, j].Replace("0", null).Replace("|", null).Replace("  |", null)
                                .Replace(" ", null);
                        }

                        int r = 0;
                        for (int u = 0; u < 9; u++)
                        {
                            for (int t = 0; t < 9; t++)
                            {
                                if (i >= 0 && i <= 2 && j >= 0 && j <= 2)
                                {
                                    if (u >= 0 && u <= 2 && t >= 0 && t <= 2)
                                    {

                                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                                            .Replace("  |", null).Replace(" ", null);
                                        r++;
                                    }
                                }

                                if (i >= 0 && i <= 2 && j >= 3 && j <= 5)
                                {
                                    if (u >= 0 && u <= 2 && t >= 3 && t <= 5)
                                    {

                                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                                            .Replace("  |", null).Replace(" ", null);
                                        r++;
                                    }
                                }

                                if (i >= 0 && i <= 2 && j >= 6 && j <= 8)
                                {
                                    if (u >= 0 && u <= 2 && t >= 6 && t <= 8)
                                    {

                                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                                            .Replace("  |", null).Replace(" ", null);
                                        r++;
                                    }
                                }

                                if (i >= 3 && i <= 5 && j >= 0 && j <= 2)
                                {
                                    if (u >= 3 && u <= 5 && t >= 0 && t <= 2)
                                    {

                                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                                            .Replace("  |", null).Replace(" ", null);
                                        r++;
                                    }
                                }

                                if (i >= 3 && i <= 5 && j >= 3 && j <= 5)
                                {
                                    if (u >= 3 && u <= 5 && t >= 3 && t <= 5)
                                    {

                                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                                            .Replace("  |", null).Replace(" ", null);
                                        r++;
                                    }
                                }

                                if (i >= 3 && i <= 5 && j >= 6 && j <= 8)
                                {
                                    if (u >= 3 && u <= 5 && t >= 6 && t <= 8)
                                    {

                                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                                            .Replace("  |", null).Replace(" ", null);
                                        r++;
                                    }
                                }

                                if (i >= 6 && i <= 8 && j >= 0 && j <= 2)
                                {
                                    if (u >= 6 && u <= 8 && t >= 0 && t <= 2)
                                    {

                                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                                            .Replace("  |", null).Replace(" ", null);
                                        r++;
                                    }
                                }

                                if (i >= 6 && i <= 8 && j >= 3 && j <= 5)
                                {
                                    if (u >= 6 && u <= 8 && t >= 3 && t <= 5)
                                    {

                                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                                            .Replace("  |", null).Replace(" ", null);
                                        r++;
                                    }
                                }

                                if (i >= 6 && i <= 8 && j >= 6 && j <= 8)
                                {
                                    if (u >= 6 && u <= 8 && t >= 6 && t <= 8)
                                    {

                                        block[r] = mapCon[u, t].Replace("0", null).Replace("|", null)
                                            .Replace("  |", null).Replace(" ", null);
                                        r++;
                                    }
                                }

                            }
                        }

                        var newblock = string.Concat(block);
                        var newarr = string.Concat(arrI);
                        var newarrJ = string.Concat(arrJ);

                        if (newarr.Length != newarr.Distinct().Count() ||
                            newarrJ.Length != newarrJ.Distinct().Count() ||
                            newblock.Length != newblock.Distinct().Count())
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else
                            Console.BackgroundColor = ConsoleColor.Green;


                        Console.Write(mapCon[i, j]);
                        if (j == 2 || j == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  |");
                        }

                        if (i == 2 && j == 8 || i == 5 && j == 8)
                        {
                            Console.WriteLine(" ");
                        }

                        Console.BackgroundColor = ConsoleColor.White;

                    }
                    else
                    {
                        Console.Write(mapCon[i, j]);
                        if (j == 2 || j == 5)
                        {
                            Console.Write("  |");
                        }

                        if (i == 2 && j == 8 || i == 5 && j == 8)
                        {
                            Console.WriteLine(" ");
                        }

                        Console.BackgroundColor = ConsoleColor.White;
                    }

                }

                Console.WriteLine();
            }

            Input();
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

    public static void Run()
    {
       
        Construct();
        Check();
        if (a.KeyChar.ToString() == "y")
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    mapCon[i, j] = null;
                }
            }
            Console.Clear();
            Console.ResetColor();
            a = new ConsoleKeyInfo();
            Run();
        }
        while (true)
        {
            DrawLevel();
            Input();
        }
    }
    
}

