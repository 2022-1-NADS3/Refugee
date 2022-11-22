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
        public static class DadosByONGs
        {
            public static string NomeONG { get; set; }
            public static string CapacidadeONG { get; set; }
            public static string LocalOng { get; set; }
            public static string DistanciaOng { get; set; }
            public static string NomeONG2 { get; set; }
            public static string CapacidadeONG2 { get; set; }
            public static string LocalOng2 { get; set; }
            public static string DistanciaOng2 { get; set; }
            public static string NomeONG3 { get; set; }
            public static string CapacidadeONG3 { get; set; }
            public static string LocalOng3 { get; set; }
            public static string DistanciaOng3 { get; set; }
            public static string NomeONG4 { get; set; }
            public static string CapacidadeONG4 { get; set; }
            public static string LocalOng4 { get; set; }
            public static string DistanciaOng4 { get; set; }
            public static string NomeONG5 { get; set; }
            public static string CapacidadeONG5 { get; set; }
            public static string LocalOng5 { get; set; }
            public static string DistanciaOng5 { get; set; }
            public static string NomeONG6 { get; set; }
            public static string CapacidadeONG6 { get; set; }
            public static string LocalOng6 { get; set; }
            public static string DistanciaOng6 { get; set; }
            public static string NomeONG7 { get; set; }
            public static string CapacidadeONG7 { get; set; }
            public static string LocalOng7 { get; set; }
            public static string DistanciaOng7 { get; set; }
        }
        public PaginaRefugiadoDetail()
        {
            InitializeComponent();
            Nome_ong1.Text = DadosByONGs.NomeONG;
            Info_ong1.Text = DadosByONGs.CapacidadeONG;
            localong1.Text = DadosByONGs.LocalOng;
            dist_ong1.Text = DadosByONGs.DistanciaOng;

            Nome_ong2.Text = DadosByONGs.NomeONG2;
            Info_ong2.Text = DadosByONGs.CapacidadeONG2;
            localong2.Text = DadosByONGs.LocalOng2;
            dist_ong2.Text = DadosByONGs.DistanciaOng2;

            Nome_ong3.Text = DadosByONGs.NomeONG3;
            Info_ong3.Text = DadosByONGs.CapacidadeONG3;
            localong3.Text = DadosByONGs.LocalOng3;
            dist_ong3.Text = DadosByONGs.DistanciaOng3;

            Nome_ong4.Text = DadosByONGs.NomeONG4;
            Info_ong4.Text = DadosByONGs.CapacidadeONG4;
            localong4.Text = DadosByONGs.LocalOng4;
            dist_ong4.Text = DadosByONGs.DistanciaOng4;

            Nome_ong5.Text = DadosByONGs.NomeONG5;
            Info_ong5.Text = DadosByONGs.CapacidadeONG5;
            localong5.Text = DadosByONGs.LocalOng5;
            dist_ong5.Text = DadosByONGs.DistanciaOng5;

            Nome_ong6.Text = DadosByONGs.NomeONG6;
            Info_ong6.Text = DadosByONGs.CapacidadeONG6;
            localong6.Text = DadosByONGs.LocalOng6;
            dist_ong6.Text = DadosByONGs.DistanciaOng5;

            Nome_ong7.Text = DadosByONGs.NomeONG7;
            Info_ong7.Text = DadosByONGs.CapacidadeONG7;
            localong7.Text = DadosByONGs.LocalOng7;
            dist_ong7.Text = DadosByONGs.DistanciaOng7;
        }

        async void AbrirPaginaONG(object sender, EventArgs e)
        {
            await DisplayAlert("Desculpe-me", @"Infelizmente ainda não consigo te ajudar", "Ok");
        }
    }
}