using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using Newtonsoft.Json.Linq;

namespace PhoneApp1
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			// Sample code to localize the ApplicationBar
			//BuildLocalizedApplicationBar();
		}
		String json;
		void handler(object sender, DownloadStringCompletedEventArgs e)
		{
			txta.Text = "abc2";
			txta.Text = e.Result;
			json=e.Result;
			String s;

			JObject j = JObject.Parse(json);
			JArray gr = (JArray)j["@graph"];

			JObject a = (JObject)gr[0];
			JObject b = (JObject)a["s:address"];
			JObject c = (JObject)b["s:addressLocality"];
			txta.Text = c;




			/*
			RootObject root = JsonConvert.DeserializeObject<RootObject>(e.Result);
			JObject obj = root.response.ScoreDetail;
			foreach (KeyValuePair<string, JToken> pair in obj)
			{
				string key = pair.Key; // here you got 39.
				foreach (JObject detail in pair.Value as JArray)
				{
					string date = detail["test_date"].ToString();
					string score = detail["score"].ToString();
					string total_marks = detail["total_marks"].ToString();
				}
			}*/

		}


		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			txta.Text = "abc";
			WebClient w = new WebClient();
			w.DownloadStringAsync(new Uri("http://platform.bing.com/geo/autosuggest/v1/?umv=47.219192,-123.605026,28.612973,-81.505417&mr=10&ul=34.038196,-118.278534,100&q=Pasadena"),null);
			
			w.DownloadStringCompleted+=new DownloadStringCompletedEventHandler(handler);
			txta.Text = "abc1";
			
		}

		private void txta_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		// Sample code for building a localized ApplicationBar
		//private void BuildLocalizedApplicationBar()
		//{
		//    // Set the page's ApplicationBar to a new instance of ApplicationBar.
		//    ApplicationBar = new ApplicationBar();

		//    // Create a new button and set the text value to the localized string from AppResources.
		//    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
		//    appBarButton.Text = AppResources.AppBarButtonText;
		//    ApplicationBar.Buttons.Add(appBarButton);

		//    // Create a new menu item with the localized string from AppResources.
		//    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
		//    ApplicationBar.MenuItems.Add(appBarMenuItem);
		//}
	}
}