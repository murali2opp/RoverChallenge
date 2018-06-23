using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Extensions;
using MarsRover.Models;
using Microsoft.AspNetCore.Mvc;
using Rover = MarsRover.Extensions.Rover;

namespace MarsRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavigateRoverController : ControllerBase
    {
        [HttpPost]
        [Produces(typeof(IEnumerable<RoverFinalLocation>))]
        public IActionResult Post(
            [FromBody] PlateauCoverageInput plateauCoverageInput)
        {
            var roverLocations = plateauCoverageInput.Rovers.Select(rover =>
                MoveRover(plateauCoverageInput.PlateauMaxCoordinates, rover)).ToList();

            return Ok(roverLocations);
        }


        private static RoverFinalLocation MoveRover(Coordinates plateauMaxCoordinates, RoverInputs roverInput)
        {
            var newCoordinateX = roverInput.CurrentCoordinate.CoordinateX;
            var newCoordinateY = roverInput.CurrentCoordinate.CoordinateY;
            var newDirection = roverInput.CurrentDirection;
            foreach (var movement in roverInput.MovementSequence)
            {
                if (movement == Directions.TurnRight || movement == Directions.TurnLeft)
                {
                    newDirection = Directions.SetDirection(newDirection, movement);
                    continue;
                }

                (newCoordinateX, newCoordinateY) = Rover.Move(newCoordinateX, newCoordinateY, newDirection, movement);
                if (newCoordinateX > plateauMaxCoordinates.CoordinateX || newCoordinateX < 0 ||
                    newCoordinateY > plateauMaxCoordinates.CoordinateY || newCoordinateY < 0)
                {
                    return new RoverFinalLocation(newCoordinateX, newCoordinateY, Rover.InvalidMovementSequence);
                }
            }

            return new RoverFinalLocation(newCoordinateX, newCoordinateY, newDirection);
        }
    }
}