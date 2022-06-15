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
    public partial class PaginaRefugiadoDetail : ContentPage
    {
        public PaginaRefugiadoDetail()
        {
            InitializeComponent();
        }

        async void AbrirPaginaONG(object sender, EventArgs e)
        {
            await DisplayAlert("Desculpe-me", @"Infelizmente ainda não consigo te ajudar", "Ok");
        }
    }
}