using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace fakie
{
	public partial class ParkName : ContentPage
	{

		static JObject parksData = null;
		JObject dataForPark = null;

		public ParkName(string parkName)
		{
			InitializeComponent();
			lblParkName.Text = parkName;
			loadData(parkName);


		}

		async void loadData(string parkName)
		{
			/* TODO: This could be more optimal implemented */

			if (parksData == null)
			{
				parksData = await firebaseAPI.doGet("parks", "", "");
			}

			foreach (var park in parksData)
			{
				if (park.Key.ToUpper() == parkName.ToUpper())
				{
					dataForPark = (JObject) park.Value;
					break;
				}
			}

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

		}
	}
}
