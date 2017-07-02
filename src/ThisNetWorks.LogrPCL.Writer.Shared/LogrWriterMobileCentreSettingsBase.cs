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


		public virtual bool ShouldSendLogFile { get; set; } = true;


		public virtual int LogNumberOfLines { get; set; } = 500;


		public virtual bool OnlySendLogFileInDebug { get; set; } = true;

		protected virtual bool InitialiseMobileCentre()
		{
            var mobileCenterAssem = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "Microsoft.Azure.Mobile");
            var mobileCenterType = mobileCenterAssem.GetType("Microsoft.Azure.Mobile.MobileCenter");

			var isConfigured = (bool)mobileCenterType.GetProperty("Configured").GetValue(null);


			var isEnabled = (bool)mobileCenterType.GetProperty("Enabled").GetValue(null);


            if (!isConfigured || !isEnabled)
				return false;
            
            var crashAssem = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "Microsoft.Azure.Mobile.Crashes");
			var crashType = mobileCenterAssem.GetType("Microsoft.Azure.Mobile.MobileCenterLog");

			_mobileCentreReportMethod = mobileCenterType.GetMethods()
														.FirstOrDefault(x => x.Name == "Error"
																		&& x.GetParameters().Length == 3);
			if (_mobileCentreReportMethod == null)
				return false;

			return true;
		}
	}
}

#endif
