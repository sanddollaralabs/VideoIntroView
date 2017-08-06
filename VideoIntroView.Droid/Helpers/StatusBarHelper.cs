using Android.App;
using Android.Views;
namespace VideoIntroView.Droid
{
	public static class StatusBarHelper
	{
		public static View DecorView
		{
			get;
			set;
		}
		public static ActionBar AppActionBar
		{
			get;
			set;
		}
	}
}