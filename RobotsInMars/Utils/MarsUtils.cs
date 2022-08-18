using System.Collections.Generic;

namespace RobotsInMars.Utils
{
    public static class MarsUtils
    {
        public static bool CheckValidCoordinates(string[] coordinates)
        {
            if (coordinates.Length == 2 && AreCoordinatesNumbersAndValidValue(coordinates))
            {
                return true;
            }

            return false;
        }

        public static bool AreCoordinatesNumbersAndValidValue(string[] coordinates)
        {
            if ((int.TryParse(coordinates[0], out _)) && (int.TryParse(coordinates[1], out _)))
            {
                if (int.Parse(coordinates[0]) <= 50 && int.Parse(coordinates[1]) <= 50) return true;
            }
            return false;
        }

        public static bool CheckValidRobotPosition(string[] robotPosition, string[] coordinates)
        {
            if (robotPosition.Length == 3 && AreRobotCoordinatesInsideMars(robotPosition, coordinates))
            {
                return true;
            }

            return false;
        }

        public static bool AreRobotCoordinatesInsideMars(string[] robotPosition, string[] coordinates)
        {
            bool isValidOrientation = false;
            bool isValidPosition = false;

            if ((int.TryParse(coordinates[0], out _)) && (int.TryParse(coordinates[1], out _)))
            {
                if ((int.Parse(robotPosition[0]) <= int.Parse(coordinates[0]) &&
                    int.Parse(robotPosition[1]) <= int.Parse(coordinates[1])) &&
                    (int.Parse(robotPosition[0]) >= 0 && int.Parse(robotPosition[1]) >= 0)) isValidPosition = true;
            }

            switch (robotPosition[2])
            {
                case "N":
                case "E":
                case "S":
                case "W":
                    isValidOrientation = true;
                    break;

            }
            if (isValidOrientation && isValidPosition)
            {
                return true;
            }
            return false;
        }

    }
}
