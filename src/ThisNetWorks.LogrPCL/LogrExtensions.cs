using System;
using System.Runtime.CompilerServices;
using ThisNetWorks.LogrPCL.Abstractions;
using ThisNetWorks.LogrPCL.Writer;

namespace ThisNetWorks.LogrPCL
{
	public static class LogrExtensions
	{
		public static void ToLogr(this object obj, [CallerLineNumber] int sourceLineNumer = 0, [CallerMemberName] string memberName = "")
		{
			var formattedMessage = $"{obj.ToString(),-50}{obj.GetType().Name,-10}{memberName,-30}line {sourceLineNumer}";
			LogrWriterInstance.Instance.LogrWrite(LogrLevel.Debug, formattedMessage);
		}

		public static void ToLogr(this object obj, string message, [CallerLineNumber] int sourceLineNumer = 0, [CallerMemberName] string memberName = "")
		{
			var messageWithObject = $"{message} = {obj.ToString()}";

			var formattedMessage = $"{messageWithObject,-50}{obj.GetType().Name,-10}{memberName,-20}line {sourceLineNumer}";
			LogrWriterInstance.Instance.LogrWrite(LogrLevel.Debug, formattedMessage);
		}

		public static void ToLogr(this object obj, string message, params object[] args)
		{
			var formatted = string.Format(message, args);
			var formattedMessage = $"{obj.ToString()}, {formatted} ({obj.GetType()})";
			LogrWriterInstance.Instance.LogrWrite(LogrLevel.Debug, formattedMessage);
		}

	}
}
