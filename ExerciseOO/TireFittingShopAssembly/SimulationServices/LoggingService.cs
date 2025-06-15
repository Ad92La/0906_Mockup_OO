using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TireFittingShopAssembly.SimulationServices
{
    /// <summary>
    /// Service for timestamped logging of simulation events to the console.
    /// </summary>
    public class LoggingService
    {
        private readonly Stopwatch _stopwatch;

        /// <summary>
        /// Initializes the logging service with a stopwatch for time measurement.
        /// </summary>
        /// <param name="stopwatch">The stopwatch used to timestamp log messages.</param>
        public LoggingService(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        /// <summary>
        /// Logs a message to the console with a timestamp.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Log(string message)
        {
            var elapsed = _stopwatch?.Elapsed ?? TimeSpan.Zero;
            Console.Write($"[{elapsed.TotalSeconds:0.0}] \t\t {message}");
        }
    }
}
