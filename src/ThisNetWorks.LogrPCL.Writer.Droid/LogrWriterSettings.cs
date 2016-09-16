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
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();


			foreach (var assemb in assemblies) {
				var type = assemb.GetTypes().Where(x => x.Name == "LogrDebugPleaseInclude");
				if (type != null)
					return true;
			}
			return false;
		}
	}
}

