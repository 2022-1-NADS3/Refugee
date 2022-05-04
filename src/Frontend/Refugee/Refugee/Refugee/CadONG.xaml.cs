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
    public partial class CadONG : ContentPage
    {
        private void TenhoCadastroO(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginONG());
        }
        public CadONG()
        {
            InitializeComponent();
        }
    }
}