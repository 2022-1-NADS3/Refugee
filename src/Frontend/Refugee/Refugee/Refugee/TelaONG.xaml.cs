using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Refugee
{
    //public class Objeto
    //{
    //    [JsonProperty("nome")]
    //    public string nome { get; set; }
    //    [JsonProperty("sobrenome")]
    //    public string sobrenome { get; set; }
    //    [JsonProperty("idade")]

    //    public int idade { get; set; }
    //    [JsonProperty("altura")]
    //    public float altura { get; set; }
    //}
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaONG : ContentPage
    {
        public TelaONG()
        {
            InitializeComponent();
        }
        //async void Dados(object sender, EventArgs e)
        //{
        //    var httpClient = new HttpClient();
        //    var resultados = await httpClient.GetStringAsync("http://132.1.2.12:3000/user");
        //    var resultadoFinal = JsonConvert.DeserializeObject<Objeto>(resultados);

        //    json.Text = resultados;
        //    userName.Text = resultadoFinal.nome;
        //    sureName.Text = resultadoFinal.sobrenome;
        //    userAge.Text = resultadoFinal.idade.ToString();
        //    userHeight.Text = resultadoFinal.altura.ToString();
        //}
    }
}