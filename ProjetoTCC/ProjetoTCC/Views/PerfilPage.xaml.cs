using ProjetoTCC.Models;
using ProjetoTCC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilPage : ContentPage
    {
        public PerfilPage()
        {
            InitializeComponent();
            Games.ItemsSource = new List<GamesModel>
            {
                new GamesModel{ Name = "Counter-Strike: Global Offensive", ImageUrl = "csgo.png", Follow = false },
                new GamesModel{ Name = "Hearthstone", ImageUrl = "hearthstone.png", Follow = true },
                new GamesModel{ Name = "League of Legends", ImageUrl = "lollogo.png", Follow = false },
                new GamesModel{ Name = "Overwatch", ImageUrl = "overwatch.png", Follow = true },
                new GamesModel{ Name = "World of Warcraft", ImageUrl = "wow.png", Follow = false }
            };
            BindingContext = new PerfilViewModel();
        }
    }
}