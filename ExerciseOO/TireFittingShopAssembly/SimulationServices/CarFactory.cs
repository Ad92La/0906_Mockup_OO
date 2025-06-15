using VehicleAssembly.Vehicle;

namespace TireFittingShopAssembly.SimulationServices
{
    /// <summary>
    /// Factory service to create an array of cars with random manufacturers for the simulation.
    /// </summary>
    public class CarFactory
    {
        private readonly Random _random = new();

        /// <summary>
        /// Creates the specified number of cars, each with a randomly selected manufacturer.
        /// </summary>
        /// <param name="numVehicles">The number of cars to create.</param>
        /// <returns>Array of Car objects with random manufacturers.</returns>
        public Car[] CreateCars(int numVehicles)
        {
            CarManufacturer[] manufacturers = (CarManufacturer[])Enum.GetValues(typeof(CarManufacturer));
            Car[] cars = new Car[numVehicles];

            for (int i = 0; i < numVehicles; i++)
            {
                // Randomly select a manufacturer for each car
                CarManufacturer randomManufacturer = manufacturers[_random.Next(manufacturers.Length)];
                cars[i] = new Car(randomManufacturer);
            }
            return cars;
        }
    }
}
