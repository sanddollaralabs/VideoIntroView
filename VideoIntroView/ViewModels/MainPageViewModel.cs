using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace VideoIntroView.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		public MainPageViewModel()
		{
			MyDataSource = new ObservableCollection<CarouselModel>() { new CarouselModel() { Title = "HELLO", Detail = "Let's get this party started!" },
																	new CarouselModel() { Title = "LEARN", Detail = "Learning is fun - video tutorials are great!" },
																    new CarouselModel() { Title = "CREATE", Detail = "Let's create some exciting content." }};
		}

		int _position;
		public int Position
		{
			get { return _position; }
			set { SetProperty(ref _position, value); }
		}

		public ObservableCollection<CarouselModel> _myDataSource;
		public ObservableCollection<CarouselModel> MyDataSource
		{
			get { return _myDataSource; }
			set { SetProperty(ref _myDataSource, value); }
		}


		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{

		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			
		}
	}
}

