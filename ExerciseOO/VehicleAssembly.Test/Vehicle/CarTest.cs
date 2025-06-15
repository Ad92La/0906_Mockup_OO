using VehicleAssembly.Vehicle;
using Xunit;

namespace VehicleAssembly.Test.Vehicle
{
    /// <summary>
    /// Unit tests for the <see cref="Car"/> class.
    /// </summary>
    public class CarTests
    {
        /// <summary>
        /// Verifies that the constructor sets the manufacturer and default tire correctly.
        /// </summary>
        [Fact]
        public void Constructor_SetsManufacturerAndDefaultTire()
        {
            var car = new Car(CarManufacturer.Honda);
            Assert.NotNull(car);

            // Access private field _manufacturer via reflection for test verification
            var manufacturerField = typeof(Car).GetField("_manufacturer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.Equal("Honda", manufacturerField?.GetValue(car));

            // Access private field _tire via reflection for test verification
            var tireField = typeof(Car).GetField("_tire", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.NotNull(tireField?.GetValue(car));
            Assert.IsType<SummerTire>(tireField?.GetValue(car));
        }

        /// <summary>
        /// Verifies that ChangeTire updates the tire reference.
        /// </summary>
        [Fact]
        public void ChangeTire_UpdatesTire()
        {
            var car = new Car(CarManufacturer.Toyota);
            var newTire = new WinterTire();
            car.ChangeTire(newTire);

            var tireField = typeof(Car).GetField("_tire", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.Same(newTire, tireField?.GetValue(car));
        }
    }
}   
