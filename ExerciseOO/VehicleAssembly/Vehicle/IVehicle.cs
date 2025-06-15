namespace VehicleAssembly.Vehicle
{
    /// <summary>
    /// Interface for all vehicles to assure the ShowInformation method is implemented.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Displays information about the vehicle.
        /// </summary>
        void ShowInformation();
    }
}
