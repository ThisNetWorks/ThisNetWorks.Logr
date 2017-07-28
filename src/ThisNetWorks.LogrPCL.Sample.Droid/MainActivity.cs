using Android.App;
using Android.Widget;
using Android.OS;
using ThisNetWorks.LogrPCL.Sample.Core;
using ThisNetWorks.LogrPCL.Sample.Shared;
using ThisNetWorks.LogrPCL.Writer;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Linq;

namespace ThisNetWorks.LogrPCL.Sample.Droid
{
	[Activity(Label = "ThisNetWorks.LogrPCL.Sample.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

			//Xamarin.Insights.Initialize(InsightsKey.XamInsightsKey, this);

			MobileCenter.Start("83876814-c344-41a9-b712-223bb575a901",
	            typeof(Analytics), typeof(Crashes));


			var mobileCenterAssem = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "Microsoft.Azure.Mobile.Analytics");
			var mobileCenterType = mobileCenterAssem.GetType("Microsoft.Azure.Mobile.Analytics.Analytics");

			//var isConfigured = (bool)mobileCenterType.GetProperty("Configured").GetValue(null);
			var _mobileCentreReportMethod = mobileCenterType.GetMethods()
											.FirstOrDefault(x => x.Name == "TrackEvent"
															&& x.GetParameters().Length == 2);


            LogrWriterInstance.Instance.Settings.MobileCentre.VersionCode = "1.0.0";

			LogrWriterInstance.Instance.Settings.MobileCentre.ShouldTryReportToMobileCentre = true;

			var coreSample = new CoreLogrSample();
			var frontLogrSample = new LogrSample("Droid Front");
			//swap out the LogrWriter with a (potentially) different implementation
			//var logr = new LogrWriter();
			//LogrWriterInstance.Instance = logr;
			//var newLogrWriterSample = new LogrSample("iOS Front - with new writer");

		}
	}
}


