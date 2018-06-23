using System;
using System.Collections.Generic;
using Xunit;

namespace RoverChallenge.Test
{
    public class InputUnitTests
    {
        [Fact]
        public void ValidInputs()
        {
            var inputs = new List<string>
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };
            MarsProgram.BeginProcessing(inputs);
        }

        [Fact]
        public void RoverMovesOutOfPlateauCoordinates()
        {
            var inputs = new List<string>
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "5 5 E",
                "MMRMMRMRRM"
            };
            MarsProgram.BeginProcessing(inputs);
        }

        [Fact]
        public void CheckPlateauBoundaryLimits_ShouldProcess()
        {
            var inputs = new List<string>
            {
                "2147483647 2147483647",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };
            MarsProgram.BeginProcessing(inputs);
        }

        [Fact]
        public void CheckPlateauBoundaryLimits_ShouldFail()
        {
            var inputs = new List<string>
            {
                "2147483648 2147483648",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };
            MarsProgram.BeginProcessing(inputs);
        }

        [Fact]
        public void CheckPlateauBoundaryLimits_ShouldFail2()
        {
            var inputs = new List<string>
            {
                "0 0",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };
            MarsProgram.BeginProcessing(inputs);
        }
    }
}
