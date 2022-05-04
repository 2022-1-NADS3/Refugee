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
    public partial class CadRefugiado : ContentPage
    {
        private void TenhoCadastroR(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginRefugiado());
        }
        public CadRefugiado()
        {
            InitializeComponent();
        }
    }
}