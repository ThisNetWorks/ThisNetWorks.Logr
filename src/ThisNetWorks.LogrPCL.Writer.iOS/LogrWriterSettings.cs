using System;
using System.Reflection;
using ThisNetWorks.LogrPCL.Writer.Shared;
using System.Linq;

namespace ThisNetWorks.LogrPCL.Writer
{
	public class LogrWriterSettings : LogrWriterSettingsBase
	{
		protected override bool InitializeDebug()
		{
			var assemb = Assembly.GetEntryAssembly();

			var type = assemb.GetTypes().Where(x => x.Name == "LogrDebugPleaseInclude");
			if (type.Any())
				return true;
			else
				return false;
		}
	}
}

