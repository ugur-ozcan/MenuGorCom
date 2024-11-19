// File: MenuGorCom.Infrastructure/Logging/SerilogConfiguration.cs
using Serilog;

namespace MenuGorCom.Infrastructure.Logging
{
    public static class SerilogConfiguration
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console() // Konsola log yazar
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Günlük log dosyası
                .CreateLogger();
        }
    }
}
