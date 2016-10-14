using Android.App;
using Android.Widget;
using Android.OS;
using ThisNetWorks.LogrPCL.Sample.Core;
using ThisNetWorks.LogrPCL.Sample.Shared;
using ThisNetWorks.LogrPCL.Writer;

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
			Xamarin.Insights.Initialize(InsightsKey.XamInsightsKey, this);

			var coreSample = new CoreLogrSample();
			var frontLogrSample = new LogrSample("Droid Front");
			//swap out the LogrWriter with a (potentially) different implementation
			//var logr = new LogrWriter();
			//LogrWriterInstance.Instance = logr;
			//var newLogrWriterSample = new LogrSample("iOS Front - with new writer");

		}
	}
}


