

namespace VehicleAssembly.Vehicle
{ 
    public class Motorcycle : IVehicle
    {
        private readonly string _manufacturer;
        
        public Motorcycle(Manufacturer manufacturer)
        {             
            _manufacturer = manufacturer.ToString();
        }

        public void ShowInformation()
        {
            Console.WriteLine($"Driving a motorcycle from {_manufacturer}"); ;
        }
    }
}