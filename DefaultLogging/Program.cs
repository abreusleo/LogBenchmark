using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddFilter("Default", LogLevel.Critical);
    }
);
    
ILogger logger = new Logger<Program>(loggerFactory);

for(int i = 0; i < 70_000_000; i++)
{
    logger.LogInformation("Testing this log {1}", Random.Shared.Next());
}
