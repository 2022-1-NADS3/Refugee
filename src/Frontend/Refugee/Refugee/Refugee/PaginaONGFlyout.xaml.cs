﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Refugee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaONGFlyout : ContentPage
    {
        public ListView ListView;

        public PaginaONGFlyout()
        {
            InitializeComponent();

            BindingContext = new PaginaONGFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class PaginaONGFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PaginaONGFlyoutMenuItem> MenuItems { get; set; }

            public PaginaONGFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<PaginaONGFlyoutMenuItem>(new[]
                {
                    new PaginaONGFlyoutMenuItem { Id = 0, Title = "EditarDadosONG" },
                    new PaginaONGFlyoutMenuItem { Id = 1, Title = "Sair" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}