using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjetoTCC.Models;

namespace ProjetoTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FollowPage : ContentPage
	{
		public FollowPage ()
		{
			InitializeComponent ();
            Games.ItemsSource = new List<GamesModel>
            {
                new GamesModel{ Name = "League of Legends", ImageUrl = "lollogo.png", Follow = false },
                new GamesModel{ Name = "DOTA 2", ImageUrl = "dota.png", Follow = false },
                new GamesModel{ Name = "Hearthstone", ImageUrl = "hearthstone.png", Follow = false }
            };
		}
	}
}