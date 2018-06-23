using System;
using System.Text;

namespace RoverChallenge.Util
{
    public class Directions
    {
        public const string North = "N";
        public const string South = "S";
        public const string East = "E";
        public const string West = "W";
        public const string TurnLeft = "L";
        public const string TurnRight = "R";

        public static string SetDirection(string currentDirection, string turnLeftOrRight)
        {
            switch (turnLeftOrRight)
            {
                case TurnLeft:
                    return GetNewLeftDirection(currentDirection);
                case TurnRight:
                    return GetNewRightDirection(currentDirection);
                default:
                    return currentDirection;
            }
        }

        private static string GetNewRightDirection(string currentDirection)
        {
            switch (currentDirection.ToUpper())
            {
                case North:
                    return East;
                case East:
                    return South;
                case South:
                    return West;
                case West:
                    return North;
                default:
                    return currentDirection;
            }
        }

        private static string GetNewLeftDirection(string currentDirection)
        {
            switch (currentDirection.ToUpper())
            {
                case North:
                    return West;
                case West:
                    return South;
                case South:
                    return East;
                case East:
                    return North;
                default:
                    return currentDirection;
            }
        }
    }
}