﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ProjetoTCC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new ProjetoTCC.MainPage();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    //public static class ViewModelLocator
    //{
    //    static ChatViewModel chatVM;
    //    public static ChatViewModel ChatViewModel
    //    {
    //        get
    //        {
    //            if (chatVM == null)
    //            {
    //                chatVM = new ChatViewModel();
    //            }
    //            return chatVM;

    //        }
    //    }

    //}
}
