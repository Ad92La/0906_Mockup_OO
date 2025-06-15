using System;

/// <summary>
/// Represents a winter tire with a minimum temperature rating and thickness.
/// </summary>
public class WinterTire : Tire
{
    /// <summary>
    /// Gets the minimum temperature (in °C) for which the tire is suitable.
    /// </summary>
    public float MinTemperature { get; private set; }

    /// <summary>
    /// Gets the thickness of the tire in centimeters.
    /// </summary>
    public float Thickness { get; private set; } = 2.5f; // Default thickness for winter tire

    /// <summary>
    /// Initializes a new instance of the <see cref="WinterTire"/> class with optional pressure, min temperature, and thickness.
    /// </summary>
    /// <param name="pressure">The air pressure in bar (default: 2.5).</param>
    /// <param name="minTemperature">The minimum temperature in °C (default: -20.5).</param>
    /// <param name="thickness">The thickness in centimeters (default: 2.5).</param>
    public WinterTire(float pressure = 2.5f, float minTemperature = -20.5f, float thickness = 2.5f)
    {
        Pressure = pressure;
        MinTemperature = minTemperature;
        Thickness = thickness;
    }

    /// <inheritdoc/>
    public override string GetTireInfo()
    {
        return $"Wintertire with {Pressure} bar pressure, Min Temp: {MinTemperature}°C, Thickness: {Thickness}cm";
    }
}

