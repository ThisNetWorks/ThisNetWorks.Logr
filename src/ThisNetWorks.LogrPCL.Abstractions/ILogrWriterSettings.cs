using System;
namespace ThisNetWorks.LogrPCL.Abstractions
{
	public interface ILogrWriterSettings
	{
        /// <summary>
        /// Gets or sets a value indicating whether we are operating in debug mode
        /// <see cref="T:ThisNetWorks.LogrPCL.Abstractions.ILogrWriterSettings"/> is debug.
        /// </summary>
        /// <value><c>true</c> if is debug; otherwise, <c>false</c>.</value>
		bool IsDebug { get; set; }

        /// <summary>
        /// Gets or sets Xamarin Insights Settings
        /// </summary>
        /// <value>The insights.</value>
		ILogrWriterInsightsSettings Insights { get; set; }

        /// <summary>
        /// Gets or sets Settings for Microsoft Mobile Centre
        /// </summary>
        /// <value>The mobile centre.</value>
        ILogrWriterMobileCentreSettings MobileCentre { get; set; }
	}
}

