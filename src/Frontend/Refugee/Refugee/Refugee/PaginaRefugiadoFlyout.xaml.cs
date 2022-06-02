using System;
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
    public partial class PaginaRefugiadoFlyout : ContentPage
    {
        public ListView ListView;

        public PaginaRefugiadoFlyout()
        {
            InitializeComponent();

            BindingContext = new PaginaRefugiadoFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class PaginaRefugiadoFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PaginaRefugiadoFlyoutMenuItem> MenuItems { get; set; }

            public PaginaRefugiadoFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<PaginaRefugiadoFlyoutMenuItem>(new[]
                {
                    new PaginaRefugiadoFlyoutMenuItem { Id = 0, Title = "Perfil", Image = "perfil.png"},
                    new PaginaRefugiadoFlyoutMenuItem { Id = 1, Title = "Sair", Image = "sair.png"},
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