using System;
using System.Reflection;
using ThisNetWorks.LogrPCL.Abstractions;

namespace ThisNetWorks.LogrPCL.Writer
{
    public class LogrWriterMobileCenterSettings : ILogrWriterMobileCentreSettings
    {
        public bool ShouldTryReportToMobileCentre { get; set; }
        public MethodInfo MobileCentreReportMethod { get; }
        public bool ShouldSendLogFile { get; set; }
        public int LogNumberOfLines { get; set; }
        public bool OnlySendLogFileInDebug { get; set; }
        public string VersionCode { get; set; }
    }
}
