using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TabelaConfig
{
    public partial class About : Page
    {
        public class Acao
        {
            public double Data { get; set; }
            public double Preco { get; set; }
        }

        public static List<Acao> Lista_acoes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Pagina da Tabela";

        }

        protected void BtnAcessaSite_Click(object sender, EventArgs e)
        {
            string json;
            using (WebClient webClient = new WebClient()) //Abrindo site que está contido o Json
            {
                json = webClient.DownloadString("https://query1.finance.yahoo.com/v8/finance/chart/PETR3.SA?period1=1598922000&period2=1604005200&interval=1d");
            }
            LendoJSON(json);
        }

        public void LendoJSON(string json)
        {
            JObject jObject = JObject.Parse(json); //Parse de string > JObject
            int qtd_acoes = jObject["chart"]["result"].ToArray()[0]["timestamp"].Count(); //Obtem os dados requeridos passando a chave de captura e efetuando a contagem de itens
            Acao acao;

            Lista_acoes = new List<Acao>();
            for (int i = 0; i < qtd_acoes; i++)
            {// lista com par: data e o valor
                acao = new Acao();
                acao.Data = Convert.ToDouble(jObject["chart"]["result"].ToArray()[0]["timestamp"][i]);
                acao.Preco = Convert.ToDouble(jObject["chart"]["result"].ToArray()[0]["indicators"]["quote"].ToArray()[0]["close"][i]);
                Lista_acoes.Add(acao);
                //Debug.WriteLine(jObject["chart"]["result"].ToArray()[0]["timestamp"][i]);
            }
            foreach (var item in Lista_acoes)
            {
                Debug.WriteLine(item.Data + ":" + item.Preco);
            }

            // Carregando tabela criada
            for (int i = 0; i < Lista_acoes.Count; i++)
            {
                TbPrecos.Rows.Add(new TableRow()); //Adicionando uma linha a tabela
                for (int j = 0; j < 2; j++)
                {
                    TbPrecos.Rows[i].Cells.Add(new TableCell());   //Adicionando colunas a linha referenciada[i]
                    if (j == 0)
                    {
                        DateTime data = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); //Para efetuar a conversão de data dos dados
                        data = data.AddSeconds(Lista_acoes[i].Data).ToLocalTime();
                        TbPrecos.Rows[i].Cells[j].Text = data.ToString();
                    }
                    else
                    {
                        TbPrecos.Rows[i].Cells[j].Text = Lista_acoes[i].Preco.ToString();
                    }
                }

            }
        }
    }
}