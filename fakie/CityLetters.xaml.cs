﻿using System.Collections.Generic;
using System;


using Xamarin.Forms;

namespace fakie
{
	public class RowTemplate
	{
		public string ButtonText1 { get; set; }
		public string ButtonText2 { get; set; }
		public string ButtonText3 { get; set; }
		public string ButtonText4 { get; set; }
	}

	public partial class CityLetters : ContentPage
	{
		private List<RowTemplate> buttons = new List<RowTemplate>();

		public CityLetters()
		{
			InitializeComponent();

			var alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZÅÄÖ";

			var i = 0;
			RowTemplate lastTemplate = null;
			foreach (char c in alphabet)
			{
				if (i % 4 == 0)
				{
					var rowTemplate = new RowTemplate();

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
			Navigation.PushAsync(new CityIndex(letter));
		}
	}
}
