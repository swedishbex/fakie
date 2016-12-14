



/* {

	{
		
		{
			InitializeComponent();
		}
	}
}
*/

using System.Collections.Generic;
using System;


using Xamarin.Forms;

namespace fakie
{
	public class LetterTemplate
	{
		public string ButtonText1 { get; set; }
		public string ButtonText2 { get; set; }
		public string ButtonText3 { get; set; }
		public string ButtonText4 { get; set; }
	}

	public partial class ParkLetters : ContentPage
	{
		private List<LetterTemplate> buttons = new List<LetterTemplate>();

		public ParkLetters()
		{
			InitializeComponent();

			var alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZÅÄÖ";

			var i = 0;
			LetterTemplate lastTemplate = null;
			foreach (char c in alphabet)
			{
				if (i % 4 == 0)
				{
					var rowTemplate = new LetterTemplate();

					lastTemplate = rowTemplate;
					buttons.Add(lastTemplate);
				}
				switch (i % 4)
				{
					case 0:
						lastTemplate.ButtonText1 = c.ToString();
						break;
					case 1:
						lastTemplate.ButtonText2 = c.ToString();
						break;
					case 2:
						lastTemplate.ButtonText3 = c.ToString();
						break;
					case 3:
						lastTemplate.ButtonText4 = c.ToString();
						break;
				}
				++i;
			}

			ButtonList.ItemsSource = buttons;
		}

		void goCity(object sender, EventArgs e)
		{
			var letter = ((Button)sender).Text;
			Navigation.PushAsync(new ParkIndex(letter));
		}
	}
}
/*using System;
using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public partial class Page2Xaml : ContentPage
	{
		public Page2Xaml()
		{
			InitializeComponent();
		}

		async void OnNextPageButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page3Xaml());
		}

		async void OnPreviousPageButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}*/ 
