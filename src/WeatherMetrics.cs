using System.Diagnostics.Metrics;

public class WeatherMetrics
{
    private readonly Counter<int> _weatherQueries;

    public WeatherMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create("Contoso.API");
        _weatherQueries = meter.CreateCounter<int>("contoso.weather.queries");
    }

    public void WeatherQuery(int temp)
    {
        _weatherQueries.Add(1,
            new KeyValuePair<string, object?>("contoso.weather.temp", temp));
    }
}