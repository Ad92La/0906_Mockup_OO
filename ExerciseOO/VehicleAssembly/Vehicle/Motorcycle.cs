namespace VehicleAssembly.Vehicle
{
    /// <summary>
    /// Represents a motorcycle which implements the vehicle interface.
    /// </summary>
    public class Motorcycle : IVehicle
    {
        private readonly string _manufacturer;

        /// <summary>
        /// Initializes a new motorcycle with the specified manufacturer.
        /// </summary>
        /// <param name="manufacturer">The motorcycle manufacturer.</param>
        public Motorcycle(MotorcycleManufacturer manufacturer)
        {
            _manufacturer = manufacturer.ToString();
        }

        /// <inheritdoc/>
        public void ShowInformation()
        {
            Console.WriteLine($"Driving a motorcycle from {_manufacturer}.");
        }
    }
}