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
            bool continueLoop = true;
            while (continueLoop)
            {
                if (_coordinates == null || !(_coordinates.Length > 0))
                {
                    ReadCoordinates();
                }
                else if (_robot.Orientation == null || _robot.Orientation.Length == 0)
                {
                    ReadRobotPosition();
                } else
                {
                    ReadRobotInstructions();
                }
                            
                Console.WriteLine("Do you want to program another robot / put the correct coordenates(any key), list all the robots(L) or exit(E)?");
                string nextMoveConsole = Console.ReadLine().ToUpper();

                switch (nextMoveConsole)
                {
                    case "L":                    
                        ListAllRobots();
                        break;
                    case "E":                    
                        continueLoop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ReadCoordinates()
        {
            string consoleValue;
            Console.WriteLine("Welcome to Mars! please put the maximum coordinates");
            consoleValue = Console.ReadLine().TrimEnd().TrimStart().ToUpper();
            string[] splittedConsoleValue = consoleValue.TrimEnd().TrimStart().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (MarsUtils.CheckValidCoordinates(splittedConsoleValue) && consoleValue.Length < 100)
            {
                _coordinates = splittedConsoleValue;
                ReadRobotPosition();
            }
        }

        private static void ReadRobotPosition()
        {
            Console.WriteLine("Now enter the position of the robot");
            string robotPosition = Console.ReadLine().TrimEnd().TrimStart().ToUpper();
            string[] splittedRobotPosition = robotPosition.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (MarsUtils.CheckValidRobotPosition(splittedRobotPosition, _coordinates) && robotPosition.Length < 100)
            {
                _robot.CoordinateX = int.Parse(splittedRobotPosition[0]);
                _robot.CoordinateY = int.Parse(splittedRobotPosition[1]);
                _robot.Orientation = splittedRobotPosition[2];
                ReadRobotInstructions();
            }
        }

        private static void ReadRobotInstructions()
        {
            Console.WriteLine("Now enter the sequence of instructions you want the robot to follow");
            string instructions = Console.ReadLine().Trim().ToUpper();
            if (instructions.Length >= 100) return;
            bool addedValidCoordenate = false;

            for (int i = 0; i < instructions.Length; i++)
            {
                switch (instructions[i])
                {
                    case 'L':
                        _robot.MoveLeft();
                        break;
                    case 'R':
                        _robot.MoveRight();
                        break;
                    case 'F':
                        _robot.MoveForward(_lastValidsCoordenates);
                        _robot.CheckValidPosition(_coordinates);
                        if (_robot.IsLost && !addedValidCoordenate) {
                            AddLastValidCoordenate(_robot);
                            addedValidCoordenate = true;
                            };
                        break;
                    default:
                        break;
                }               
            }
            _listOfRobots.Add(_robot);
            _robot = new Robot();
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

            _lastValidsCoordenates.Add(coordinateX + "," + coordinateY  + "," + robot.Orientation);
        }

        private static void ListAllRobots()
        {
            foreach (Robot robot in _listOfRobots)
            {
                string robotMessage = robot.CoordinateX + " " + robot.CoordinateY + " " + robot.Orientation + (robot.IsLost ? " LOST" : "");
                Console.WriteLine(robotMessage);
            }

            Console.WriteLine("Do you want to exit? (E) or program another robot?(any key)");
            string consoleValue = Console.ReadLine();
            if (consoleValue.ToUpper().Equals("E")) Environment.Exit(0);
        }


    }
}
