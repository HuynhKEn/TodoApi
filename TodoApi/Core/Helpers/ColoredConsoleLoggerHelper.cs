using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TodoApi.Core.Helpers {
    public class ColorConsoleLoggerConfiguration {
        public int EventId { get; set; }

        public Dictionary<LogLevel, ConsoleColor> LogLevels { get; set; } = new() {
            [LogLevel.Information] = ConsoleColor.Green
        };
    }

    public class ColorConsoleLogger : ILogger {
        private readonly string _name;
        private readonly Func<ColorConsoleLoggerConfiguration> _getCurrentConfig;

        public ColorConsoleLogger(
            string name,
            Func<ColorConsoleLoggerConfiguration> getCurrentConfig) =>
            (_name, _getCurrentConfig) = (name, getCurrentConfig);

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) =>
            _getCurrentConfig().LogLevels.ContainsKey(logLevel);

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter) {
            if (!IsEnabled(logLevel)) {
                return;
            }

            ColorConsoleLoggerConfiguration config = _getCurrentConfig();
            if (config.EventId == 0 || config.EventId == eventId.Id) {
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = config.LogLevels[logLevel];
                Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}]");
                Console.ForegroundColor = originalColor;
                Console.WriteLine($"     {_name} - {formatter(state, exception)}");
            }
            
        }
    }

    public sealed class ColorConsoleLoggerProvider : ILoggerProvider {
        private readonly IDisposable _onChangeToken;
        private ColorConsoleLoggerConfiguration _currentConfig;
        private readonly ConcurrentDictionary<string, ColorConsoleLogger> _loggers = new();

        public ColorConsoleLoggerProvider(
            IOptionsMonitor<ColorConsoleLoggerConfiguration> config) {
            _currentConfig = config.CurrentValue;
            _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new ColorConsoleLogger(name, GetCurrentConfig));

        private ColorConsoleLoggerConfiguration GetCurrentConfig() => _currentConfig;

        public void Dispose() {
            _loggers.Clear();
            _onChangeToken.Dispose();
        }
    }

    public static class ColorConsoleLoggerExtensions {
        public static ILoggingBuilder AddColorConsoleLogger(
            this ILoggingBuilder builder) {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, ColorConsoleLoggerProvider>());

            LoggerProviderOptions.RegisterProviderOptions
                <ColorConsoleLoggerConfiguration, ColorConsoleLoggerProvider>(builder.Services);

            return builder;
        }

        public static ILoggingBuilder AddColorConsoleLogger(
            this ILoggingBuilder builder,
            Action<ColorConsoleLoggerConfiguration> configure) {
            builder.AddColorConsoleLogger();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}
