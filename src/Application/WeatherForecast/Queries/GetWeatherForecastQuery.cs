using MediatR;

namespace OI.Template.Application.WeatherForecast.Queries;

public record GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecastDto>>;

public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecastDto>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public async Task<IEnumerable<WeatherForecastDto>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var random = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
        {
            Date = DateOnly.FromDateTime(DateTime.Now).AddDays(index),
            TemperatureC = random.Next(-20, 55),
            Summary = Summaries[random.Next(Summaries.Length)]
        });
    }
}