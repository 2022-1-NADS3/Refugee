using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace Refugee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public static class DadosByRefugiado
    {
        public static string NomeRefugiado { get; set; }
        public static string SexoRefugiado { get; set; }
        public static string PaisRefugiado { get; set; }
        public static string IdiomaRefugiado { get; set; }
        public static string EstadoCivilRefugiado { get; set; }
        public static string NumeroFilhoRefugiado { get; set; }
        public static string TelefoneRefugiado{ get; set; }
        public static string DeficienciaRefugiado { get; set; }
        public static string EmailRefugiado { get; set; }
        public static string SenhaRefugiado { get; set; }
        public static int RefugiadoID { get; set; }

    }

    public class DadosUseRefugiado
    {
        [JsonProperty("refuname")]
        public string refuname { get; set; }

        [JsonProperty("refusexo")]
        public string refusexo { get; set; }

        [JsonProperty("refupais")]
        public string refupais { get; set; }

        [JsonProperty("refuidioma")]
        public string refuidioma { get; set; }

        [JsonProperty("refuestadoCivil")]
        public string refuestadoCivil { get; set; }

        [JsonProperty("refunumeroFilhos")]
        public string refunumeroFilhos { get; set; }

        [JsonProperty("refutelefone")]
        public string refutelefone { get; set; }

        [JsonProperty("refudeficiencia")]
        public string refudeficiencia { get; set; }

        [JsonProperty("refuemail")]
        public string refuemail { get; set; }

        [JsonProperty("refusenha")]
        public string refusenha { get; set; }

    }
    public partial class PerfilRefugiado : ContentPage
    {
        public PerfilRefugiado()
        {
            InitializeComponent();
            nomeRefugiado.Text = DadosByRefugiado.NomeRefugiado;
            sexorefugiado.Text = DadosByRefugiado.SexoRefugiado;
            paisrefugiado.Text = DadosByRefugiado.PaisRefugiado;
            idiomarefugiado.Text = DadosByRefugiado.IdiomaRefugiado;
            esdatocivil.Text = DadosByRefugiado.EstadoCivilRefugiado;
            numerofilhos.Text = DadosByRefugiado.NumeroFilhoRefugiado;
            telefonerefugiado.Text = DadosByRefugiado.TelefoneRefugiado;
            deficiencia.Text = DadosByRefugiado.DeficienciaRefugiado;
            emailrefugiado.Text = DadosByRefugiado.EmailRefugiado;
            senharefugiado.Text = DadosByRefugiado.SenhaRefugiado;
        }
        private void AlterarDados(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlterarDadosRefugiadoOne());
        }
    }
}