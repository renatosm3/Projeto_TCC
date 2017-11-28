using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCC
{
    public static class TokenControll
    {
        public static string Identidade { get; private set; }

        public static async Task<string> RecuperarToken()
        {
            var id = CrossDeviceInfo.Current.Id;
            string iden = "furtss";
            var tokenUrl = $"http://a8a8155c.ngrok.io/token?device={id}&identity={iden}";

            var http = new HttpClient();
            var json = await http.GetStringAsync(tokenUrl).ConfigureAwait(false);;

            var resposta = Newtonsoft.Json.JsonConvert.DeserializeObject<RepostaServidor>(json);

            Identidade = resposta.Identity?.Trim('"') ?? string.Empty;

            return resposta?.Token?.Trim('"') ?? string.Empty;
            
        }
    }

    public class RepostaServidor
    {
        [Newtonsoft.Json.JsonProperty("identity")]
        public string Identity { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; } = string.Empty;
    }
}
