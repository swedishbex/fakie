using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace fakie
{
	public class City
	{
		public string CityName { get; set; }
	}
	public partial class CityIndex : ContentPage
	{
		ObservableCollection<City> cities = new ObservableCollection<City>();
		public CityIndex()
		{
			InitializeComponent();
			cities.Add(new City { CityName = "Malmö" });
			cities.Add(new City { CityName = "Malugn" });
			CityList.ItemsSource = cities;

		}
	}
}
