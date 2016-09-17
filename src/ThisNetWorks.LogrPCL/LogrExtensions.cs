using System;
using System.Runtime.CompilerServices;
using ThisNetWorks.LogrPCL.Abstractions;
using ThisNetWorks.LogrPCL.Writer;
using System.Reflection;
using System.Linq;

namespace ThisNetWorks.LogrPCL
{
	public static class LogrExtensions
	{
		public static T ToLogr<T>(this T obj, [CallerLineNumber] int sourceLineNumer = 0, [CallerMemberName] string memberName = "")
		{
			var formattedMessage = $"{obj.ToString(),-50}{obj.GetType().Name,-10}{memberName,-20}line {sourceLineNumer}";
			LogrWriterInstance.Instance.LogrWrite(LogrLevel.Debug, formattedMessage);
			return obj;
		}

		public static T ToLogr<T>(this T obj, string message, [CallerLineNumber] int sourceLineNumer = 0, [CallerMemberName] string memberName = "")
		{
			var messageWithObject = $"{message} = {obj.ToString()}";

			var formattedMessage = $"{messageWithObject,-50}{obj.GetType().Name,-10}{memberName,-20}line {sourceLineNumer}";
			LogrWriterInstance.Instance.LogrWrite(LogrLevel.Debug, formattedMessage);
			return obj;
		}

		public static T ToLogr<T>(this T obj, string message, params object[] args)
		{
			var formatted = string.Format(message, args);
			var formattedMessage = $"{obj.ToString()}, {formatted} ({obj.GetType()})";
			LogrWriterInstance.Instance.LogrWrite(LogrLevel.Debug, formattedMessage);
			return obj;
		}

		//TODO work in progress (maybe use YAML to deserialize complex types)
		//public static T ToLogrTest<T>(this T obj, [CallerLineNumber] int sourceLineNumer = 0, [CallerMemberName] string memberName = "")
		//{
		//	var formattedMessage = $"{obj.ToString(),-50}{obj.GetType().Name,-10}{memberName,-20}line {sourceLineNumer}";
		//	LogrWriterInstance.Instance.LogrWrite(LogrLevel.Debug, formattedMessage);

		//	var type = obj.GetType();
		//	var fields = type.GetRuntimeFields().Where(x => x.Attributes == FieldAttributes.Private);
		//	var props = type.GetRuntimeProperties();

		//	foreach (FieldInfo field in fields) {

		//		Logr.Debug($"Fields {field.FieldType}, {field.Name}, value = {field.GetValue(obj)}");
		//	}

		//	foreach (PropertyInfo prop in props) {
		//		Logr.Debug($"Properties {prop.PropertyType}, {prop.Name}");
		//	}


		//	return obj;
		//}


	}
}
