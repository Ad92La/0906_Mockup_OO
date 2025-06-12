using System;

public class SummerTire : Tire
{
	public float MaxTemperature { get; set; }


	public SummerTire(float pressure = 2.5f, float maxTemperature = 50.0f)
	{
		Pressure = pressure;
		MaxTemperature = maxTemperature;
	}

    public override string GetTireInfo()
	{
		return "Summer tire with {Pressure} bar pressure, Max Temp: {MaxTemperature}°C";
	}
}

