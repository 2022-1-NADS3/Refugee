using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Refugee
{
    public static class DadosModel
    {
        public static string NomeModel { get; set; }
        public static string EmailModel { get; set; }
        public static string SenhaModel { get; set; }
        public static string SexoModel { get; set; }
        public static int UserId { get; set; }

    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilRefugiado : ContentPage
    {
        public PerfilRefugiado()
        {
            InitializeComponent();
        }
        private void AlterarDados(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlterarDadosRefugiadoOne());
        }
    }
}