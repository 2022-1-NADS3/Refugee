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
    public static class DadosByONGs
    {
        public static string NomeONG { get; set; }
        public static string EnderecoONG { get; set; }
        public static string TelefoneONG { get; set; }
        public static string ResponsavelONG { get; set; }
        public static string ServicoONG { get; set; }
        public static string HorarioONG { get; set; }
        public static string CapacidadeONG { get; set; }
        public static string LinguasONG { get; set; }
        public static string EmailONG { get; set; }
        public static string SenhaONG { get; set; }
        public static int ONGID { get; set; }

    }
    public partial class PaginaONGDetail : ContentPage
    {
        public PaginaONGDetail()
        {
            InitializeComponent();
            nomeONG.Text = DadosByONGs.NomeONG;
            enderecoONG.Text = DadosByONGs.EnderecoONG;
            telefoneONG.Text = DadosByONGs.TelefoneONG;
            responsavelONG.Text = DadosByONGs.ResponsavelONG;
            servicoONG.Text = DadosByONGs.ServicoONG;
            horarioONG.Text = DadosByONGs.HorarioONG;
            capacidadeONG.Text = DadosByONGs.CapacidadeONG;
            linguasONG.Text = DadosByONGs.LinguasONG;
            emailONG.Text = DadosByONGs.EmailONG;
            senhaONG.Text = DadosByONGs.SenhaONG;
        }
        async void SairByONG(object sender, EventArgs e)
        {
            nomeONG.Text = "";
            DadosByONGs.NomeONG = "";
            enderecoONG.Text = "";
            DadosByONGs.EnderecoONG = "";
            telefoneONG.Text = "";
            DadosByONGs.TelefoneONG = "";
            responsavelONG.Text = "";
            DadosByONGs.ResponsavelONG = "";
            servicoONG.Text = "";
            DadosByONGs.ServicoONG = "";
            horarioONG.Text = "";
            DadosByONGs.HorarioONG = "";
            capacidadeONG.Text = "";
            DadosByONGs.CapacidadeONG = "";
            linguasONG.Text = "";
            DadosByONGs.LinguasONG = "";
            emailONG.Text = "";
            DadosByONGs.EmailONG = "";
            senhaONG.Text = "";
            DadosByONGs.SenhaONG = "";
            await DisplayAlert("Tchau", @"Você foi deslogado", "OK");
            await Navigation.PushAsync(new MainPage());
        }
        async void AlterarDadosONG(object sender, EventArgs e)
        {
            await DisplayAlert("Atenção", @"Infelizmente essa função está sendo preparada", "Ok");
        }
    }
}