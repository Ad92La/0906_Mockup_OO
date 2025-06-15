namespace VehicleAssembly.Vehicle
{
    /// <summary>
    /// Class to represent a car which implements the vehicle interface.
    /// </summary>
    public class Car : IVehicle
    {
        private readonly string _manufacturer;
        private Tire _tire;

        /// <summary>
        /// Initializes a new car with the specified manufacturer and a default summer tire.
        /// </summary>
        /// <param name="manufacturer">The car manufacturer.</param>
        public Car(CarManufacturer manufacturer)
        {
            _manufacturer = manufacturer.ToString();
            _tire = new SummerTire(); // Default tire type
        }

        /// <inheritdoc/>
        public void ShowInformation()
        {
            Console.Write($"Driving a car from {_manufacturer}. ");
            Console.WriteLine(_tire.GetTireInfo());
        }

        /// <summary>
        /// Changes the tire of the car.
        /// </summary>
        /// <param name="newTire">The new tire to be installed.</param>
        public void ChangeTire(Tire newTire)
        {
            _tire = newTire;
        }
    }
}