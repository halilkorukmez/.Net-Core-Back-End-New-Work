using System.IO;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Logging.Log4Net;

public class JsonLayout : LayoutSkeleton
{
    public override void ActivateOptions()
    {

    }

    public override void Format(TextWriter writer, LoggingEvent loggingEvent)
    {
        LogData logData = new LogData(loggingEvent);
        var jsonData = JsonConvert.SerializeObject(logData);

        writer.WriteLine(jsonData);
    }
}