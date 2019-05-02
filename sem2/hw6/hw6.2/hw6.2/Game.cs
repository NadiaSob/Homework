using System;
using System.Collections.Generic;
using System.IO;

namespace hw6._2
{
    /// <summary>
    /// Realisation of the game.
    /// </summary>
    public class Game
    {
        private readonly List<string> map;
        private (int, int) characterCoordinates;

        public Game(string mapPath)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Welcome to my game!");
            Console.WriteLine("Use arrow keys to move the character.");
            Console.WriteLine("Try not to crash into walls.");
            Console.WriteLine("If you want to exit game, press Esc.");
            Console.WriteLine("Press Enter to start.");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("Press Enter to start!");
            }

            using (var streamReader = new StreamReader(mapPath))
            {
                map = new List<string>();

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    map.Add(line);
                }

                Console.Clear();
                PrintMap();
                CheckMap();
                FindCharacter();
            }
        }

        private bool IsWall(int x, int y) => map[x][y] == 'N';

        /// <summary>
        /// Moves character up.
        /// </summary>
        /// <param name="sender">Empty object.</param>
        /// <param name="args">Empty parameter.</param>
        public void OnUp(object sender, EventArgs args)
        {
            var (x, y) = characterCoordinates;

            if (!IsWall(x - 1, y))
            {
                Console.CursorTop = x;
                Console.CursorLeft = y;
                Console.Write(' ');

                characterCoordinates.Item1 = --Console.CursorTop;
                characterCoordinates.Item2 = --Console.CursorLeft;
                Console.Write('@');
            }
            else
            {
                Console.Clear();
                throw new CrashingIntoWallException();
            }
        }

        /// <summary>
        /// Moves character down.
        /// </summary>
        /// <param name="sender">Empty object.</param>
        /// <param name="args">Empty parameter.</param>
        public void OnDown(object sender, EventArgs args)
        {
            var (x, y) = characterCoordinates;

            if (!IsWall(x + 1, y))
            {
                Console.CursorTop = x;
                Console.CursorLeft = y;
                Console.Write(' ');

                characterCoordinates.Item1 = ++Console.CursorTop;
                characterCoordinates.Item2 = --Console.CursorLeft;
                Console.Write('@');
            }
            else
            {
                Console.Clear();
                throw new CrashingIntoWallException();
            }
        }

        /// <summary>
        /// Moves character left.
        /// </summary>
        /// <param name="sender">Empty object.</param>
        /// <param name="args">Empty parameter.</param>
        public void OnLeft(object sender, EventArgs args)
        {
            var (x, y) = characterCoordinates;

            if (!IsWall(x, y - 1))
            {
                Console.CursorTop = x;
                Console.CursorLeft = y;
                Console.Write(' ');

                characterCoordinates.Item1 = Console.CursorTop;
                Console.CursorLeft -= 2;
                characterCoordinates.Item2 = Console.CursorLeft;
                Console.Write('@');
            }
            else
            {
                Console.Clear();
                throw new CrashingIntoWallException();
            }
        }

        /// <summary>
        /// Moves character right.
        /// </summary>
        /// <param name="sender">Empty object.</param>
        /// <param name="args">Empty parameter.</param>
        public void OnRight(object sender, EventArgs args)
        {
            var (x, y) = characterCoordinates;

            if (!IsWall(x, y + 1))
            {
                Console.CursorTop = x;
                Console.CursorLeft = y;
                Console.Write(' ');

                characterCoordinates.Item1 = Console.CursorTop;
                characterCoordinates.Item2 = Console.CursorLeft;
                Console.Write('@');
            }
            else
            {
                Console.Clear();
                throw new CrashingIntoWallException();
            }
        }

        private void FindCharacter()
        {
            for (var x = 0; x < map.Count; ++x)
            {
                var y = map[x].IndexOf('@');

                if (y != -1)
                {
                    characterCoordinates = (x, y);
                    return;
                }
            }

            throw new FormatException("The сharacter is not found.");
        }

        private void CheckMap()
        {
            bool checkCharacter = false;
            for (var i = 0; i < map.Count; ++i)
            {
                for (var j = 0; j < map[i].Length; ++j)
                {
                    if (map[i][j] != ' ' && map[i][j] != '@' && map[i][j] != 'N')
                    {
                        throw new FormatException("There are invalid symbols on the map.");
                    }
                    if (map[i][j] == '@')
                    {
                        if (!checkCharacter)
                        {
                            checkCharacter = true;
                        }
                        else
                        {
                            throw new FormatException("There is more than one character on the map.");
                        }
                    }
                }
            }
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
