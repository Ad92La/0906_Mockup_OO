using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssembly.Vehicle;

namespace TireFittingShopAssembly.SimulationServices
{
    /// <summary>
    /// Service that encapsulates the logic for processing a customer's tire change.
    /// Controls parallelism using a semaphore and logs all relevant events.
    /// </summary>
    public class TireChangeService
    {
        private readonly SemaphoreSlim _tireChangingSemaphore;
        private readonly Random _random;
        private readonly Action<string> _logAction;

        /// <summary>
        /// Initializes the tire change service.
        /// </summary>
        /// <param name="tireChangingSemaphore">Semaphore to control parallel tire changes.</param>
        /// <param name="random">Random instance for simulating change durations.</param>
        /// <param name="logAction">Delegate for logging events.</param>
        public TireChangeService(SemaphoreSlim tireChangingSemaphore, Random random, Action<string> logAction)
        {
            _tireChangingSemaphore = tireChangingSemaphore;
            _random = random;
            _logAction = logAction;
        }

        /// <summary>
        /// Simulates the tire change process for a single customer.
        /// Waits for a semaphore slot, simulates the work, and logs the process.
        /// Exceptions are caught and logged; the semaphore is always released.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <param name="car">The car whose tires are to be changed.</param>
        public void ProcessCustomer(int customerId, Car car)
        {
            try
            {
                _tireChangingSemaphore.Wait();

                int changingTime = _random.Next(2000, 5001);

                _logAction($"Customer {customerId} car tires are being changed and it will take {(changingTime / 1000.0):0.0} seconds.\n");
                Thread.Sleep(changingTime);

                WinterTire winterTire = new WinterTire();
                car.ChangeTire(winterTire);

                _logAction($"Customer {customerId} has left. \n");

            }
            catch (Exception e)
            {
                _logAction($"Error processing customer {customerId}: {e}");
            }
            finally
            {
                _tireChangingSemaphore.Release();
            }
            
        }
    }
}
