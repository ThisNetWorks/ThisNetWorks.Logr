using System;
using ThisNetWorks.LogrPCL.Abstractions;

namespace ThisNetWorks.LogrPCL.Writer
{
	public static class LogrWriterInstance
	{
		static Lazy<ILogrWriter> TTS = new Lazy<ILogrWriter>(() => CreateLogrWriter(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		private static ILogrWriter _customImplementation = null;

		public static ILogrWriter Instance {
			get {

				if (_customImplementation != null)
					return _customImplementation;

				var ret = TTS.Value;
				if (ret == null) {
					throw NotImplementedInReferenceAssembly();
				}
				return ret;
			}
			set {
				_customImplementation = value;
			}
		}

	  	static ILogrWriter CreateLogrWriter()
		{
#if PCL
			return null;
#else
			return new LogrWriter();
#endif
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the Xam.Plugins.Vibrate NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
}



