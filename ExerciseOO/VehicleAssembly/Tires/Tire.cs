using System;

/// <summary>
/// Abstract base class for all tire types.
/// Provides a common interface for tire properties and information retrieval.
/// </summary>
public abstract class Tire
{
    /// <summary>
    /// Gets or sets the air pressure of the tire in bar.
    /// </summary>
    public float Pressure { get; protected set; }

    /// <summary>
    /// Returns a string describing the tire's properties.
    /// </summary>
    /// <returns>Information about the tire.</returns>
    public abstract string GetTireInfo();
}
