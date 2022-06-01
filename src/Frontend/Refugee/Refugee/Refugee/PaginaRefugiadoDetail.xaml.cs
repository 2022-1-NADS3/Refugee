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

        private void AbrirPaginaONG(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaONGDetail());
        }
    }
}