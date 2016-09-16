# Vurtigo.Logr

A lightweight Cross platform Logger for Xamarin.

Provides a Logr to write console messages to Android or iOS.

Logr does not need to be initialized, it works straight out of the box.

```
Logr.Debug("Debug Message");
Logr.Debug("Debug Message with string formatting {0}", args);
Logr.Error(e, "Error Message {1}", args);
```

If Xamarin.Insights is installed (and initialized) Logr will send Logr.Error message to Insights. Xamarin Insights should be initialized before writing any logs.

On Android Logr will also send the last 500 lines of logcat (configurable) to Insights. 
By default it will only do this in Debug mode, but can be turned on for Release if you're trying to pin down an exception. You could also turn it on in specific places in your code and turn it off again afterwards.

To configure Logr, for example, to disable Insights reporting, access the LogrWriter Settings class.

```
LogrWriterInstance.Instance.Settings.Insights.LogNumberOfLines = 10;
LogrWriterInstance.Instance.Settings.Insights.ShouldTryReportToInsights = false;
LogrWriterInstance.Instance.Settings.Insights.OnlySendLogFileInDebug = true;
```

To swap out the LogrWriter to your own implementation, inherit from ILogrWriter, and replace the instance.

```
var logr = new CustomLogrWriter();
LogrWriterInstance.Instance = logr;
```

## Nuget

https://www.nuget.org/packages/Xamarin.Logr

Add Vurtigo.Logr to your PCL and platform projects. Currently supported platforms are:

- Xamarin.Android
- Xamarin.iOS
