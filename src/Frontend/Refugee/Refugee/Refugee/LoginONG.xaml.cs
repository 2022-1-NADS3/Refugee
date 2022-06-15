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
        async void EsqueceuSenha(object sender, EventArgs e)
        {
            await DisplayAlert("Desculpe-me", @"Infelizmente não consigo te ajudar nisso", "Entendo");
        }
        public LoginONG()
        {
            InitializeComponent();
        }

        async void LogandoOng(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailong.Text) || string.IsNullOrWhiteSpace(senhaong.Text))
            {
                await DisplayAlert("Atenção", @"Todos os campos devem ser preenchidos", "Fechar");
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

                    DadosByONGs.NomeONG = textresult["nome_ong"].ToString();
                    DadosByONGs.EnderecoONG = textresult["endereco_ong"].ToString();
                    DadosByONGs.TelefoneONG = textresult["telefone_ong"].ToString();
                    DadosByONGs.ResponsavelONG = textresult["responsavel_ong"].ToString();
                    DadosByONGs.ServicoONG = textresult["servico_ong"].ToString();
                    DadosByONGs.HorarioONG = textresult["horarioatendimento_ong"].ToString();
                    DadosByONGs.CapacidadeONG = textresult["capacidadedisponivel_ong"].ToString();
                    DadosByONGs.LinguasONG = textresult["linguasaceitas_ong"].ToString();
                    DadosByONGs.EmailONG = textresult["email_ong"].ToString();
                    DadosByONGs.SenhaONG = textresult["senha_ong"].ToString();
                    DadosByONGs.ONGID = (int)textresult["ong_id"];
                    await Navigation.PushAsync(new PaginaONG());
                }
                else
                {
                    await DisplayAlert("Atenção", @"Login Inválido, tente novamente", "Fechar");
                }
            }
        }
    }
}