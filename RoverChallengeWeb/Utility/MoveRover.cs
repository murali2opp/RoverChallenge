using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Extensions
{
    public class Rover
    {
        public const char InvalidMovementSequence = '@';
        private const int DefaultMovementUnit = 1;

        private static readonly Dictionary<char, int> MovementUnits = new Dictionary<char, int>
        {
            {'M', 1},
            {'H', 2},
            {'Q', 3}
        };

        public static (int coordinateX, int coordinateY) Move(int currentX, int currentY,
            char currentDirection, char movementUnit)
        {
            var unitsToBeMoved = GetMovementUnit(movementUnit);
            switch (currentDirection)
            {
                case Directions.East:
                    return (currentX + unitsToBeMoved, currentY);
                case Directions.West:
                    return (currentX - unitsToBeMoved, currentY);
                case Directions.North:
                    return (currentX, currentY + unitsToBeMoved);
                case Directions.South:
                    return (currentX, currentY - unitsToBeMoved);
                default:
                    return (currentX, currentY);
            }
        }

        public static int GetMovementUnit(char movementUnit)
        {
            return MovementUnits.ContainsKey(movementUnit) ? MovementUnits[movementUnit] : DefaultMovementUnit;
        }
    }
}