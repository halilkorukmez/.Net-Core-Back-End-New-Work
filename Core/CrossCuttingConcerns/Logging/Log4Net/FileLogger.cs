namespace Core.CrossCuttingConcerns.Logging.Log4Net;

public class FileLogger : LoggerServiceBase
{
    private static string LOGGER_NAME = "JsonFileLogger";
    public FileLogger() : base(LOGGER_NAME)
    {
    }
}