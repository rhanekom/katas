using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public static bool IsCellAlive(int neighbours)
        {
            return !(neighbours > 3 || neighbours < 2);
        }
        
        public static bool IsCellAlive(Cell cell)
        {
            int neighbours = 0;

            for (int i = 0; i < 22*30; i++)
            {
                Cell neighbour = World.GetWorld()[i];
                if(neighbour != null && IsNeighbour(neighbour, cell))
                {
                    neighbours++;
                }
            }

            return IsCellAlive(neighbours);
        }        

        public static int GetNumberOfNeighbours(Cell cell)
        {
            int neighbours = 0;
            for (int i = 0; i < 22*30; i++)
            {
                Cell neighbour = World.GetWorld()[i];
                if (neighbour != null && IsNeighbour(neighbour, cell))
                {
                    neighbours++;
                }                
            }
            return neighbours;
        }

        public static bool IsNeighbour(Cell potentialNeighbour, Cell focus)
        {
            bool result = false;
            double sqDistance = Math.Pow(focus.X - potentialNeighbour.X, 2) + Math.Pow(focus.Y - potentialNeighbour.Y, 2);
            if (sqDistance <= 2 && sqDistance > 0)
            {
                result = true;
            }
            return result;
        }


        public static bool IsNotPresentInWorld(Cell needle)
        {
            bool result = true;
            for (int i = 0; i < 22*30; i++)
            {
                Cell cell = World.GetWorld()[i];
                if(cell != null && cell.X == needle.X && cell.Y == needle.Y)
                {
                    result = false;
                }                
            }
            return result;
        }

        public static bool IsNotPresentInList(List<Cell> haystack, Cell needle)
        {
            return haystack.Count(cell => (needle.X == cell.X) && (needle.Y == cell.Y)) == 0;
        }

        public static List<Cell> GetNeighbours(Cell focus)
        {
            var neighbourList = new List<Cell>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var newCell = new Cell(focus.X + i, focus.Y + j);
                    if (IsNeighbour(focus, newCell))
                    {
                        neighbourList.Add(newCell);
                    }
                }
            }

            return neighbourList;
        }
    }
}
