﻿namespace OI.Template.Domain.Entities;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}