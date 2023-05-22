namespace WebApplication1.Services
{
    public class MyService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<List<WeatherForecast>> MyMethodAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(2 * 1000);

            if (cancellationToken.IsCancellationRequested)
            {
                throw new BadHttpRequestException("Bad request");
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }
}
