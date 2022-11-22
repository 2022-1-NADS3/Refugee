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
using static Refugee.PaginaRefugiadoDetail;


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
        async void EsqueceuSenha(object sender, EventArgs e)
        {
            await DisplayAlert("Desculpe-me", @"Infelizmente não consigo te ajudar nisso", "Entendo");
        }
        public LoginRefugiado()
        {
            InitializeComponent();
        }

        async void Logado(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(emailrefugiado.Text) || string.IsNullOrWhiteSpace(senharefugiado.Text))
            {
                await DisplayAlert("Atenção", @"Todos os campos devem ser preenchidos", "Fechar");
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
                    DadosByRefugiado.NomeRefugiado = textresult["nome_refugiado"].ToString();
                    DadosByRefugiado.SexoRefugiado = textresult["sexo_refugiado"].ToString();
                    DadosByRefugiado.PaisRefugiado = textresult["pais_refugiado"].ToString();
                    DadosByRefugiado.IdiomaRefugiado = textresult["idioma_refugiado"].ToString();
                    DadosByRefugiado.EstadoCivilRefugiado = textresult["estadocivil_refugiado"].ToString();
                    DadosByRefugiado.NumeroFilhoRefugiado = textresult["numerofilhos_refugiado"].ToString();
                    DadosByRefugiado.TelefoneRefugiado = textresult["telefone_refugiado"].ToString();
                    DadosByRefugiado.DeficienciaRefugiado = textresult["deficiencia_refugiado"].ToString();
                    DadosByRefugiado.EmailRefugiado = textresult["email_refugiado"].ToString();
                    DadosByRefugiado.SenhaRefugiado = textresult["senha_refugiado"].ToString();
                    DadosByRefugiado.RefugiadoID = (int)textresult["refugiado_id"];
                    DadosByONGs.NomeONG = "ONG Nova Esperança";
                    DadosByONGs.CapacidadeONG = "248 VAGAS";
                    DadosByONGs.LocalOng = "Av. Brigadeiro Luís Antônio, 78";
                    DadosByONGs.DistanciaOng = "15 Km";

                    DadosByONGs.NomeONG2 = "ONG Bom Samaritano";
                    DadosByONGs.CapacidadeONG2 = "400 VAGAS";
                    DadosByONGs.LocalOng2 = "Rua do Lavapés, 981";
                    DadosByONGs.DistanciaOng2 = "19 Km";

                    DadosByONGs.NomeONG3 = "ONG Vila 567";
                    DadosByONGs.CapacidadeONG3 = "278 VAGAS";
                    DadosByONGs.LocalOng3 = "Vila Madalena, 567";
                    DadosByONGs.DistanciaOng3 = "20 Km";

                    DadosByONGs.NomeONG4 = "ONG Nova São Paulo";
                    DadosByONGs.CapacidadeONG4 = "700 VAGAS";
                    DadosByONGs.LocalOng4 = "Av. Duque de Caxias , 763";
                    DadosByONGs.DistanciaOng4 = "43 Km";

                    DadosByONGs.NomeONG5 = "ONG Bom Jesus";
                    DadosByONGs.CapacidadeONG5 = "532 VAGAS";
                    DadosByONGs.LocalOng5 = "Av. Elixio Teixeira Leite, 240";
                    DadosByONGs.DistanciaOng5 = "52 Km";

                    DadosByONGs.NomeONG6 = "ONG Parque Isabel";
                    DadosByONGs.CapacidadeONG6 = "15 VAGAS";
                    DadosByONGs.LocalOng6 = "Parque Isabel, 645";
                    DadosByONGs.DistanciaOng6 = "70 Km";

                    DadosByONGs.NomeONG7 = "ONG Vida Nova";
                    DadosByONGs.CapacidadeONG7 = "40 VAGAS";
                    DadosByONGs.LocalOng7 = "Rua da Esperança, 30";
                    DadosByONGs.DistanciaOng7 = "80 Km";

                    await Navigation.PushAsync(new PaginaRefugiado());
                }
                else
                {
                    await DisplayAlert("Atenção", @"Login Inválido, tente novamente", "Fechar");
                }
            }
        }
    }
}