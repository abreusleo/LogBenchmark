using Microsoft.Extensions.Logging;

namespace Benchmark;

public class LoggerAdapter<T> : ILoggerAdapter<T>
{
    private readonly ILogger<T> _logger;

    public LoggerAdapter(ILogger<T> logger)
    {
        _logger = logger;
    }

    public void Log(LogLevel logLevel, string message)
    {
        if(_logger.IsEnabled(logLevel))
            _logger.LogInformation(message);
    }

    public void Log<T0>(LogLevel logLevel, string message, T0 arg0)
    {
        if(_logger.IsEnabled(logLevel))
            _logger.LogInformation(message, arg0);
    }

    public void Log<T0, T1>(LogLevel logLevel, string message, T0 arg0, T1 arg1)
    {
        if(_logger.IsEnabled(logLevel))
            _logger.LogInformation(message, arg0, arg1);
    }
    
    public void Log<T0, T1, T2>(LogLevel logLevel, string message, T0 arg0, T1 arg1, T2 arg2){
        if(_logger.IsEnabled(logLevel))
            _logger.LogInformation(message, arg0, arg1, arg2);
    }
}

public interface ILoggerAdapter<T>
{
    public void Log(LogLevel logLevel, string message);
    public void Log<T0, T1>(LogLevel logLevel, string message, T0 arg0, T1 arg1);
}