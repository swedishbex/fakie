using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace fakie
{
	public partial class ParkName : ContentPage
	{
		JObject dataForPark = null;

		public ParkName(string parkName)
		{
			InitializeComponent();
			lblParkName.Text = parkName;
			loadData(parkName);
		}

		async void loadData(string parkName)
		{
			dataForPark = await DataManager.GetPark(parkName);

			var lat = double.Parse(dataForPark["coords"]["lat"].ToString());
			var lng = double.Parse(dataForPark["coords"]["long"].ToString());

			var position = new Position(lat, lng);

			MyMap.MoveToRegion(
				MapSpan.FromCenterAndRadius(
					position, Distance.FromMiles(1)));

			var pin = new Pin
			{
				Type = PinType.Place,
				Position = position,
				Label = parkName,
				Address = "custom detail info"
			};
			MyMap.Pins.Add(pin);

			if (dataForPark["Address"] != null)
			{
				var address = dataForPark["Address"].ToString();
				lblAddress.Text = address;
			}

			if (dataForPark["CommunityUrl"] != null)
			{
				var hyperlink = dataForPark["CommunityUrl"].ToString();
				if (!string.IsNullOrEmpty(hyperlink))
				{
					lblUrl.Text = hyperlink;
					lblUrl.Clicked += (s, e) =>
					{
						Device.OpenUri(new Uri(dataForPark["CommunityUrl"].ToString()));
					};
				}
			}

			if (dataForPark["ImageUrl"] != null)
			{
				var imageUrl = dataForPark["ImageUrl"].ToString();
				if (!string.IsNullOrEmpty(imageUrl)) {
					imgPark.Source = ImageSource.FromUri(new Uri(imageUrl));
				}
			}


		}
	}
}
