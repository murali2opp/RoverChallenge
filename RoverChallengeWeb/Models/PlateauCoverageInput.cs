using System.Collections.Generic;

namespace MarsRover.Models
{
    public class PlateauCoverageInput
    {
        public Coordinates PlateauMaxCoordinates { get; set; }
        public IEnumerable<RoverInputs> Rovers { get; set; }
    }

    public class Coordinates
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
    }

    public class RoverInputs
    {
        public Coordinates CurrentCoordinate { get; set; }
        public char CurrentDirection { get; set; }
        public string MovementSequence { get; set; }
    }

    public class RoverFinalLocation
    {
        public RoverFinalLocation(int coordinateX, int coordinateY, char finishedDirection)
        {
            FinishedCoordinate = new Coordinates
            {
                CoordinateX = coordinateX,
                CoordinateY = coordinateY
            };
            FinishedDirection = finishedDirection;
        }

        public Coordinates FinishedCoordinate { get; set; }
        public char FinishedDirection { get; set; }

        public string ToString => $"{FinishedCoordinate.CoordinateX} {FinishedCoordinate.CoordinateY} {FinishedDirection}";
    }
}