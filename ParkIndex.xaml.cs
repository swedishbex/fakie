using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using System.Globalization;

namespace fakie
{
	public partial class ParkIndex : ContentPage
	{
		ObservableCollection<string> parks = new ObservableCollection<string>();
		static JObject parksData = null;

		private string charKey;
		public ParkIndex(string sortChar)
		{
			InitializeComponent();
			charKey = sortChar;
			lblLetter.Text = sortChar;
			loadData();
		}

		async void loadData()
		{
			if (parksData == null)
			{
				parksData = await firebaseAPI.doGet("parks", "", "");
			}

			foreach (var park in parksData)
			{
				var lclPark = (JObject)park.Value;

				foreach (var parkpage in lclPark["Parks"])
				{
					if (parkpage.ToString().ToLower().StartsWith(charKey.ToLower(), StringComparison.Ordinal))
					{
						parks.Add(parkpage.ToString().ToUpper());
					}
				}


			 }

			 var culture = new CultureInfo("sv-SE");
			// Use culture in StringComparer.Create. But StringComparer.Create does not exists? Why?
			ParkList.ItemsSource = parks.OrderBy(i => i, StringComparer.CurrentCulture); 
		}

		void goParkName(object sender, EventArgs e)
		{
			var parkDetails = ((Button)sender).Text;
			//Navigation.PushAsync(new ParkName(parkDetails));
		}

	}
}














/*using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fakie
{
	public partial class ParkIndex : ContentPage
	{
		public ParkIndex(string cityName)
		{
			InitializeComponent();
			//lblCityName.Text = cityName;
		}
	}
}


// Kopiera Cityindex med nya namn*/