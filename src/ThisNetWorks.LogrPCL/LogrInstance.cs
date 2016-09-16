using System;
using ThisNetWorks.LogrPCL.Abstractions;

namespace ThisNetWorks.LogrPCL
{
	public static class LogrInstance
	{
		static Lazy<ILogr> TTS = new Lazy<ILogr>(() => CreateLogr(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		public static ILogr Instance {
			get {
				var ret = TTS.Value;
				if (ret == null) {
					throw NotImplementedInReferenceAssembly();
				}
				return ret;
			}
		}

		static ILogr CreateLogr()
		{
			return new Logr();
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the Xam.Plugins.Vibrate NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
}

