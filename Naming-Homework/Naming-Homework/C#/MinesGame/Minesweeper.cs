using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper;

namespace Minesweeper
{
    public class Minesweeper
    {
        private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] field = CreateField();
            char[,] bombs = SetBombs();
            int counter = 0;
            bool explosion = false;
            List<Rating> champions = new List<Rating>(6);
            int row = 0;
            int column = 0;
            bool isFirstGame = true;
            const int max = 35;
            bool haveWon = false;

            do
            {
                if (isFirstGame)
                {
                    Console.WriteLine("Let's play \"Minesweeper\". Try to find all fields without mines."
                        + " Use 'top' command to see the ratings, 'restart' command to start a new "
                        + "game and 'exit' command to quit!");
                    CreateBoard(field);
                    isFirstGame = false;
                }

                Console.Write("Write row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowRatings(champions);
                        break;
                    case "restart":
                        field = CreateField();
                        bombs = SetBombs();
                        CreateBoard(field);
                        explosion = false;
                        isFirstGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                HandleGameTurn(field, bombs, row, column);
                                counter++;
                            }

                            if (max == counter)
                            {
                                haveWon = true;
                            }
                            else
                            {
                                CreateBoard(field);
                            }
                        }
                        else
                        {
                            explosion = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! invalid command\n");
                        break;
                }

                if (explosion)
                {
                    CreateBoard(bombs);
                    Console.Write("\nHrrrrrr! You died like a hero with {0} points. " + "Write your nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Rating lastGameRating = new Rating(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(lastGameRating);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < lastGameRating.Points)
                            {
                                champions.Insert(i, lastGameRating);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Rating r1, Rating r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    champions.Sort((Rating r1, Rating r2) => r2.Points.CompareTo(r1.Points));
                    ShowRatings(champions);

                    field = CreateField();
                    bombs = SetBombs();
                    counter = 0;
                    explosion = false;
                    isFirstGame = true;
                }

                if (haveWon)
                {
                    Console.WriteLine("\nCongratulations! You opened all boxes!.");
                    CreateBoard(bombs);
                    Console.WriteLine("Write your nickname: ");
                    string name = Console.ReadLine();
                    Rating points = new Rating(name, counter);
                    champions.Add(points);
                    ShowRatings(champions);
                    field = CreateField();
                    bombs = SetBombs();
                    counter = 0;
                    haveWon = false;
                    isFirstGame = true;
                }
            }
            while (command != "exit");
            {
                Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
                Console.Read();
            }
        }

        private static void ShowRatings(List<Rating> ratings)
        {
            Console.WriteLine("\nPoints:");
            if (ratings.Count > 0)
            {
                for (int i = 0; i < ratings.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, ratings[i].PlayerName, ratings[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty!\n");
            }
        }

        private static void HandleGameTurn(char[,] field, char[,] bombs, int row, int column)
        {
            char minesCount = GetMinesCountAroundPosition(bombs, row, column);
            bombs[row, column] = minesCount;
            field[row, column] = minesCount;
        }

        private static void CreateBoard(char[,] board)
        {
            int rowsCount = board.GetLength(0);
            int columnsCount = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rowsCount; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columnsCount; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] SetBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] field = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> bombsList = new List<int>();
            while (bombsList.Count < 15)
            {
                Random random = new Random();
                int position = random.Next(50);
                if (!bombsList.Contains(position))
                {
                    bombsList.Add(position);
                }
            }

            foreach (int bomb in bombsList)
            {
                int col = bomb / columns;
                int row = bomb % columns;
                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                field[col, row - 1] = '*';
            }

            return field;
        }

        private static void SetFieldNumbers(char[,] field)
        {
            int column = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char minesCount = GetMinesCountAroundPosition(field, i, j);
                        field[i, j] = minesCount;
                    }
                }
            }
        }

        private static char GetMinesCountAroundPosition(char[,] field, int row, int col)
        {
            int minesCount = 0;
            int fieldHeight = field.GetLength(0);
            int fieldWidth = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < fieldHeight)
            {
                if (field[row + 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (col + 1 < fieldWidth)
            {
                if (field[row, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < fieldWidth))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < fieldHeight) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < fieldHeight) && (col + 1 < fieldWidth))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}