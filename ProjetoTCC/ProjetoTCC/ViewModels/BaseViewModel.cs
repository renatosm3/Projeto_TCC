using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;

namespace ProjetoTCC
{
    public class BaseViewModel : MvvmHelpers.BaseViewModel
    {
    
        public async Task PushAsync<TViewMovel>(params object[] args) where TViewMovel : BaseViewModel {
            var viewModelType = typeof(TViewMovel);

            var viewModelTypeName = viewModelType.Name;
            var viewModelWordLength = "ViewModel".Length;
            var viewTypeName = $"ProjetoTCC.Views.{viewModelTypeName.Substring(0,viewModelTypeName.Length - viewModelWordLength)}Page";
            var viewType = Type.GetType(viewTypeName);

            var page = Activator.CreateInstance(viewType) as Page;

            var viewModel = Activator.CreateInstance(viewModelType, args);
            if (page != null) {
                page.BindingContext = viewModel;
            }

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
