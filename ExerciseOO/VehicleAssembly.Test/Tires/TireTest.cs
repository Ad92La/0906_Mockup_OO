using Xunit;

/// <summary>
/// Unit tests for the SummerTire and WinterTire classes.
/// </summary>
public class TireTests
{
    /// <summary>
    /// Verifies that the default values for SummerTire are set correctly.
    /// </summary>
    [Fact]
    public void SummerTire_DefaultValues_AreCorrect()
    {
        var tire = new SummerTire();
        Assert.Equal(2.5f, tire.Pressure);
        Assert.Equal(50.0f, tire.MaxTemperature);
        Assert.Contains("Summer tire", tire.GetTireInfo());
    }

    /// <summary>
    /// Verifies that the default values for WinterTire are set correctly.
    /// </summary>
    [Fact]
    public void WinterTire_DefaultValues_AreCorrect()
    {
        var tire = new WinterTire();
        Assert.Equal(2.5f, tire.Pressure);
        Assert.Equal(-20.5f, tire.MinTemperature);
        Assert.Equal(2.5f, tire.Thickness);
        Assert.Contains("Winter tire", tire.GetTireInfo());
    }

    /// <summary>
    /// Verifies that custom values for WinterTire are set correctly via the constructor.
    /// </summary>
    [Fact]
    public void WinterTire_CustomValues_AreSet()
    {
        var tire = new WinterTire(2.0f, -30.0f, 3.0f);
        Assert.Equal(2.0f, tire.Pressure);
        Assert.Equal(-30.0f, tire.MinTemperature);
        Assert.Equal(3.0f, tire.Thickness);
    }
}