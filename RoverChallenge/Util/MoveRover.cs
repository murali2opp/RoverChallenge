using System.Collections.Generic;

namespace RoverChallenge.Util
{
    public class Rover
    {
        public static readonly string InvalidMovementSequence = "Rover moved out of plateau coordinates";
        private const int DefaultMovementUnit = 1;

        private static readonly Dictionary<string, int> MovementUnits = new Dictionary<string, int>
        {
            {"M", 1},
            {"H", 2},
            {"Q", 3}
        };

        public static (int coordinateX, int coordinateY) Move(int currentX, int currentY,
            string currentDirection, string movementUnit)
        {
            var unitsToBeMoved = GetMovementUnit(movementUnit);
            switch (currentDirection.ToUpper())
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

        public static int GetMovementUnit(string movementUnit)
        {
            return MovementUnits.ContainsKey(movementUnit.ToUpper()) ? MovementUnits[movementUnit.ToUpper()] : DefaultMovementUnit;
        }
    }
}