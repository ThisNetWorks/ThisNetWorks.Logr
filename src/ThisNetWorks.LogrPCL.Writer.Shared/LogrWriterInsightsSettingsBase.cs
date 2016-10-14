using System;
using System.Reflection;
using ThisNetWorks.LogrPCL.Abstractions;
using System.Linq;

#if !PCL
namespace ThisNetWorks.LogrPCL.Writer.Shared
{
	public class LogrWriterInsightsSettingsBase : ILogrWriterInsightsSettings
	{
		/// <summary>
		/// The insights report method. Found via reflection, no need to use this property.
		/// </summary>
		protected MethodInfo _insightsReportMethod;
		public MethodInfo InsightsReportMethod 
		{
			get {
				return _insightsReportMethod;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether logging to Xamarin.Insights should be attempted
		/// </summary>
		/// <value><c>true</c> should try report to insights; otherwise, <c>false</c>. Default is true.</value>
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

		/// <summary>
		/// Gets or sets a value indicating whether Logr should send log file. Checked before OnlySendLogFileInDebug. If false here will not 
		/// check OnlySendLogFileInDebug
		/// </summary>
		/// <value><c>true</c> if should send log file; otherwise, <c>false</c>.</value>
		public virtual bool ShouldSendLogFile { get; set; } = true;

		/// <summary>
		/// Gets or sets the number of lines to retrieve from the system log file, if ShouldLEndLogFile is trye
		/// </summary>
		/// <value>The log number of lines. Default is 500</value>
		public virtual int LogNumberOfLines { get; set; } = 500;

		/// <summary>
		/// Gets or sets a value indicating whether to try and upload a log file in debug mode only, or in release, if ShouldSendLogFile is true
		/// </summary>
		/// <value><c>true</c> if only send log file in debug; otherwise, <c>false</c>. Default is true./value>
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
