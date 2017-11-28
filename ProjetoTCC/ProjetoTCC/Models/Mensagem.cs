using Humanizer;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCC
{
    public class Mensagem : ObservableObject
    {
        string nomeUsuario;

        public string NomeUsuario
        {
            get { return nomeUsuario; }
            set { SetProperty(ref nomeUsuario, value); }
        }

        string texto;

        public string Texto
        {
            get { return texto; }
            set { SetProperty(ref texto, value); }
        }

        DateTime horaEnvio;

        public DateTime HoraEnvio
        {
            get { return horaEnvio; }
            set { SetProperty(ref horaEnvio, value); }
        }

        //converte datetime em string
        public string horaEnvioString => HoraEnvio.Humanize();

        bool recebendo;

        public bool Recebendo
        {
            get { return recebendo; }
            set { SetProperty(ref recebendo, value); }
        }
    }
}
