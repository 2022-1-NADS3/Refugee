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
    public class DadosRefugiado
    {
        [JsonProperty("refuemail")]
        public string refuemail { get; set; }

        [JsonProperty("refusenha")]
        public string refusenha { get; set; }

    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginRefugiado : ContentPage
    {
        private void Logar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaRefugiado());
        }
        private void FazerCadastroR(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadRefugiado());
        }
        public LoginRefugiado()
        {
            InitializeComponent();
        }

        async void Logado(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(emailrefugiado.Text) || string.IsNullOrWhiteSpace(senharefugiado.Text))
            {
                await DisplayAlert("Atenção", @"Todos os campos tem que conter dados", "Beleza");
            }
            else
            {
                var httpClient = new HttpClient();
                var refugiadoPost = new DadosRefugiado
                {
                    refuemail = emailrefugiado.Text,
                    refusenha = senharefugiado.Text
                };

                var json = JsonConvert.SerializeObject(refugiadoPost);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // envia a requisição POST
                var uri = "https://app-refugee-fecap.herokuapp.com/login_refugiado";
                var post = await httpClient.PostAsync(uri, content);
                var result = await post.Content.ReadAsStringAsync();
                JObject textresult = JsonConvert.DeserializeObject<JObject>(result);
                // exibe a saida no TextView 
                if (post.IsSuccessStatusCode && result.Contains(emailrefugiado.Text))
                {
                    //DadosModel.EmailModel = textresult["user_email"].ToString();
                    //DadosModel.NomeModel = textresult["user_name"].ToString();
                    //DadosModel.SenhaModel = textresult["user_password"].ToString();
                    //DadosModel.SexoModel = textresult["user_sex"].ToString();
                    //DadosModel.UserId = (int)textresult["user_id"];
                    await Navigation.PushAsync(new PaginaRefugiado());
                }
                else
                {
                    await DisplayAlert("Atenção", @"Login Inválido, tente novamente", "Beleza");
                }
            }
        }
    }
}