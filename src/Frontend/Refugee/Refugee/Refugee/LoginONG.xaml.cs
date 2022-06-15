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
    public class DadosONG
    {
        [JsonProperty("ongemail")]
        public string ongemail { get; set; }

        [JsonProperty("ongsenha")]
        public string ongsenha { get; set; }

    }

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

        async void LogandoOng(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailong.Text) || string.IsNullOrWhiteSpace(senhaong.Text))
            {
                await DisplayAlert("Atenção", @"Todos os campos tem que conter dados", "Beleza");
            }

            else
            {
                var httpClient = new HttpClient();
                var ongPost = new DadosONG
                {
                    ongemail = emailong.Text,
                    ongsenha = senhaong.Text
                };

                var json = JsonConvert.SerializeObject(ongPost);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // envia a requisição POST
                var uri = "https://app-refugee-fecap.herokuapp.com/login_ongs";
                var post = await httpClient.PostAsync(uri, content);
                var result = await post.Content.ReadAsStringAsync();
                JObject textresult = JsonConvert.DeserializeObject<JObject>(result);
                // exibe a saida no TextView 
                if (post.IsSuccessStatusCode && result.Contains(emailong.Text))
                {
                    //DadosModel.EmailModel = textresult["user_email"].ToString();
                    //DadosModel.NomeModel = textresult["user_name"].ToString();
                    //DadosModel.SenhaModel = textresult["user_password"].ToString();
                    //DadosModel.SexoModel = textresult["user_sex"].ToString();
                    //DadosModel.UserId = (int)textresult["user_id"];
                    await Navigation.PushAsync(new PaginaONG());
                }
                else
                {
                    await DisplayAlert("Atenção", @"Login Inválido, tente novamente", "Beleza");
                }
            }
        }
    }
}