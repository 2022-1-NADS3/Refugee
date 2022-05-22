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
    public partial class LoginRefugiado : ContentPage
    {
        private void Logar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TelaRefugiado());
        }
        private void FazerCadastroR(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadRefugiado());
        }
        public LoginRefugiado()
        {
            InitializeComponent();
        }
    }
}