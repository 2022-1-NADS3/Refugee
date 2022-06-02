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
    public partial class LoginONG : ContentPage
    {
        private void Logar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaONG());
        }
        private void FazerCadastroO(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadONG());
        }
        public LoginONG()
        {
            InitializeComponent();
        }
    }
}