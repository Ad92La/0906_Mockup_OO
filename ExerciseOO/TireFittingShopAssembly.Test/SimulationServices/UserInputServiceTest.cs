using System;
using System.IO;
using TireFittingShopAssembly.SimulationServices;
using Xunit;

namespace TireFittingShopAssembly.Test.SimulationServices
{
    /// <summary>
    /// Unit tests for the <see cref="UserInputService"/>.
    /// Verifies that only valid positive integers are accepted as input.
    /// </summary>
    public class UserInputServiceTest
    {
        /// <summary>
        /// Checks that a valid positive integer is accepted as input.
        /// </summary>
        [Fact]
        public void GetPositiveInt_ReturnsValidInput()
        {
            // Simulate user input "5"
            var input = new StringReader("5\n");
            Console.SetIn(input);
            var service = new UserInputService();
            int result = service.GetPositiveInt("Enter number: ");
            Assert.Equal(5, result);
        }

        /// <summary>
        /// Checks that invalid input is rejected and valid input is eventually accepted.
        /// </summary>
        [Fact]
        public void GetPositiveInt_RejectsInvalidAndAcceptsValidInput()
        {
            // Simulate user input: -1 (invalid), abc (invalid), 3 (valid)
            var input = new StringReader("-1\nabc\n3\n");
            Console.SetIn(input);
            var service = new UserInputService();
            int result = service.GetPositiveInt("Enter number: ");
            Assert.Equal(3, result);
        }
    }
}