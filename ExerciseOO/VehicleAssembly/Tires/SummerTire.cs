using System;

/// <summary>
/// Represents a summer tire with a maximum temperature rating.
/// </summary>
public class SummerTire : Tire
{
    /// <summary>
    /// Gets the maximum temperature (in °C) for which the tire is suitable.
    /// </summary>
    public float MaxTemperature { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SummerTire"/> class with optional pressure and max temperature.
    /// </summary>
    /// <param name="pressure">The air pressure in bar (default: 2.5).</param>
    /// <param name="maxTemperature">The maximum temperature in °C (default: 50.0).</param>
    public SummerTire(float pressure = 2.5f, float maxTemperature = 50.0f)
    {
        Pressure = pressure;
        MaxTemperature = maxTemperature;
    }

    /// <inheritdoc/>
    public override string GetTireInfo()
    {
        return $"Summertire with {Pressure} bar pressure, Max Temp: {MaxTemperature}°C";
    }
}

