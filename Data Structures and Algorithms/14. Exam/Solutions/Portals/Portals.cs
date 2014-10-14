namespace Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Portals
    {
        public const string ImpassableSymbol = "#";

        // 25 Points ..........
        public static void Main()
        {
            // Read start cell position
            var startPositionString = Console.ReadLine();
            var startPosition = startPositionString.Split(' ');

            var startCell = new Cell<int>(
                    int.Parse(startPosition[0]),
                    int.Parse(startPosition[1])
                );

            // Visited cells hashset
            var visitedCells = new HashSet<Cell<int>>();

            // Read labyrinth dimensions
            var labyrinthDimensionsString = Console.ReadLine();
            var labyrinthDimensions = labyrinthDimensionsString.Split(' ');
            var rows = int.Parse(labyrinthDimensions[0]);
            var columns = int.Parse(labyrinthDimensions[1]);

            // Read labyrinth content
            var labyrinth = ReadLabyrinth(rows, columns, visitedCells);

            // DFS - Finds the maximal power, which can be used in the labyrinth
            var result = Dfs(labyrinth, startCell, visitedCells);
            Console.WriteLine(result);
        }

        private static string[,] ReadLabyrinth(int rows, int columns, HashSet<Cell<int>> visitedCells)
        {
            var labyrinth = new string[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine().Split(' ');

                for (int c = 0; c < columns; c++)
                {
                    // line[c]
                    labyrinth[r, c] = line[c];

                    // Mark impassable cells as visited to avoid additional checks in the DFS
                    if (labyrinth[r, c] == ImpassableSymbol)
                    {
                        visitedCells.Add(new Cell<int>(r, c));
                    }
                }
            }

            return labyrinth;
        }

        private static int Dfs(string[,] labyrinth, Cell<int> startCell, HashSet<Cell<int>> visitedCells)
        {
            int maximalPower = 0;

            var stack = new Stack<Cell<int>>();
            stack.Push(startCell);

            visitedCells.Add(startCell);

            var rows = labyrinth.GetLength(0);
            var columns = labyrinth.GetLength(1);
            
            while (stack.Count > 0)
            {
                var currentCell = stack.Pop();

                var currentCellPower = int.Parse(labyrinth[currentCell.Row, currentCell.Column]);
                if (currentCellPower == 0)
                {
                    break;
                }

                maximalPower += currentCellPower;

                // Calculate best next step
                var possibleSteps = new SortedDictionary<int, Cell<int>>();

                // Left -> Column--
                if (currentCell.Column - currentCellPower >= 0)
                {
                    var newCell = new Cell<int>(currentCell.Row, currentCell.Column - currentCellPower);
                    if (!visitedCells.Contains(newCell))
                    {
                        var newCellPower = int.Parse(labyrinth[newCell.Row, newCell.Column]);
                        if (!possibleSteps.ContainsKey(newCellPower))
                        {
                            possibleSteps.Add(newCellPower, newCell);
                        }
                    }
                }

                // Right -> Column ++
                if (currentCell.Column + currentCellPower <= columns - 1)
                {
                    var newCell = new Cell<int>(currentCell.Row, currentCell.Column + currentCellPower);
                    if (!visitedCells.Contains(newCell))
                    {
                        var newCellPower = int.Parse(labyrinth[newCell.Row, newCell.Column]);
                        if (!possibleSteps.ContainsKey(newCellPower))
                        {
                            possibleSteps.Add(newCellPower, newCell);
                        }
                    }
                }

                // Down -> Row--
                if (currentCell.Row - currentCellPower >= 0)
                {
                    var newCell = new Cell<int>(currentCell.Row - currentCellPower, currentCell.Column);
                    if (!visitedCells.Contains(newCell))
                    {
                        var newCellPower = int.Parse(labyrinth[newCell.Row, newCell.Column]);
                        if (!possibleSteps.ContainsKey(newCellPower))
                        {
                            possibleSteps.Add(newCellPower, newCell);
                        }
                    }
                }

                // Up -> Row++
                if (currentCell.Row + currentCellPower <= rows - 1)
                {
                    var newCell = new Cell<int>(currentCell.Row + currentCellPower, currentCell.Column);
                    if (!visitedCells.Contains(newCell))
                    {
                        var newCellPower = int.Parse(labyrinth[newCell.Row, newCell.Column]);
                        if (!possibleSteps.ContainsKey(newCellPower))
                        {
                            possibleSteps.Add(newCellPower, newCell);
                        }
                    }
                }

                if (possibleSteps.Count > 0)
                {
                    var newCell = possibleSteps.Last().Value;
                    stack.Push(newCell);
                    visitedCells.Add(newCell);
                }
            }

            return maximalPower;
        }
    }

    public class Cell<T>
    {
        public Cell(T row, T column)
        {
            this.Row = row;
            this.Column = column;
        }

        public T Row { get; set; }

        public T Column { get; set; }

        public override bool Equals(object obj)
        {
            var otherCell = obj as Cell<T>;
            if (otherCell == null)
            {
                return false;
            }

            return
                this.Row.Equals(otherCell.Row) &&
                this.Column.Equals(otherCell.Column);
        }

        public override int GetHashCode()
        {
            return this.Row.GetHashCode() ^
                this.Column.GetHashCode();
        }
    }
}
