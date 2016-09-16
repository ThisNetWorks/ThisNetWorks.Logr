using System;
using System.Runtime.CompilerServices;
using ThisNetWorks.LogrPCL;
using ThisNetWorks.LogrPCL.Abstractions;
using ThisNetWorks.LogrPCL.Writer;

public class Logr : ILogr
{
	#region static members
	public static void Debug(string message)
	{
		LogrInstance.Instance.Debug(message);
	}

	public static void Debug(string message, params object[] args)
	{
		LogrInstance.Instance.Debug(message, args);
	}

	public static void Info(string message)
	{
		LogrInstance.Instance.Info(message);
	}

	public static void Info(string message, params object[] args)
	{
		LogrInstance.Instance.Info(message, args);
	}

	public static void Warn(string message)
	{
		LogrInstance.Instance.Warn(message);
	}

	public static void Warn(string message, params object[] args)
	{
		LogrInstance.Instance.Info(message, args);
	}

	public static void Error(string message)
	{
		LogrInstance.Instance.Error(message);
	}

	public static void Error(string message, params object[] args)
	{
		LogrInstance.Instance.Error(message, args);
	}

	public static void Error(Exception e, string message)
	{
		LogrInstance.Instance.Error(e, message);
	}

	public static void Error(Exception e, string message, params object[] args)
	{
		LogrInstance.Instance.Error(e, message, args);
	}

	#endregion


	#region interface members
	void ILogr.Debug(string message)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Debug, message);
	}

	void ILogr.Debug(string message, params object[] args)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Debug, message, null, args);
	}

	void ILogr.Info(string message)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Info, message);
	}

	void ILogr.Info(string message, params object[] args)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Info, message, null, args);
	}

	void ILogr.Warn(string message)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Warn, message);
	}

	void ILogr.Warn(string message, params object[] args)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Warn, message, null, args);
	}

	void ILogr.Error(string message)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Error, message);
	}

	void ILogr.Error(string message, params object[] args)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Error, message, null, args);
	}

	void ILogr.Error(Exception e, string message)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Error, message, e);
	}

	void ILogr.Error(Exception e, string message, params object[] args)
	{
		LogrWriterInstance.Instance.LogrWrite(LogrLevel.Error, message, e, args);
	}
	#endregion
}

