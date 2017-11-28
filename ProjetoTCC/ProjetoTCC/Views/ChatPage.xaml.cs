using ProjetoTCC.ViewModels;
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
	public partial class ChatPage : ContentPage
	{

        ChatViewModel chat;
        public ChatPage ()
		{
			InitializeComponent ();

            BindingContext = new ChatViewModel();


            //alterar título com grupo criado
            Title = "Mix da Uniseb";
            BindingContext = chat = new ChatViewModel();

            //acompanha as mudanças da lista de mensagem
            chat.Mensagens.CollectionChanged += (sender, e) => {
                var ultimaMsg = chat.Mensagens[chat.Mensagens.Count - 1];
                lvMensagens.ScrollTo(ultimaMsg, ScrollToPosition.End, true);
            };

        }

        void lvMensagens_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lvMensagens.SelectedItem = null;
        }

        void lvMensagens_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            lvMensagens.SelectedItem = null;

        }
    }
}