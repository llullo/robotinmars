using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsInMars.Models
{
    public class Robot
    {
        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public string Orientation { get; set; }

        public bool IsLost { get; set; }

        public void MoveLeft()
        {
            switch (Orientation)
            {
                case "N":
                    Orientation = "W";
                    break;
                case "E":
                    Orientation = "N";
                    break;
                case "S":
                    Orientation = "E";
                    break;
                case "W":
                    Orientation = "S";
                    break;
            }
        }

        public void MoveRight()
        {
            switch (Orientation)
            {
                case "N":
                    Orientation = "E";
                    break;
                case "E":
                    Orientation = "S";
                    break;
                case "S":
                    Orientation = "W";
                    break;
                case "W":
                    Orientation = "N";
                    break;
            }
        }

        public void MoveForward(List<string> lastValidCoordinates)
        {
            bool stopAdvance = false;
            foreach (string validCoordinate in lastValidCoordinates)
            {
                int validCoordinateX = int.Parse(validCoordinate.Split(",")[0]);
                int validCoordinateY = int.Parse(validCoordinate.Split(",")[1]);

                if (CoordinateX == validCoordinateX && CoordinateY == validCoordinateY && Orientation == validCoordinate.Split(",")[2])
                {
                    stopAdvance = true;
                    break;
                }
            }

            if (stopAdvance) return;
            switch (Orientation)
            {
                case "N":
                    CoordinateY++;
                    break;
                case "E":
                    CoordinateX++;
                    break;
                case "S":
                    CoordinateY--;
                    break;
                case "W":
                    CoordinateX--;
                    break;
            }
        }

        public bool CheckValidPosition(string[] coordinates)
        {
            if ((CoordinateX >= 0 && CoordinateY >= 0) && (CoordinateX <= int.Parse(coordinates[0]) && CoordinateY <= int.Parse(coordinates[1])))
            {
                return true;
            } else
            {
                IsLost = true;
                return false;
            }
        }
    }
}
