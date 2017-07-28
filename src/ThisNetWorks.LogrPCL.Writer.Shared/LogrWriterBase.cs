using System;
using System.Reflection;
using ThisNetWorks.LogrPCL.Abstractions;
using System.Linq;
using System.Collections.Generic;
using ThisNetWorks.LogrPCL;

#if !PCL
namespace ThisNetWorks.LogrPCL.Writer.Shared
{
	public abstract class LogrWriterBase
	{
		public ILogrWriterSettings Settings { get; set; } = new LogrWriterSettings();

		protected abstract string FormatMessage(string message, params object[] args);
		protected abstract void LogDebug(string message);
		protected abstract void LogInfo(string message);
		protected abstract void LogWarn(string message);
		protected abstract void LogError(string message, Exception e);
		protected abstract void AddLogFileToInsights(IDictionary<string, string> dict);

        protected abstract string AddLogFileToMobileCenter(string message);

		public void LogrWrite(LogrLevel logrLevel, string message, Exception e = null, params object[] args)
		{
            try
            {
                var messageFormatted = FormatMessage(message, args);

                switch (logrLevel)
                {
                    case LogrLevel.Debug:
                        if (Settings.IsDebug)
                            LogDebug(messageFormatted);
                        break;
                    case LogrLevel.Info:
                        LogInfo(messageFormatted);
                        break;
                    case LogrLevel.Warn:
                        LogWarn(messageFormatted);
                        break;

                    case LogrLevel.Error:

                        LogError(messageFormatted, e);
                        break;
                }
            } catch (Exception ex){
                var error = "Error writing / formatting logr message " + ex.Message;
				var messageFormatted = FormatMessageWithTime(error);
                LogWarn(messageFormatted);
            }
		}

		protected virtual string FormatMessageWithTime(string message)
		{
			return DateTime.Now.ToString("T") + " : " + message;
		}

		protected virtual void ReportToInsights(Exception e, string message, InsightsSeverity warningLevel)
		{
			if (Settings.Insights.ShouldTryReportToInsights == false)
				return;

			if (Settings.Insights.InsightsReportMethod == null)
				return;
			
			var dict = new Dictionary<string, string>();
			dict.Add("Logr Error", message);

			if (Settings.Insights.OnlySendLogFileInDebug && Settings.IsDebug && Settings.Insights.ShouldSendLogFile)
				AddLogFileToInsights(dict);
			else if (Settings.Insights.OnlySendLogFileInDebug == false && Settings.Insights.ShouldSendLogFile)
				AddLogFileToInsights(dict);

			object[] parametersArray = new object[] { e, dict, (int)warningLevel };

			Settings.Insights.InsightsReportMethod.Invoke(null, parametersArray);

		}


		protected virtual void ReportToMobileCenter(string tag, Exception e, string message)
		{
			if (Settings.MobileCentre.ShouldTryReportToMobileCentre == false)
				return;

			if (Settings.MobileCentre.MobileCentreReportMethod == null)
				return;


			if (Settings.MobileCentre.OnlySendLogFileInDebug && Settings.IsDebug && Settings.MobileCentre.ShouldSendLogFile)
                message = AddLogFileToMobileCenter(message);
			else if (Settings.Insights.OnlySendLogFileInDebug == false && Settings.Insights.ShouldSendLogFile)
				message = AddLogFileToMobileCenter(message);

            message = String.Concat("v", Settings.MobileCentre.VersionCode
                                    , " "
                                    , DateTime.Today.ToShortDateString()
                                    , " "
                                    , message);

            var events = new Dictionary<string, string>{
                {"Message", message.Truncate(64)}
            };

            object[] parametersArray = new object[] { tag, events };

            Settings.MobileCentre.MobileCentreReportMethod.Invoke(null, parametersArray);

		}

	}
}
#endif
