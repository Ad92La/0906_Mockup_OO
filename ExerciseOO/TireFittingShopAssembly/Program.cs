using System;
using VehicleAssembly.Vehicle;

namespace TireFittingShopAssembly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create vehicles using the Manufacturer enum
            IVehicle myCar = new Car(Manufacturer.Honda);
            IVehicle myBike = new Motorcycle(Manufacturer.Honda);

            myCar.ShowInformation();
            myBike.ShowInformation();

            // Create a Honda car and show info
            Car hondaCar = new Car(Manufacturer.Honda);
            hondaCar.ShowInformation();

            // Change tires to winter tires (all 4)
            var winterTires = new WinterTire();

            hondaCar.ChangeTire(winterTires);
            hondaCar.ShowInformation();
        }
    }
}
