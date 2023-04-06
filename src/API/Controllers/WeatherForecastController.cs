using Microsoft.AspNetCore.Mvc;
using OI.Template.Application.WeatherForecast.Queries;

namespace OI.Template.API.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecastDto>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastQuery());
    }
}