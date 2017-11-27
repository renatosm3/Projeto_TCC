using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjetoTCC.Models;
using ProjetoTCC.ViewModels;

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
                new GamesModel{ Name = "Counter-Strike Global Offensive", ImageUrl = "csgo.png", Follow = true },
                new GamesModel{ Name = "DOTA 2", ImageUrl = "dota.png", Follow = true },
                new GamesModel{ Name = "Hearthstone", ImageUrl = "hearthstone.png", Follow = true },
                new GamesModel{ Name = "League of Legends", ImageUrl = "lollogo.png", Follow = false },
                new GamesModel{ Name = "Overwatch", ImageUrl = "overwatch.png", Follow = true },
                new GamesModel{ Name = "PLAYERUNKNOWN'S BATTLEGROUNDS", ImageUrl = "pubg.png", Follow = false },
                new GamesModel{ Name = "World of Warcraft", ImageUrl = "wow.png", Follow = true }
            };

            BindingContext = new FollowViewModel();
        }
	}
}