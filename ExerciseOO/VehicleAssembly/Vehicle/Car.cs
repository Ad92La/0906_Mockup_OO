
namespace VehicleAssembly.Vehicle { 
    public class Car : IVehicle
    {
        private readonly string _manufacturer;
        private Tire _tire;

        public Car(Manufacturer manufacturer)
        {
            _manufacturer = manufacturer.ToString();
            _tire = new SummerTire(); // Default tire type
        }

        public void ShowInformation()
        {
            Console.WriteLine($"Driving a car from {_manufacturer}.");
            Console.WriteLine($"Current tire: {_tire.GetTireInfo()}");
        }

        public void ChangeTire(Tire newTire)
        {
            _tire = newTire;
            Console.WriteLine($"Changed tire to: {_tire.GetTireInfo()}");
        }


    }
    
}