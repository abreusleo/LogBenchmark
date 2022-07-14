using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Microsoft.Extensions.Logging;

namespace Benchmark;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class LoggerBenchmarks
{
    private const string LogMessageWithParameters = "This is a log message with parameters {First}, {Second}";
    private const string LogMessageWithoutParameters = "This is a log message without parameters";

    private ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("SampleApp.Program", LogLevel.Warning);
        }
    );

    private readonly ILogger<LoggerBenchmarks> _logger;
    private readonly ILoggerAdapter<LoggerBenchmarks> _loggerAdapter;

    public LoggerBenchmarks()
    {
        _logger = new Logger<LoggerBenchmarks>(loggerFactory);
        _loggerAdapter = new LoggerAdapter<LoggerBenchmarks>(_logger);
    }

    [BenchmarkCategory("Params"), Benchmark]
    public void IfLog_Params()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(LogMessageWithParameters, 69, 420);
        }
    }
    
    [BenchmarkCategory("NoParams"), Benchmark]
    public void IfLog()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(LogMessageWithoutParameters);
        }
    }

    [BenchmarkCategory("Params"), Benchmark(Baseline = true)]
    public void NormalLog_Params()
    {
        _logger.LogInformation(LogMessageWithParameters, 69, 420);
    }
    
    [BenchmarkCategory("NoParams"), Benchmark(Baseline = true)]
    public void NormalLog()
    {
        _logger.LogInformation(LogMessageWithoutParameters);
    }

    [BenchmarkCategory("Params"), Benchmark]
    public void LoggerAdapter_Params()
    {
        _loggerAdapter.Log(LogLevel.Information, LogMessageWithParameters, 69, 420);
    }
    
    [BenchmarkCategory("NoParams"), Benchmark]
    public void LoggerAdapter()
    {
        _loggerAdapter.Log(LogLevel.Information, LogMessageWithoutParameters);
    }
}