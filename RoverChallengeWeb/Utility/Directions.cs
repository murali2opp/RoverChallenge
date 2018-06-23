using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Extensions
{
    public class Directions
    {
        public const char North = 'N';
        public const char South = 'S';
        public const char East = 'E';
        public const char West = 'W';
        public const char TurnLeft = 'L';
        public const char TurnRight = 'R';

        public static char SetDirection(char currentDirection, char turnLeftOrRight)
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

        private static char GetNewRightDirection(char currentDirection)
        {
            switch (currentDirection)
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

        private static char GetNewLeftDirection(char currentDirection)
        {
            switch (currentDirection)
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