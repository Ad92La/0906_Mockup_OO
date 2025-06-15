using System.Diagnostics;
using TireFittingShopAssembly.SimulationServices;
using Xunit;
using System.IO;

namespace TireFittingShopAssembly.Test.SimulationServices
{
    /// <summary>
    /// Unit tests for the <see cref="LoggingService"/>.
    /// Verifies that log messages are written with a timestamp.
    /// </summary>
    public class LoggingServiceTest
    {
        /// <summary>
        /// Checks that the log output contains the message and a timestamp.
        /// </summary>
        [Fact]
        public void Log_WritesTimestampedMessage()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var logger = new LoggingService(stopwatch);

            // Redirect console output to a StringWriter for test verification
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                logger.Log("Test message");
                var output = sw.ToString();
                Assert.Contains("Test message", output);
                Assert.Contains("[", output); // Timestamp present
            }
        }
    }
}
