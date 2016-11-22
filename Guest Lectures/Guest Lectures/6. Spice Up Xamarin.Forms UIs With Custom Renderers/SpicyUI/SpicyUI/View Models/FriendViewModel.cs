using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SpicyUI
{
	public class FriendViewModel : BaseViewModel
	{
		private ObservableCollection<Friend> friends;

		public FriendViewModel ()
		{
			Friends = GenerateFakeData ();
		}

		public ObservableCollection<Friend> Friends
		{
			get { return friends; }
			set { friends = value; }
		}

		private ObservableCollection<Friend> GenerateFakeData ()
		{
			return new ObservableCollection<Friend> {
				new Friend { Name = "Pierce Boggan", Image = "https://www.gravatar.com/avatar/2c9e321b47083ae4afc45b241bf3c2a2" },
				new Friend { Name = "Joseph Hill", Image = "https://www.gravatar.com/avatar/f763ec6935726b7f7715808828e52223" },
				new Friend { Name = "Mike James", Image = "https://www.gravatar.com/avatar/b652b0269a0abde1e99ac0537ca0b4d9" },
				new Friend { Name = "James Montemagno", Image = "https://www.gravatar.com/avatar/7d1f32b86a6076963e7beab73dddf7ca" },
				new Friend { Name = "Krystin Stutesman", Image = "https://www.gravatar.com/avatar/c4c6a8656fdd0bf81ec88ab254872ddd" },
				new Friend { Name = "Jayme Singleton", Image = "https://www.gravatar.com/avatar/36250fac36d72ca6387e499d4502c9b9" },
				new Friend { Name = "Nat Friedman", Image = "https://www.gravatar.com/avatar/7ebc299c7938911f0d517bf63b235f31" },
				new Friend { Name = "Miguel de Icaza", Image = "https://www.gravatar.com/avatar/2f3572497f5917ee06610a3ddb4497f1" }
			};
		}
	}
}

