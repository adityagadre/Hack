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
using System.Collections; // for 'IEnumerable'
using System.Collections.Generic; // for 'List'


namespace PhoneApp1
{
    public class SampleWords : IEnumerable
    {
        public IEnumerable AutoCompletions = new List<string>()
        {
         "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "Nullam", "felis", "dui", "gravida", "at",
         "condimentum", "eget", "mattis", "non", "est", "Duis", "porta", "ornare", "tellus", "at", "convallis", "nibh", "aliquam",
         "faucibus", "Vivamus", "molestie", "fringilla", "ullamcorper", "Aenean", "non", "diam", "eu", "sapien", "pretium", "iaculis",
         "Quisque", "at", "ante", "libero", "eu", "tincidunt", "urna", "Cras", "libero", "ligula", "hendrerit", "at", "posuere", "at",
         "tempor", "at", "nulla", "Aliquam", "feugiat", "sagittis", "dolor", "convallis", "porttitor", "neque", "commodo", "ut", "Praesent",
         "egestas", "tincidunt", "lectus", "et", "pharetra", "enim", "semper", "et", "Fusce", "placerat", "orci", "vel", "iaculis",
         "dictum", "nulla", "sem", "convallis", "nunc", "in", "viverra", "leo", "mauris", "eu", "odio", "Nullam", "et", "ultricies",
         "sapien", "Proin", "quis", "mi", "a", "sapien", "semper", "lobortis", "ut", "eget", "est", "Suspendisse", "scelerisque", "porta",
         "mattis", "In", "eleifend", "tellus", "vel", "nulla", "aliquam", "ornare", "Praesent", "tincidunt", "dui", "ut", "libero",
         "iaculis", "consequat", "Nunc", "interdum", "eleifend", "rhoncus", "Curabitur", "sollicitudin", "nulla", "sagittis", "quam",
         "vehicula", "cursus", "Fusce", "laoreet", "arcu", "vitae", "fringilla", "scelerisque", "nisi", "purus", "laoreet", "ipsum", "id",
         "suscipit", "erat", "tellus", "eu", "sapien", "Proin", "pharetra", "tortor", "nisl", "Etiam", "et", "risus", "eget", "lectus",
         "vulputate", "dignissim", "ac","sed", "erat", "Nulla", "vel", "condimentum", "nunc", "Suspendisse", "aliquam", "euismod", "dictum",
         "Ut", "arcu", "enim", "consectetur", "at", "rhoncus", "at", "porta", "ut", "lacus", "Donec", "nisi", "quam", "faucibus", "tempor",
         "tincidunt", "eu", "porttitor", "id", "ipsum", "Proin", "nec", "neque", "nulla", "Suspendisse", "sapien", "metus", "aliquam", "nec",
         "dapibus", "consequat", "rutrum", "id", "leo", "Donec", "ac", "fermentum", "tortor", "Pellentesque", "nisl", "orci", "tincidunt",
         "at", "iaculis", "vitae", "consequat", "scelerisque", "ante", "Suspendisse", "potenti", "Maecenas", "auctor", "justo", "a", "nibh",
         "sagittis", "facilisis", "Phasellus", "ultrices", "lectus", "a", "nisl", "pretium", "accumsan"
         };

        public IEnumerator GetEnumerator()
        {
            return AutoCompletions.GetEnumerator();
        }
    }


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
			String s="";

			JObject j = JObject.Parse(json);
			JArray gr = (JArray)j["@graph"];

			int i;
			for (i = 0; i < gr.Count; i++)
			{
				JObject a = (JObject)gr[i];
				JObject b = (JObject)a["s:address"];
                JValue c = null;
                if (b == null)
                {
                    c = (JValue)a["s:addressLocality"];
                }
                else
                {
                    c = (JValue)b["s:addressLocality"];
                }
                if(c!=null)
                { 
				    s += "," + c.Value.ToString();
                }
			}
			
			txta.Text = s;




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