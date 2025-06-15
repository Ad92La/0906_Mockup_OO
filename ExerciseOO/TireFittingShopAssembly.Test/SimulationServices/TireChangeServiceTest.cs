using System;
using System.Threading;
using TireFittingShopAssembly.SimulationServices;
using VehicleAssembly.Vehicle;
using Xunit;

namespace TireFittingShopAssembly.Test.SimulationServices
{
    /// <summary>
    /// Unit tests for the <see cref="TireChangeService"/>.
    /// Verifies correct tire change logic and logging.
    /// </summary>
    public class TireChangeServiceTest
    {
        [Fact]
        public void ProcessCustomer_ChangesTireAndLogs()
        {
            var semaphore = new SemaphoreSlim(1);
            var random = new Random(42); // Seed for deterministic test
            string log = "";
            void Log(string msg) => log += msg;

            var car = new Car(CarManufacturer.Honda);
            var service = new TireChangeService(semaphore, random, Log);

            service.ProcessCustomer(1, car);

            // Check that log contains start and end messages
            Assert.Contains("Customer 1 car tires are being changed", log);
            Assert.Contains("Customer 1 has left", log);

            // Check that the tire is now a WinterTire
            var tireField = typeof(Car).GetField("_tire", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.IsType<WinterTire>(tireField?.GetValue(car));
        }
    }
}
