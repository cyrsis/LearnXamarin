using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpicyUI
{
	public class WelcomeViewModel : BaseViewModel
	{
		Command signInUserCommand;
		Page signInPage;

		public WelcomeViewModel (Page p)
		{
			signInPage = p;
		}

		public Command SignInUserCommand
		{
			get { return signInUserCommand ?? (signInUserCommand = new Command (async () => await ExecuteSignInUserCommand ()));}
		}

		public async Task ExecuteSignInUserCommand ()
		{
			if (IsBusy) {
				return;
			}

			IsBusy = true;

//			var navigationPage = new NavigationPage (new FriendsPage ()) {
//				BarBackgroundColor = Color.FromHex ("4A90E2"),
//				BarTextColor = Color.White
//			};

			var friendsPage = new FriendsPage ();
			var cameraPage = new CameraPage ();

			var carouselPage = new CarouselPage () {
				Children = { friendsPage, cameraPage }
			};
				
			// Sign In User Logic
			await signInPage.Navigation.PushModalAsync (carouselPage);

			IsBusy = false;
		}
	}
}

