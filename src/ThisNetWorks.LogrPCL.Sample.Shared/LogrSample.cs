using System;
namespace ThisNetWorks.LogrPCL.Sample.Shared
{
	public class LogrSample
	{
		public LogrSample(string location)
		{

			string args = "args";
			Logr.Debug($"{location} Debug Message");
			Logr.Debug("{0} Debug Message with {1}", location, args);

			Logr.Info($"{location} Info Message");
			Logr.Info("{0} Info Message with {1}", location, args);

			Logr.Warn($"{location} Warn Message");
			Logr.Warn("{0} Warn Message with {1}", location, args);

			Logr.Error($"{location} Error Message");
			Logr.Error("{0} Error Message with {1}", location, args);
			Logr.Error(new Exception("Test Exception"), $"{location} Error Message" );
			Logr.Error(new Exception("Test Exception"), "{0} Error Message {1}", location, args);


		}
	}
}

