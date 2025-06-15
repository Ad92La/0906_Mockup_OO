using VehicleAssembly.Vehicle;
using Xunit;

namespace VehicleAssembly.Test.Vehicle
{
    /// <summary>
    /// Unit tests for the <see cref="Motorcycle"/> class.
    /// </summary>
    public class MotorcycleTests
    {
        /// <summary>
        /// Verifies that the constructor sets the manufacturer correctly.
        /// </summary>
        [Fact]
        public void Constructor_SetsManufacturer()
        {
            var motorcycle = new Motorcycle(MotorcycleManufacturer.KTM);

            // Access private field _manufacturer via reflection for test verification
            var manufacturerField = typeof(Motorcycle).GetField("_manufacturer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.Equal("KTM", manufacturerField?.GetValue(motorcycle));
        }
    }
}