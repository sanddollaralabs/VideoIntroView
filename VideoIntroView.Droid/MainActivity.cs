using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace VideoIntroView.Droid
{
	[Activity(Label = "VideoIntroView.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			var pixelWidth = (int)Resources.DisplayMetrics.WidthPixels;
			var pixelHeight = (int)Resources.DisplayMetrics.HeightPixels;
			var screenPixelDensity = (double)Resources.DisplayMetrics.Density;

			App.ScreenHeight = (double)((pixelHeight - 0.5f) / screenPixelDensity);
			App.ScreenWidth = (double)((pixelWidth - 0.5f) / screenPixelDensity);

			StatusBarHelper.DecorView = this.Window.DecorView;

			LoadApplication(new App(new AndroidInitializer()));
		}
	}

	public class AndroidInitializer : IPlatformInitializer
	{
		public void RegisterTypes(IUnityContainer container)
		{

		}
	}
}
