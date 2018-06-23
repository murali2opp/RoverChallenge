using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RoverChallenge.Models;

namespace RoverChallenge.Util
{
    public class PlateauCoverageInputProcessor
    {
        public static PlateauCoverageInput Process(List<string> martianInputs)
        {
            var maxCoordinates = GetMaxCoordinates(martianInputs[0]);
            var roverInputs = new List<RoverInputs>();

            GetRoverInputs(martianInputs, roverInputs);

            return new PlateauCoverageInput
            {
                Rovers = roverInputs,
                PlateauMaxCoordinates = maxCoordinates
            };
        }

        private static void GetRoverInputs(List<string> martianInputs, List<RoverInputs> roverInputs)
        {
            if(roverInputs.Count %2 == 0 || martianInputs.Count == 1)
                throw new Exception("Rovers Input Corrupted");
            for (var roverIndex = 1; roverIndex < martianInputs.Count; roverIndex = roverIndex + 2)
            {
                var roverPosition = martianInputs[roverIndex].Trim().Split(' ');
                var roverInput = new RoverInputs(Convert.ToInt32(roverPosition[0]), Convert.ToInt32(roverPosition[1]),
                    roverPosition[2],
                    martianInputs[roverIndex + 1]);
                roverInputs.Add(roverInput);
            }
        }

        private static Coordinates GetMaxCoordinates(string firstLineOfMartianInput)
        {
            var maxCoordinates = firstLineOfMartianInput.Trim().Split(' ');
            if (maxCoordinates.Length != 2)
                throw new InvalidDataException("Invalid Plateau Coordinates");
            int.TryParse(maxCoordinates[0], out int maxCoordinateX);
            int.TryParse(maxCoordinates[1], out int maxCoordinateY);

            if (maxCoordinateX <= 0 || maxCoordinateY <= 0)
                throw new InvalidDataException("Invalid Plateau Coordinates");

            return new Coordinates(maxCoordinateX, maxCoordinateY);
        }
    }
}