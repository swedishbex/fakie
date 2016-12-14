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

				var parkname = (JObject) region.Key;




			if (parkname.ToString().ToLower().StartsWith(charKey.ToLower(), StringComparison.Ordinal))
			{
				parks.Add(parkname.ToString().ToUpper());
			}

			var culture = new CultureInfo("sv-SE");
			// Use culture in StringComparer.Create. But StringComparer.Create does not exists? Why?
			ParkList.ItemsSource = parks.OrderBy(i => i, StringComparer.CurrentCulture);
		}

		void goParkName(object sender, EventArgs e)
		{
			var parkDetails = ((Button)sender).Text;
			Navigation.PushAsync(new ParkName(parkDetails));
		}

	}
}





	
				






						   