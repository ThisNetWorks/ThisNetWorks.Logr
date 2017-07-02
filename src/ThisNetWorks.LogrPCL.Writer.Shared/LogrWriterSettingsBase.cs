using System;
using System.Reflection;
using ThisNetWorks.LogrPCL.Abstractions;
using System.Linq;

#if !PCL
namespace ThisNetWorks.LogrPCL.Writer.Shared
{
	public abstract class LogrWriterSettingsBase : ILogrWriterSettings
	{
		protected bool _isInitialized = false;

		protected bool _isDebug;
		public bool IsDebug {
			get {
				if (_isInitialized == false) {
					_isDebug = InitializeDebug();
					_isInitialized = true;
				}
				return _isDebug;
			}
			set {
				_isDebug = value;
			}
		}

		public ILogrWriterInsightsSettings Insights { get; set; } = new LogrWriterInsightsSettings();
        public ILogrWriterMobileCentreSettings MobileCentre { get; set; } = new LogrWriterMobileCentreSettings();
		protected abstract bool InitializeDebug();
	}
}
#endif
