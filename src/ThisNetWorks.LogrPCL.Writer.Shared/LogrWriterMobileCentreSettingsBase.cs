using System;
using System.Linq;
using System.Reflection;
using ThisNetWorks.LogrPCL.Abstractions;

#if !PCL
namespace ThisNetWorks.LogrPCL.Writer.Shared
{
    public class LogrWriterMobileCentreSettingsBase : ILogrWriterMobileCentreSettings
    {
        protected MethodInfo _mobileCentreReportMethod;
        public MethodInfo MobileCentreReportMethod
		{
			get
			{
				return _mobileCentreReportMethod;
			}
		}


        private bool _shouldTryReportToMobileCentre = true;
        public virtual bool ShouldTryReportToMobileCentre
		{
			get
			{
				if (_shouldTryReportToMobileCentre)
				{
                    var mobileCentreInitialised = InitialiseMobileCentre();
					if (mobileCentreInitialised == false)
						_shouldTryReportToMobileCentre = false;
				}

				return _shouldTryReportToMobileCentre;
			}
			set { _shouldTryReportToMobileCentre = value; }
		}


        private bool _shouldSendLogFile;
        public virtual bool ShouldSendLogFile { 
            get {
                //disabled analytics events only support 64 characters
                //return _shouldSendLogFile;
                return false; 
            } set { _shouldSendLogFile = value; } } 


		public virtual int LogNumberOfLines { get; set; } = 500;


		public virtual bool OnlySendLogFileInDebug { get; set; } = true;


		public virtual string VersionCode { get; set; } = "0.0.0";

		protected virtual bool InitialiseMobileCentre()
		{
            var mobileCenterAssem = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "Microsoft.Azure.Mobile");
            var mobileCenterType = mobileCenterAssem.GetType("Microsoft.Azure.Mobile.MobileCenter");

			var isConfigured = (bool)mobileCenterType.GetProperty("Configured").GetValue(null);


//TODO enabled moved to async task in v0.14.0
			//var isEnabled = (bool)mobileCenterType.GetProperty("Enabled").GetValue(null);


    //        if (!isConfigured || !isEnabled)
				//return false;

            if (!isConfigured)
                return false;
            
            var crashAssem = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "Microsoft.Azure.Mobile.Analytics");
            var crashType = crashAssem.GetType("Microsoft.Azure.Mobile.Analytics.Analytics");

			_mobileCentreReportMethod = crashType.GetMethods()
										    .FirstOrDefault(x => x.Name == "TrackEvent"
											&& x.GetParameters().Length == 2);
			if (_mobileCentreReportMethod == null)
				return false;

			return true;
		}
	}
}

#endif
