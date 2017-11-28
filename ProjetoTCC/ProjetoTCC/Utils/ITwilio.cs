using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCC
{
    public interface ITwilio
    {
        Task<bool> Inicializar();

        void EnviarMensagem(string texto);

        Action<Mensagem> MensagemAdicionada { get; set; }

    }
}
