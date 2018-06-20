using NUnit.Framework;
using System;
using Xamarin.UITest;

namespace Multiplatform.UItest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			if (platform == Platform.iOS)
			{
				string bundleId = Environment.GetEnvironmentVariable("IOS_SIMULATOR_UDID");
				string deviceIdentifier = "com.bitrise.multiplatform";

				app = ConfigureApp
					.iOS
					.InstalledApp(bundleId)
					.DeviceIdentifier(deviceIdentifier)
					.StartApp();
			}
			else
			{
				app = AppInitializer.StartApp(platform);
			}
		}

		[Test]
		public void AppLaunches()
		{
			app.Screenshot("First screen.");
		}
	}
}
