using System;
using System.Reflection;

namespace ThisNetWorks.LogrPCL.Abstractions
{
    public interface ILogrWriterMobileCentreSettings
    {
		/// <summary>
		/// Gets or sets a value indicating whether logging to Microsoft Mobile Centre should be attempted.
		/// <para>&#160;</para>
		/// <para>&#160;</para>Default is true.
		/// </summary>
		bool ShouldTryReportToMobileCentre { get; set; }

		/// <summary>
		/// The insights report method. Found via reflection, no need to use this property.
		/// </summary>
		MethodInfo MobileCentreReportMethod { get; }

		/// <summary>
		/// Gets or sets a value indicating whether Logr should send log file to Microsoft Mobile Centre. 
		/// <para>&#160;</para>
		/// <para>&#160;</para>If false OnlySendLogFileInDebug flag will be ignored.
		/// </summary>
		/// <value><c>true</c> if should send log file; otherwise, <c>false</c>.</value>
		bool ShouldSendLogFile { get; set; }

		/// <summary>
		/// Gets or sets the number of lines to retrieve from the system log file, if ShouldSendLogFile is true.
		/// <para>&#160;</para>
		/// <para>&#160;</para>Default is 500.
		/// </summary>
		int LogNumberOfLines { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to try and upload a log file in debug mode only, or in release, if ShouldSendLogFile is true
		/// <para>&#160;</para>
		/// <para>&#160;</para>Default is true.
		/// </summary>
		bool OnlySendLogFileInDebug { get; set; }
    }
}
