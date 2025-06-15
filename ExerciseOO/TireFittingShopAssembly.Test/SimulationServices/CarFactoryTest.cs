using TireFittingShopAssembly.SimulationServices;
using VehicleAssembly.Vehicle;
using Xunit;

namespace TireFittingShopAssembly.Test.SimulationServices
{
    /// <summary>
    /// Unit tests for the <see cref="CarFactory"/> service.
    /// Verifies that cars are created correctly and manufacturers are valid.
    /// </summary>
    public class CarFactoryTest
    {
        /// <summary>
        /// Ensures that the factory creates the correct number of cars.
        /// </summary>
        [Fact]
        public void CreateCars_CreatesCorrectNumberOfCars()
        {
            var factory = new CarFactory();
            int num = 5;
            var cars = factory.CreateCars(num);
            Assert.Equal(num, cars.Length);
        }

        /// <summary>
        /// Ensures that all created cars have a valid manufacturer.
        /// </summary>
        [Fact]
        public void CreateCars_AssignsValidManufacturers()
        {
            var factory = new CarFactory();
            var cars = factory.CreateCars(10);
            var validManufacturers = new[] { "Honda", "Toyota" };
            foreach (var car in cars)
            {
                // Access private field _manufacturer via reflection for test verification
                var manufacturerField = typeof(Car).GetField("_manufacturer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var manufacturer = manufacturerField?.GetValue(car)?.ToString();
                Assert.Contains(manufacturer, validManufacturers);
            }
        }
    }
}
