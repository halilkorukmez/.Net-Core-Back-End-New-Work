using log4net.Core;

namespace Core.CrossCuttingConcerns.Logging.Log4Net;

public class LogData
{
    private LoggingEvent _loggingEvent;

    public LogData(LoggingEvent loggingEvent)
    {
        _loggingEvent = loggingEvent;
    }

    public object Message => _loggingEvent.MessageObject;
}