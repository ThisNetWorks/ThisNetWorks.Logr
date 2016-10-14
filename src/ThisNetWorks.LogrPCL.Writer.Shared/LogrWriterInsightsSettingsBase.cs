using System;
using System.Reflection;
using ThisNetWorks.LogrPCL.Abstractions;
using System.Linq;

#if !PCL
namespace ThisNetWorks.LogrPCL.Writer.Shared
{
	public class LogrWriterInsightsSettingsBase : ILogrWriterInsightsSettings
	{

		protected MethodInfo _insightsReportMethod;
		public MethodInfo InsightsReportMethod 
		{
			get {
				return _insightsReportMethod;
			}
		}


		private bool _shouldTryReportToInsights = true;
		public virtual bool ShouldTryReportToInsights {
			get {
				if (_shouldTryReportToInsights) {
					var insightsInitialised = InitialiseInsights();
					if (insightsInitialised == false)
						_shouldTryReportToInsights = false;
				}

				return _shouldTryReportToInsights;
			}
			set { _shouldTryReportToInsights = value; }
		}


		public virtual bool ShouldSendLogFile { get; set; } = true;


		public virtual int LogNumberOfLines { get; set; } = 500;


		public virtual bool OnlySendLogFileInDebug { get; set; } = true;

		protected virtual bool InitialiseInsights()
		{
			var insightsAssem = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "Xamarin.Insights");

			var insightsType = insightsAssem.GetType("Xamarin.Insights");
			var isInsightsInitialized = (bool)insightsType.GetProperty("IsInitialized").GetValue(null);

			if (!isInsightsInitialized)
				return false;

			_insightsReportMethod = insightsType.GetMethods()
														.FirstOrDefault(x => x.Name == "Report"
																		&& x.GetParameters().Length == 3
																		&& x.GetParameters()[2].ParameterType.IsEnum == true);
			if (_insightsReportMethod == null)
				return false;

			return true;
		}
	}
}

#endif
