namespace My.DDD.CQRS.Temp6.Contracts.WeatherAggregate
{
    public class WeatherForecastResult
    {

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string? Summary { get; set; }
    }
}
