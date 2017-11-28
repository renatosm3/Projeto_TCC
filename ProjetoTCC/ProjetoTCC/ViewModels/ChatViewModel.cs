using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoTCC
{
    public class ChatViewModel : BaseViewModel
    {
        public Command goParticipantesCommand { get; }

        async void ExecutegoParticipantesCommand()
        {
            await PushAsync<ParticipantesViewModel>();
        }

        public ObservableRangeCollection<Mensagem> Mensagens { get; }
        ITwilio twilio;

        string mensagemEnviada = string.Empty;

        public string MensagemEnviada
        {
            get { return mensagemEnviada; }
            set { SetProperty(ref mensagemEnviada, value); }
        }

        public ICommand EnviarMensagemCommand { get; set; }
        
        public ChatViewModel()
        {
            goParticipantesCommand = new Command(ExecutegoParticipantesCommand);

            twilio = DependencyService.Get<ITwilio>();
            
            Mensagens = new ObservableRangeCollection<Mensagem>();

            EnviarMensagemCommand = new Command(() =>
            {
                var mensagem = new Mensagem
                {
                    Texto = MensagemEnviada,
                    Recebendo = false,
                    HoraEnvio = DateTime.Now
                };


                Mensagens.Add(mensagem);

                twilio?.EnviarMensagem(mensagem.Texto);

                MensagemEnviada = string.Empty;
            });

            if (twilio == null)
                return;

            twilio.MensagemAdicionada = (mensagem) =>
            {
                Mensagens.Add(mensagem);
            };
        }
    }
}
