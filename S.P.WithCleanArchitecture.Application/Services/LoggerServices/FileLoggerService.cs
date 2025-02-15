using S.P.WithCleanArchitecture.Application.Interfaces;
using S.P.WithCleanArchitecture.Application.Services.LoggerService;
using System.Text.Json;

namespace S.P.WithCleanArchitecture.Infrastructure.Logging
{ 
    public class FileLoggerService : ILoggerService
    {
        private static List<LogObject> logObjects = new List<LogObject>();
        private const string FILE = "Files";
        private const string LOG_FILE_NAME = "LogFile.json";

        public async Task LogIntoFile(LogObject logObject)
        {
            if (logObject == null)
                return;

            var ReadingLogObjectsAsJson = await File.ReadAllTextAsync(GetLogFilePath());

            if (ReadingLogObjectsAsJson.Length > 0)
            {
                logObjects = JsonSerializer.Deserialize<List<LogObject>>(
                    ReadingLogObjectsAsJson,
                    new JsonSerializerOptions { WriteIndented = true }) ??
                    logObjects;
            }

            logObjects.Add(logObject);

            string LogObjectsAsJson = JsonSerializer.Serialize<List<LogObject>>(
                logObjects,
                new JsonSerializerOptions { WriteIndented = true });

            await File.WriteAllTextAsync(GetLogFilePath(), LogObjectsAsJson);

        }

        private string GetLogFilePath()
        {
           return Path.Combine(Directory.GetCurrentDirectory(), FILE, LOG_FILE_NAME);
        }
    }
}
        