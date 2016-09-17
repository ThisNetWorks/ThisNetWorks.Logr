using System;
using ThisNetWorks.LogrPCL.Sample.Shared;

namespace ThisNetWorks.LogrPCL.Sample.Core
{
	public class CoreLogrSample
	{
		public CoreLogrSample()
		{
			var coreSample = new LogrSample("Core");
			var testCoreLogString = "Core String".ToLogr();
			//testCoreLogString.ToLogr();
			testCoreLogString.ToLogr(nameof(testCoreLogString));
			testCoreLogString.ToLogr($"This formats a custom message {testCoreLogString}");
			testCoreLogString.ToLogr("This is the value of the {0}", testCoreLogString );
		}
	}
}

