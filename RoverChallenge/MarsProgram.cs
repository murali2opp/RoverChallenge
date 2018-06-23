using System;
using System.Collections.Generic;
using RoverChallenge.Models;
using RoverChallenge.Util;

namespace RoverChallenge
{
    public class MarsProgram
    {
        public static void Main()
        {
            Console.WriteLine("Welcome Martian!!! Please guide our rovers. Just enter a blank line when all rover inputs are finished!!!");

            string input;
            var martianInputs = new List<string>();
            do
            {
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                    martianInputs.Add(input);
            } while (!string.IsNullOrEmpty(input));

            BeginProcessing(martianInputs);
            
            Console.ReadKey();
        }

        public static void BeginProcessing(List<string> martianInputs)
        {
            try
            {
                ValidateMartinaInputs(martianInputs);

                var plateauCoverageInput = PlateauCoverageInputProcessor.Process(martianInputs);
                foreach (var rover in plateauCoverageInput.Rovers)
                {

                    Console.WriteLine(SetRoverToAction(plateauCoverageInput.PlateauMaxCoordinates, rover));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ValidateMartinaInputs(List<string> martianInputs)
        {
            if (martianInputs.Count == 0)
                throw new Exception("Coordinates missing !!!");

            if (martianInputs.Count == 1)
                throw new Exception("No Rovers to Navigate !!!");

            if (martianInputs.Count % 2 == 0)
                throw new Exception("Rover Movement sequence missing !!!");

            //// TODO: Can further validate the rover first line input, but it is a weekend for me. So Rover, I entrust my faith on you. :)
        }

        private static string SetRoverToAction(Coordinates plateauMaxCoordinates, RoverInputs roverInput)
        {
            var newCoordinateX = roverInput.CurrentCoordinate.CoordinateX;
            var newCoordinateY = roverInput.CurrentCoordinate.CoordinateY;
            var newDirection = roverInput.CurrentDirection.ToUpper();
            foreach (var sequence in roverInput.MovementSequence)
            {
                var movement = sequence.ToString().ToUpper();
                if (movement == Directions.TurnRight || movement == Directions.TurnLeft)
                {
                    newDirection = Directions.SetDirection(newDirection, movement);
                    continue;
                }

                try
                {
                    (newCoordinateX, newCoordinateY) = Rover.Move(newCoordinateX, newCoordinateY, newDirection, movement);
                    if (newCoordinateX > plateauMaxCoordinates.CoordinateX || newCoordinateX < 0 ||
                        newCoordinateY > plateauMaxCoordinates.CoordinateY || newCoordinateY < 0)
                    {
                        throw new Exception(Rover.InvalidMovementSequence);
                    }
                }
                catch (Exception e)
                {
                    return new RoverFinalLocation(newCoordinateX, newCoordinateY, Rover.InvalidMovementSequence)
                        .ToDisplayString();
                }
                
            }

            return new RoverFinalLocation(newCoordinateX, newCoordinateY, newDirection).ToDisplayString();
        }
    }
}