using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoTCC
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventPage : TabbedPage
	{
		public EventPage()
		{
			InitializeComponent ();

            Grupos.ItemsSource = new List<GroupModel>
            {

                new GroupModel{ NomeJogo = "Counter-Strike: Global Offensive", ImageUrl = "csgo.png", Name = "MIX da madrugada" },
                new GroupModel{ NomeJogo = "Counter-Strike: Global Offensive", ImageUrl = "csgo.png", Name = "MIX Ribeirão Preto" },
                new GroupModel{ NomeJogo = "DOTA 2", ImageUrl = "dota.png", Name = "Grupo dos 4K MMR" },
                new GroupModel{ NomeJogo = "DOTA 2", ImageUrl = "dota.png", Name = "Grupo dos 9K MMR" },
                new GroupModel{ NomeJogo = "Hearthstone", ImageUrl = "hearthstone.png", Name = "Dicas Rank 5" },
                new GroupModel{ NomeJogo = "Hearthstone", ImageUrl = "hearthstone.png", Name = "Grupo dos Legends" },
                new GroupModel{ NomeJogo = "Overwatch", ImageUrl = "overwatch.png", Name = "D.Va Best waifu" },
                new GroupModel{ NomeJogo = "Overwatch", ImageUrl = "overwatch.png", Name = "Mei Best waifu" },
                new GroupModel{ NomeJogo = "World of Warcraft", ImageUrl = "wow.png", Name = "Grupo da Aliança" },
                new GroupModel{ NomeJogo = "World of Warcraft", ImageUrl = "wow.png", Name = "Grupo da Horda" },
            };

            Games.ItemsSource = new List<GamesModel>
            {

                new GamesModel{ Name = "Counter-Strike: Global Offensive", ImageUrl = "csgo.png", Follow = true },
                new GamesModel{ Name = "DOTA 2", ImageUrl = "dota.png", Follow = true },
                new GamesModel{ Name = "Hearthstone", ImageUrl = "hearthstone.png", Follow = true },
                new GamesModel{ Name = "League of Legends", ImageUrl = "lollogo.png", Follow = false },
                new GamesModel{ Name = "Overwatch", ImageUrl = "overwatch.png", Follow = true },
                new GamesModel{ Name = "PLAYERUNKNOWN'S BATTLEGROUNDS", ImageUrl = "pubg.png", Follow = false },
                new GamesModel{ Name = "World of Warcraft", ImageUrl = "wow.png", Follow = false }
            };
            BindingContext = new EventViewModel();
        }
        
    }
}