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
                new GamesModel{ Name = "Game A", ImageUrl = "images/default.jpg", Follow = false },
                new GamesModel{ Name = "Game B", ImageUrl = "images/default.jpg", Follow = true },
                new GamesModel{ Name = "Game C", ImageUrl = "images/default.jpg", Follow = false }
            };
		}
	}
}