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
        public List<string> Map { get; private set; }
        private (int, int) characterCoordinates;

        public Game(string mapPath)
        {
            using (var streamReader = new StreamReader(mapPath))
            {
                Map = new List<string>();

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Map.Add(line);
                }

                CheckMap();
                FindCharacter();
            }
        }

        private bool IsWall(int x, int y) => Map[x][y] == 'N';

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
            for (var x = 0; x < Map.Count; ++x)
            {
                var y = Map[x].IndexOf('@');

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
            for (var i = 0; i < Map.Count; ++i)
            {
                for (var j = 0; j < Map[i].Length; ++j)
                {
                    if (Map[i][j] != ' ' && Map[i][j] != '@' && Map[i][j] != 'N')
                    {
                        throw new FormatException("There are invalid symbols on the map.");
                    }
                    if (Map[i][j] == '@')
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

        /// <summary>
        /// Prints the map.
        /// </summary>
        public void PrintMap()
        {
            Console.Clear();

            for (var i = 0; i < Map.Count; ++i)
            {
                Console.WriteLine(Map[i]);
            }
        }
    }
}
