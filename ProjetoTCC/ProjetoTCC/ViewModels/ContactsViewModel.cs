using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoTCC.ViewModels
{
    class ContactsViewModel : BaseViewModel
    {
        public Command ConfirmCommand { get; }

        public ContactsViewModel()
        {
            ConfirmCommand = new Command(ExecuteConfirmCommand);
        }

        async void ExecuteConfirmCommand()
        {
            await PushAsync<PerfilViewModel>();
        }
    }
}
