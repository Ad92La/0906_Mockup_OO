using System;

public class WinterTire : Tire
{
	public float MinTemperature { get; set; }
	public float Thickness { get; set; } = 0.5f; // Default thickness for winter tire


    public WinterTire(float pressure= 2.5f, float minTemperature = -12.5f, float thickness = 2.5f)
	{
		Pressure = pressure;
		MinTemperature = minTemperature;
		Thickness = thickness;
    }
	public override string GetTireInfo()
	{
		return "Winter tire with {Pressure} bar pressure, Min Temp: {MinTemperature}°C, Thickness: {Thickness}mm";
	}
}

