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
        
        public bool IsCellAlive(int neighbours)
        {
            return !(neighbours > 3 || neighbours < 2);
        }

        
        public bool IsCellAlive()
        {
            int neighbours = 0;
            for (int i = 0; i < 22*30; i++)
            {
                Cell c = World.GetWorld()[i];
                if(c != null && IsNeighbour(c))
                {
                    neighbours++;
                }
            }

            return IsCellAlive(neighbours);
        }        

        public int DetermineNumberOfNeighbours()
        {
            int neighbours = 0;
            for (int i = 0; i < 22*30; i++)
            {
                Cell c = World.GetWorld()[i];
                if (c != null && IsNeighbour(c))
                {
                    neighbours++;
                }                
            }
            return neighbours;
        }

        public bool IsNeighbour(Cell cell)
        {
            bool result = false;
            double sqDistance = Math.Pow(X - cell.X, 2) + Math.Pow(Y - cell.Y, 2);
            if (sqDistance <= 2 && sqDistance > 0)
            {
                result = true;
            }
            return result;
        }


        public bool IsNotPresentInWorld()
        {
            bool result = true;
            for (int i = 0; i < 22*30; i++)
            {
                Cell c = World.GetWorld()[i];
                if(c != null && c.X == X && c.Y == Y)
                {
                    result = false;
                }                
            }
            return result;
        }

        public bool IsNotPresentInList(List<Cell> cellsList)
        {
            return cellsList.Count(cell => (X == cell.X) && (Y == cell.Y)) == 0;
        }

        public List<Cell> GetNeighbours()
        {
            List<Cell> neighbourList = new List<Cell>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    Cell newCell = new Cell(X + i, Y + j);
                    if (newCell.IsNeighbour(this))
                    {
                        neighbourList.Add(newCell);
                    }
                }
            }
            return neighbourList;
        }
    }
}
