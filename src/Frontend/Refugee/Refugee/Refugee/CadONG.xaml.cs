using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;

namespace Refugee
{
    public class CadastroONG
    {
        [JsonProperty("ongname")]
        public string ongname { get; set; }

        [JsonProperty("ongendereco")]
        public string ongendereco { get; set; }

        [JsonProperty("ongtelefone")]
        public string ongtelefone { get; set; }

        [JsonProperty("ongresponsavel")]
        public string ongresponsavel { get; set; }

        [JsonProperty("ongservico")]
        public string ongservico { get; set; }

        [JsonProperty("onghorario")]
        public string onghorario { get; set; }

        [JsonProperty("ongcapacidade")]
        public string ongcapacidade { get; set; }

        [JsonProperty("onglinguas")]
        public string onglinguas { get; set; }

        [JsonProperty("ongemail")]
        public string ongemail { get; set; }

        [JsonProperty("ongsenha")]
        public string ongsenha { get; set; }

    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadONG : ContentPage
    {
        public CadONG()
        {
            InitializeComponent();
        }
        private void TenhoCadastroO(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginONG());
        }
        
        async void CadastrarONG(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nomeONG.Text) || string.IsNullOrWhiteSpace(endereco.Text) ||
               string.IsNullOrWhiteSpace(telefone.Text) || string.IsNullOrWhiteSpace(responsavel.Text) ||
               string.IsNullOrWhiteSpace(servico.Text) || string.IsNullOrWhiteSpace(horaAtende.Text) ||
               string.IsNullOrWhiteSpace(capacidade.Text) || string.IsNullOrWhiteSpace(linguasAceitas.Text) ||
               string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(senha.Text))
            {
                await DisplayAlert("Atenção", @"Todos os campos devem ser preenchidos", "Fechar");
            }
            else
            {
                var httpClient = new HttpClient();
                var ongPost = new CadastroONG
                {
                    ongname = nomeONG.Text,
                    ongendereco = endereco.Text,
                    ongtelefone = telefone.Text,
                    ongresponsavel = responsavel.Text,
                    ongservico = servico.Text,
                    onghorario = horaAtende.Text,
                    ongcapacidade = capacidade.Text,
                    onglinguas = linguasAceitas.Text,
                    ongemail = email.Text,
                    ongsenha = senha.Text
                };

                var json = JsonConvert.SerializeObject(ongPost);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var uri = "https://app-refugee-fecap.herokuapp.com/cadastrar_ongs";
                var result = await httpClient.PostAsync(uri, content);

                if (result.IsSuccessStatusCode)
                {
                    await Navigation.PushAsync(new LoginONG());
                }
            }
        }
    }
}