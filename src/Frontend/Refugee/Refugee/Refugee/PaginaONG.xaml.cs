using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Refugee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaONG : FlyoutPage
    {
        public PaginaONG()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PaginaONGFlyoutMenuItem;
            if (item == null)
                return;
            if(item.Title == "EditarDadosONG")
            {
                Navigation.PushAsync(new TelaRefugiado());
            }
            else if(item.Title == "Sair")
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