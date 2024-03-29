﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Refugee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaRefugiado : FlyoutPage
    {
        public PaginaRefugiado()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PaginaRefugiadoFlyoutMenuItem;
            if (item == null)
                return;

            if(item.Title == "Perfil")
            {
                Navigation.PushAsync(new PerfilRefugiado());
            }
            
            else if (item.Title == "Sair")
            {
                Navigation.PushAsync(new MainPage());
            }

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Detail = new NavigationPage(page);
            //IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}