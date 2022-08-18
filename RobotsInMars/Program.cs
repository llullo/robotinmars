using RobotsInMars.Models;
using RobotsInMars.Utils;
using System;
using System.Collections.Generic;

namespace RobotsInMars
{
    class Program
    {

        private static string[] _coordinates;
        private static Robot _robot = new Robot();
        private static List<Robot> _listOfRobots = new List<Robot>();
        private static List<string> _lastValidsCoordenates = new List<string>();
        static void Main(string[] args)
        {            
            while (true)
            {
                if (!(_coordinates.Length > 0)) {
                    ReadCoordinates();
                } else
                {

                }
               
                                                
            }
        }

        private static void ReadCoordinates()
        {
            string consoleValue;
            Console.WriteLine("Welcome to Mars! please put the maximum coordinates");
            consoleValue = Console.ReadLine();
            Console.WriteLine(consoleValue);
            string[] splittedConsoleValue = consoleValue.Split(" ");
            if (MarsUtils.CheckValidCoordinates(splittedConsoleValue) && consoleValue.Length < 100)
            {
                _coordinates = splittedConsoleValue;
                ReadRobotPosition();
            }

        }

        private static void ReadRobotPosition()
        {
            Console.WriteLine("Now enter the position of the robot");
            string robotPosition = Console.ReadLine();
            string[] splittedRobotPosition = robotPosition.Split(" ");
            if (MarsUtils.CheckValidRobotPosition(splittedRobotPosition, _coordinates) && robotPosition.Length < 100)
            {
                _robot.CoordinateX = int.Parse(splittedRobotPosition[0]);
                _robot.CoordinateY = int.Parse(splittedRobotPosition[1]);
                _robot.Orientation = splittedRobotPosition[3];

            }
        }

        private static void ReadRobotInstruccions()
        {
            Console.WriteLine("Now enter the sequence of instruccions you want the robot to follow");

        }

        private static void AddLastValidCoordenate(Robot robot)
        {
            string coordinateX = robot.CoordinateX.ToString();
            string coordinateY = robot.CoordinateY.ToString();

            switch (robot.Orientation)
            {
                case "N":
                    coordinateY = (robot.CoordinateY - 1).ToString();
                    break;
                case "E":
                    coordinateX = (robot.CoordinateX - 1).ToString();
                    break;
                case "S":
                    coordinateY = (robot.CoordinateY + 1).ToString();
                    break;
                case "W":
                    coordinateX = (robot.CoordinateX + 1).ToString();
                    break;
            }

            _lastValidsCoordenates.Add(coordinateX + "," + coordinateY);
        }

        
    }
}
