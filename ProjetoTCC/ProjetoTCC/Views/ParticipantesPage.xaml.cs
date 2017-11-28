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
	public partial class ParticipantesPage : ContentPage
	{

		public ParticipantesPage()
		{

            InitializeComponent();

            contatos.ItemsSource = new List<GamesModel>
            {
                new GamesModel{ Name = "OrigPrankster", Descricao = "André Luiz", Follow = true },
                new GamesModel{ Name = "WolfSilver", Descricao = "Renato Oliveira", Follow = false },
                new GamesModel{ Name = "Vini", Descricao = "Vinícius Furtado", Follow = true }
            };
            BindingContext = new ParticipantesPage();

		}
	}
}