using System;
using System.Diagnostics;
using MvvmCross.Platform.Platform;

namespace Project.Core
{
	//in your platform setup class (setup.cs) override CreateDebugTrace and return this class
	
	public class LogrMvxDebugTrace : IMvxTrace
	{
		public void Trace(MvxTraceLevel level, string tag, Func<string> message)
		{
			this.Trace(level, tag, message());
		}

		public void Trace(MvxTraceLevel level, string tag, string message)
		{
			switch (level) {
				case MvxTraceLevel.Diagnostic:
					Logr.Info(tag + ":" + level + ":" + message);
					break;
				case MvxTraceLevel.Warning:
					Logr.Warn(tag + ":" + level + ":" + message);
					break;
				case MvxTraceLevel.Error:
				//Logging to error here can cause to many log messages if, for example, you bind to a url image property which doesn't exist
				//on the server - mvx will throw an error, which will get logged. Keep it in if you want to see this behaviour, change
				//it to Logr.Warn if you want to suppress these kind of error's getting thrown to Insights. I tend to leave it in while beta
				//testing and take it out later - mostly because the less logging to logcat, the faster the application runs.
				
					Logr.Error(tag + ":" + level + ":" + message);
					break;
			}
		}

		public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			switch (level) {
				case MvxTraceLevel.Diagnostic:
					Logr.Info(tag + ":" + level + ":" + message, args);
					break;
				case MvxTraceLevel.Warning:
					Logr.Warn(tag + ":" + level + ":" + message, args);
					break;
				case MvxTraceLevel.Error:
					Logr.Error(tag + ":" + level + ":" + message, args);
					break;
			}
		}
	}
}

