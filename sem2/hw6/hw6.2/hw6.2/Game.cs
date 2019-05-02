using System;
using System.Collections.Generic;
using System.IO;

namespace hw6._2
{
    /// <summary>
    /// 
    /// </summary>
    public class Game
    {
        private readonly List<string> map;
        private (int, int) playerCoordinates;

        public Game(string mapPath)
        {
            using (var streamReader = new StreamReader(mapPath))
            {
                Console.CursorVisible = false;
                Console.WriteLine("Welcome to my game!");
                Console.WriteLine("Use arrow keys to move the character.");
                Console.WriteLine("If you want to exit game, press Esc.");
                Console.WriteLine("Press Enter to start.");

                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Press Enter to start!");
                }

                map = new List<string>();

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    map.Add(line);
                }

                Console.Clear();
                PrintMap();
                FindPlayer();
            }
        }

        private bool IsWall(int x, int y) => map[x][y] == 'N';

        public void OnUp(object sender, EventArgs args)
        {
            var (x, y) = playerCoordinates;

            if (!IsWall(x - 1, y))
            {
                Console.CursorTop = x;
                Console.CursorLeft = y;
                Console.Write(' ');

                playerCoordinates.Item1 = --Console.CursorTop;
                playerCoordinates.Item2 = --Console.CursorLeft;
                Console.Write('@');
            }
        }

        public void OnDown(object sender, EventArgs args)
        {
            var (x, y) = playerCoordinates;

            if (!IsWall(x + 1, y))
            {
                Console.CursorTop = x;
                Console.CursorLeft = y;
                Console.Write(' ');

                playerCoordinates.Item1 = ++Console.CursorTop;
                playerCoordinates.Item2 = --Console.CursorLeft;
                Console.Write('@');
            }
        }

        public void OnLeft(object sender, EventArgs args)
        {
            var (x, y) = playerCoordinates;

            if (!IsWall(x, y - 1))
            {
                Console.CursorTop = x;
                Console.CursorLeft = y;
                Console.Write(' ');

                playerCoordinates.Item1 = Console.CursorTop;
                Console.CursorLeft -= 2;
                playerCoordinates.Item2 = Console.CursorLeft;
                Console.Write('@');
            }
        }

        public void OnRight(object sender, EventArgs args)
        {
            var (x, y) = playerCoordinates;

            if (!IsWall(x, y + 1))
            {
                Console.CursorTop = x;
                Console.CursorLeft = y;
                Console.Write(' ');

                playerCoordinates.Item1 = Console.CursorTop;
                playerCoordinates.Item2 = Console.CursorLeft;
                Console.Write('@');
            }
        }

        private void FindPlayer()
        {
            for (var x = 0; x < map.Count; ++x)
            {
                var y = map[x].IndexOf('@');

                if (y != -1)
                {
                    playerCoordinates = (x, y);
                    return;
                }
            }

            throw new FormatException();
        }

        private void PrintMap()
        {
            Console.Clear();

            for (var i = 0; i < map.Count; ++i)
            {
                Console.WriteLine(map[i]);
            }
        }
    }
}
