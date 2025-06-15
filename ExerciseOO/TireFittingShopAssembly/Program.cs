using System;
using System.Diagnostics;
using TireFittingShopAssembly.SimulationServices;
using VehicleAssembly.Vehicle;

namespace TireFittingShopAssembly
{
    /// <summary>
    /// Entry point for the tire fitting shop simulation.
    /// Initializes all services, creates vehicles, and manages the parallel processing of customers.
    /// The simulation uses a semaphore to control the maximum number of parallel tire changes.
    /// </summary>
    internal class Program
    {
        // Semaphore to control the number of parallel tire changes
        static SemaphoreSlim? tireChangingSemaphore;

        // Shared random number generator for simulation timing
        static readonly Random random = new();

        // Stopwatch to measure and log simulation time
        static Stopwatch? stopwatch;

        /// <summary>
        /// Main entry point. Orchestrates the simulation workflow.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(".......... Start Simulation setup .............");
                // Service for validated user input (number of vehicles and parallel customers)
                var userInputService = new UserInputService();

                int numVehicles = userInputService.GetPositiveInt("Please enter the number of cars you want to change the tires on: ");
                int numCustomersParallel = userInputService.GetPositiveInt("Please enter the number of customers you want to serve in parallel: ");

                // Controls the maximum number of customers being served in parallel
                tireChangingSemaphore = new SemaphoreSlim(numCustomersParallel);

                Console.WriteLine("........... Start Simulation ............");
                Console.WriteLine($"Number of vehicles: {numVehicles}, Number of customers served in parallel: {numCustomersParallel}");

                // Headers for the console output
                Console.WriteLine("\nTimestamp (s) \t Message");

                // List to keep track of all running customer tasks
                List<Task> arrivingCustomers = new List<Task>();

                // Factory to create the required number of cars with random manufacturers base on user-input
                var vehicleFactory = new CarFactory();
                Car[] cars = vehicleFactory.CreateCars(numVehicles);

                // Start the stopwatch
                stopwatch = Stopwatch.StartNew();

                // Logger for timestamped console output
                var loggingService = new LoggingService(stopwatch);

                // Service to handle the tire changing logic, including semaphore usage and logging
                var tireChangeService = new TireChangeService(tireChangingSemaphore, random, loggingService.Log);

                // Start a task for each customer/vehicle
                for (int i = 0; i < numVehicles; i++)
                {
                    int customerId = i + 1;
                    Car car = cars[i];

                    loggingService.Log($"Customer {customerId} has arrived. ");
                    car.ShowInformation();

                    // Each customer is processed in a separate Task
                    var customerTask = Task.Run(() => tireChangeService.ProcessCustomer(customerId, car));
                    arrivingCustomers.Add(customerTask);

                    // Simulate random arrival intervals between customers
                    Thread.Sleep(random.Next(0, 1001));
                }

                // Wait for all customer tasks to complete before finishing the simulation
                Task.WaitAll([.. arrivingCustomers]); 
            }
            catch (Exception e)
            {
                // Global error handler for unexpected exceptions in the main workflow
                Console.WriteLine($"\n An unexpected error occured: {e}");
            }
            finally
            {
                // Cleanup: Dispose of the semaphore and stop the stopwatch
                tireChangingSemaphore?.Dispose();
                stopwatch?.Stop();
            }
        }
    }
}
