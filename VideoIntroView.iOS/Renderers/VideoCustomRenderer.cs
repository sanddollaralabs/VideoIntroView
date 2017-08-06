using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using AVFoundation;
using Foundation;
using UIKit;
using VideoIntroView;
using VideoIntroView.iOS;

[assembly: ExportRenderer(typeof(VideoPlayerView), typeof(VideoCustomRenderer))]
namespace VideoIntroView.iOS
{
	public class VideoCustomRenderer : ViewRenderer
	{
		//globally declare variables
		AVAsset _asset;
		AVPlayerItem _playerItem;
		AVPlayer _player;

		NSObject videoEndNotificationToken;
		AVPlayerLayer _playerLayer;

		protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);

			_asset = AVAsset.FromUrl(NSUrl.FromFilename("intro.mp4"));
			_playerItem = new AVPlayerItem(_asset);

			_player = new AVPlayer(_playerItem);
			_player.ActionAtItemEnd = AVPlayerActionAtItemEnd.None;
			_playerLayer = AVPlayerLayer.FromPlayer(_player);

			videoEndNotificationToken = NSNotificationCenter.DefaultCenter.AddObserver(AVPlayerItem.DidPlayToEndTimeNotification, VideoDidFinishPlaying, _playerItem);

			_player.Play();

		}
		private void VideoDidFinishPlaying(NSNotification obj)
		{
			_player.Seek(CoreMedia.CMTime.Zero);
		}

		public override void LayoutSubviews()
		{
			//layout the elements depending on what screen orientation we are. 
			if (DeviceHelpers.iOSDevice.Orientation == UIDeviceOrientation.Portrait)
			{
				_playerLayer.Frame = NativeView.Frame;
				_playerLayer.VideoGravity = AVLayerVideoGravity.ResizeAspectFill;
				NativeView.Layer.AddSublayer(_playerLayer);
			}
			else if (DeviceHelpers.iOSDevice.Orientation == UIDeviceOrientation.LandscapeLeft || DeviceHelpers.iOSDevice.Orientation == UIDeviceOrientation.LandscapeRight)
			{
				_playerLayer.Frame = NativeView.Frame;
				NativeView.Layer.AddSublayer(_playerLayer);
			}
		}
	}
}