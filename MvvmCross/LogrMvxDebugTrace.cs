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

