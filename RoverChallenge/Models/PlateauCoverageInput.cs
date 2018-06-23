using System.Collections.Generic;

namespace RoverChallenge.Models
{
    public class PlateauCoverageInput
    {
        public Coordinates PlateauMaxCoordinates { get; set; }
        public IEnumerable<RoverInputs> Rovers { get; set; }
    }

    public class Coordinates
    {
        public Coordinates(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
    }

    public class RoverInputs
    {
        public RoverInputs(int coordinateX, int coordinateY, string currentDirection, string movementSequence)
        {
            CurrentCoordinate = new Coordinates(coordinateX, coordinateY);
            CurrentDirection = currentDirection;
            MovementSequence = movementSequence;
        }
        public Coordinates CurrentCoordinate { get; set; }
        public string CurrentDirection { get; set; }
        public string MovementSequence { get; set; }
    }

    public class RoverFinalLocation
    {
        public RoverFinalLocation(int coordinateX, int coordinateY, string finishedDirection)
        {
            FinishedCoordinate = new Coordinates(coordinateX, coordinateY);
            FinishedDirection = finishedDirection;
        }
        public Coordinates FinishedCoordinate { get; set; }
        public string FinishedDirection { get; set; }
        public string ToDisplayString()=> $"{FinishedCoordinate.CoordinateX} {FinishedCoordinate.CoordinateY} {FinishedDirection}";
    }
}