using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;

namespace GettingStarted;

public class Program
{
    public static void Main()
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddOpenTelemetry(options =>
            {
                // Add log provider.
                options.AddConsoleExporter();
            });

            builder.AddConsole();
        });

 

        var logger = loggerFactory.CreateLogger("SampleCategory");
        logger.LogInformation("Hello {name}.", "Demo Friday");
        logger.LogError("This is an error");
    }
}