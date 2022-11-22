﻿using System;
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
    public class CadastroUsuario
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
        public string refudeficiencia    { get; set; }

        [JsonProperty("refuemail")]
        public string refuemail { get; set; }

        [JsonProperty("refusenha")]
        public string refusenha { get; set; }

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadRefugiado : ContentPage
    {

        public CadRefugiado()
        {
            InitializeComponent();
        }
        private void TenhoCadastroR(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginRefugiado());
        }

        async void Cadastrar(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nome.Text) || //string.IsNullOrWhiteSpace("")|| 
                //string.IsNullOrWhiteSpace("") ||
                string.IsNullOrWhiteSpace(idioma.Text) ||
                //string.IsNullOrWhiteSpace("") || string.IsNullOrWhiteSpace("") ||
                string.IsNullOrWhiteSpace(telefone.Text) || //string.IsNullOrWhiteSpace("") ||
                string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(senha.Text)){

                await DisplayAlert("Atenção", @"Todos os campos devem ser preenchidos", "Fechar");

            }
            else
            {
                var httpClient = new HttpClient();
                var refuiadoPost = new CadastroUsuario
                {
                    refuname = nome.Text,
                    refusexo = " ",
                    refupais = " ",
                    refuidioma = idioma.Text,
                    refuestadoCivil = " ",
                    refunumeroFilhos = " ",
                    refutelefone = telefone.Text,
                    refudeficiencia = " ",
                    refuemail = email.Text,
                    refusenha = senha.Text
                };

                var json = JsonConvert.SerializeObject(refuiadoPost);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var uri = "https://app-refugee-fecap.herokuapp.com/cadastrar_refugiados";
                var result = await httpClient.PostAsync(uri, content);

                if (result.IsSuccessStatusCode)
                {
                    await DisplayAlert("Sucesso", @"Cadastro realizado com sucesso", "Fechar");
                    await Navigation.PushAsync(new LoginRefugiado());
                }
            }
        }   
    }
}