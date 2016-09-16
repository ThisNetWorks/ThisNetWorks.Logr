using System;
namespace ThisNetWorks.LogrPCL.Sample.iOS
{
	// This class is never actually used - it just allows the Logr library to know
	// if the app is compiled with the DEBUG constant or not, and stops 
	// debug logs occuring on release builds

	#if DEBUG
	public class LogrDebugPleaseInclude
	{
		public LogrDebugPleaseInclude()
		{
		}
	}
	#endif
}