using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocsk
{
    struct Object
    {
        public int x;
        public int y;
        public char c;
        public ConsoleColor color;
    }
    static void PrintObject(int x, int y, char c, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
    static void PrintString(int x, int y, string c, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
    static void Main()
    {
        int counter = 0;
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 30;
        List<Object> objects = new List<Object>();
        Object user = new Object();
        user.x = 5;
        user.y = Console.WindowWidth - 1;
        user.c = '(';
        user.color = ConsoleColor.Gray;
        Object user1 = new Object();
        user1.x = 6;
        user1.y = Console.WindowWidth - 1;
        user1.c = 'O';
        user1.color = ConsoleColor.Gray;
        Object user2 = new Object();
        user2.x = 7;
        user2.y = Console.WindowWidth - 1;
        user2.c = ')';
        user2.color = ConsoleColor.Gray;
        Random randomGenerator = new Random();
        int playfield = 28;
        PrintObject(user.x, user.y, user.c, user.color);
        PrintObject(user1.x, user1.y, user1.c, user1.color);
        PrintObject(user2.x, user2.y, user2.c, user2.color);
        while (true)
        {
            {
                int chance = randomGenerator.Next(0, 99);
                int length = randomGenerator.Next(1, 3);
                int colorChance = randomGenerator.Next(0, 3);
                int position = randomGenerator.Next(0, playfield);
                int symbolChance = randomGenerator.Next(0, 11);
                char symbol = 'a';
                switch (symbolChance)
                {
                    case 0: symbol = '^'; break;
                    case 1: symbol = '@'; break;
                    case 2: symbol = '*'; break;
                    case 3: symbol = '&'; break;
                    case 4: symbol = '+'; break;
                    case 5: symbol = '%'; break;
                    case 6: symbol = '$'; break;
                    case 7: symbol = '#'; break;
                    case 8: symbol = '!'; break;
                    case 9: symbol = '.'; break;
                    case 10: symbol = ';'; break;
                    case 11: symbol = '-'; break;
                }
                ConsoleColor objectColor = new ConsoleColor();
                switch (colorChance)
                {
                    case 0: objectColor = ConsoleColor.Cyan; break;
                    case 1: objectColor = ConsoleColor.Red; break;
                    case 2: objectColor = ConsoleColor.Yellow; break;
                }
                if (chance > 20)
                {
                    for (int i = 0; i < length; i++)
                    {
                        Object newObject = new Object();
                        newObject.color = objectColor;
                        newObject.x = position + i;
                        newObject.y = 0;
                        newObject.c = symbol;
                        objects.Add(newObject);
                    }
                }
            }
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (user.x - 1 >= 0)
                    {
                        user.x--;
                        user1.x--;
                        user2.x--;
                    }
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (user2.x + 1 <= playfield)
                    {
                        user.x++;
                        user1.x++;
                        user2.x++;
                    }
                }
            }
            PrintObject(user.x, user.y, user.c, user.color);
            PrintObject(user1.x, user1.y, user1.c, user1.color);
            PrintObject(user2.x, user2.y, user2.c, user2.color);
            List<Object> newList = new List<Object>();
            for (int i = 0; i < objects.Count; i++)
            {
                Object oldObject = objects[i];
                Object newObject = new Object();
                newObject.x = oldObject.x;
                newObject.y = oldObject.y + 1;
                newObject.c = oldObject.c;
                newObject.color = oldObject.color;
                if (newObject.y == user.y && newObject.x == user.x)
                {
                    PrintString(8, 10, "Game over", ConsoleColor.Red);
                    PrintString(8, 11, "Your score is:" + counter, ConsoleColor.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                if (newObject.y == user1.y && newObject.x == user1.x)
                {
                    PrintString(8, 10, "Game over", ConsoleColor.Red);
                    PrintString(8, 11, "Your score is:" + counter, ConsoleColor.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                if (newObject.y == user2.y && newObject.x == user2.x)
                {
                    PrintString(8, 10, "Game over", ConsoleColor.Red);
                    PrintString(8, 11, "Your score is:" + counter, ConsoleColor.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                if (newObject.y < Console.WindowHeight)
                    newList.Add(newObject);
                else counter++;
            }
            objects = newList;
            for (int i = 0; i < objects.Count; i++)
            {
                Object rock = objects[i];
                PrintObject(rock.x, rock.y, rock.c, rock.color);
            }
            Thread.Sleep(150);
            Console.Clear();
        }
    }
}


