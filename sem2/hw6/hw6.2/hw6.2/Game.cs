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
        public List<List<char>> Map { get; private set; }
        private (int, int) characterCoordinates;
        private (int, int) previousCoordinates;

        public Game(string mapPath)
        {
            using (var streamReader = new StreamReader(mapPath))
            {
                Map = new List<List<char>>();

                string line;
                int temp = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Map.Add(new List<char>());
                    for (var i = 0; i < line.Length; ++i)
                    {
                        Map[temp].Add(line[i]);
                    }

                    ++temp;
                }

                CheckMap();
                FindCharacter();
            }
        }

        private bool IsWall(int x, int y) => Map[x][y] == 'N';

        private bool IsEndOfMap(int x, int y) => x < 0 || y < 0 || Map.Count <= x || Map[x].Count <= y;

        /// <summary>
        /// Moves character up.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="args">Empty parameter.</param>
        public void OnUp(object sender, EventArgs args)
        {
            var (x, y) = characterCoordinates;

            if (IsEndOfMap(x - 1, y))
            {
                return;
            }

            if (!IsWall(x - 1, y))
            {
                Map[x][y] = ' ';

                previousCoordinates = characterCoordinates;
                characterCoordinates.Item1 = x - 1;
                Map[x - 1][y] = '@';
            }
            else
            {
                throw new CrashingIntoWallException();
            }
        }

        /// <summary>
        /// Moves character down.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="args">Empty parameter.</param>
        public void OnDown(object sender, EventArgs args)
        {
            var (x, y) = characterCoordinates;

            if (IsEndOfMap(x + 1, y))
            {
                return;
            }

            if (!IsWall(x + 1, y))
            {
                Map[x][y] = ' ';

                previousCoordinates = characterCoordinates;
                characterCoordinates.Item1 = x + 1;
                Map[x + 1][y] = '@';
            }
            else
            {
                throw new CrashingIntoWallException();
            }
        }

        /// <summary>
        /// Moves character left.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="args">Empty parameter.</param>
        public void OnLeft(object sender, EventArgs args)
        {
            var (x, y) = characterCoordinates;

            if (IsEndOfMap(x, y - 1))
            {
                return;
            }

            if (!IsWall(x, y - 1))
            {
                Map[x][y] = ' ';

                previousCoordinates = characterCoordinates;
                characterCoordinates.Item2 = y - 1;
                Map[x][y - 1] = '@';
            }
            else
            {
                throw new CrashingIntoWallException();
            }
        }

        /// <summary>
        /// Moves character right.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="args">Empty parameter.</param>
        public void OnRight(object sender, EventArgs args)
        {
            var (x, y) = characterCoordinates;

            if (IsEndOfMap(x, y + 1))
            {
                return;
            }

            if (!IsWall(x, y + 1))
            {
                Map[x][y] = ' ';

                previousCoordinates = characterCoordinates;
                characterCoordinates.Item2 = y + 1;
                Map[x][y + 1] = '@';
            }
            else
            {
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
                for (var j = 0; j < Map[i].Count; ++j)
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
                            throw new FormatException("There are more than one character on the map.");
                        }
                    }
                }
            }
            if (!checkCharacter)
            {
                throw new FormatException("There is no character on the map.");
            }
        }

        /// <summary>
        /// Updates map on the console after the change of character location .
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="args">Empty parameter.</param>
        public void ChangeMap(object sender, EventArgs args)
        {
            var (x, y) = previousCoordinates;

            Console.CursorTop = x;
            Console.CursorLeft = y - 1;

            if (!IsEndOfMap(x, y - 1))
            {
                Console.Write(Map[x][y - 1]);
            }
            else
            {
                Console.CursorTop = x;
                Console.CursorLeft = y;
            }
            Console.Write(Map[x][y]);

            if (!IsEndOfMap(x, y + 1))
            {
                Console.Write(Map[x][y + 1]);
            }

            Console.CursorTop = x - 1;
            Console.CursorLeft = y;

            if (!IsEndOfMap(x - 1, y))
            {
                Console.Write(Map[x - 1][y]);
            }

            Console.CursorTop = x + 1;
            Console.CursorLeft = y;

            if (!IsEndOfMap(x + 1, y))
            {
                Console.Write(Map[x + 1][y]);
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
                for (var j = 0; j < Map[i].Count; ++j)
                {
                    Console.Write(Map[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
