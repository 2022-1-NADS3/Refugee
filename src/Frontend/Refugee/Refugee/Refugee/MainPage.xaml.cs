using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Refugee
{
    public partial class MainPage : ContentPage
    {
        private void LoginONGs(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginONG());
        }
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
