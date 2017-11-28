using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Widget;
using Twilio.Common;
using Twilio.IPMessaging;
using System.Threading.Tasks;
using Plugin.DeviceInfo;

namespace ProjetoTCC.Droid
{
    public class TwilioController : Java.Lang.Object, ITwilio, IPMessagingClientListener, IChannelListener, ITwilioAccessManagerListener
    {
        public ITwilioIPMessagingClient Client { get; private set; }
        public static IChannel GeneralChannel { get; private set; }
        
        public Action<Mensagem> MensagemAdicionada { get; set; }


        public async Task<bool> Inicializar()
        {
            var task = new TaskCompletionSource<bool>();
            if (!TwilioIPMessagingSDK.IsInitialized)
            {
                TwilioIPMessagingSDK.InitializeSDK(Xamarin.Forms.Forms.Context, new InitListener
                {
                    InitializedHandler = async delegate
                    {
                        await SetupAsync();
                        task.SetResult(true);
                    },
                    ErrorHandler = err =>
                    {
                        task.SetResult(false);
                    }
                });
            }
            else
            {
                return await SetupAsync();
            }

            return await task.Task.ConfigureAwait(false);
        }

        async Task<bool> SetupAsync()
        {
            var task = new TaskCompletionSource<bool>();
            var token = await TokenControll.RecuperarToken();
            var accessManager = TwilioAccessManagerFactory.CreateAccessManager(token, this);
            Client = TwilioIPMessagingSDK.CreateIPMessagingClientWithAccessManager(accessManager, this);

            IChannel[] channelo = Client.Channels.GetChannels();

            
            Client.Channels.LoadChannelsWithListener(new StatusListener
            {
                SuccessHandler = () =>
                {
                    IChannel[] channel = Client.Channels.GetChannels();
                    GeneralChannel = Client.Channels.GetChannelByUniqueName("general");

                    if (GeneralChannel != null)
                    {
                        GeneralChannel.Listener = this;
                        JoinGeneralChannel();
                    }
                    else
                    {
                        CreateAndJoinGeneralChannel();
                    }

                    task.SetResult(true);
                }
            });

            return await task.Task.ConfigureAwait(false);
        }

        void CreateAndJoinGeneralChannel()
        {
            var options = new Dictionary<string, Java.Lang.Object>();
            options["friendlyName"] = "General Chat Channel";
            options["ChannelType"] = ChannelChannelType.ChannelTypePublic;
            Client.Channels.CreateChannel(options, new CreateChannelListener
            {
                OnCreatedHandler = channel =>
                {
                    GeneralChannel = channel;
                    channel.SetUniqueName("general", new StatusListener
                    {
                        SuccessHandler = () => { Console.WriteLine("set unique name successfully!"); }
                    });
                    JoinGeneralChannel();
                },
                OnErrorHandler = () => { }
            });
        }

        void JoinGeneralChannel()
        {
            GeneralChannel?.Join(new StatusListener
            {
                SuccessHandler = () =>
                {

                }
            });
        }

        async Task<bool> Conectar()
        {
            var task = new TaskCompletionSource<bool>();
            var token = await TokenControll.RecuperarToken();
            var accessManager = TwilioAccessManagerFactory.CreateAccessManager(token, this);
            Client = TwilioIPMessagingSDK.CreateIPMessagingClientWithAccessManager(accessManager, this);

            return await task.Task.ConfigureAwait(false);
        }

        //lista os canais
        async Task<bool> ListarCanais()
        {
            var task = new TaskCompletionSource<bool>();
            Client.Channels.LoadChannelsWithListener(new StatusListener
            {
                SuccessHandler = () =>
                {
                    IChannel[] channel = Client.Channels.GetChannels();

                    task.SetResult(true);
                }
            });

            return await task.Task.ConfigureAwait(false);
        }

        void CriarCanal(string nomeCanal)
        {
            var opcoes = new Dictionary<string, Java.Lang.Object>();
            opcoes["friendlyName"] = nomeCanal;
            opcoes["ChannelType"] = ChannelChannelType.ChannelTypePublic;
            Client.Channels.CreateChannel(opcoes, new CreateChannelListener
            {
                OnCreatedHandler = channel =>
                {
                    GeneralChannel = channel;
                    channel.SetUniqueName("general", new StatusListener
                    {
                        SuccessHandler = () => { }
                    });
                    this.JoinGeneralChannel();
                },
                OnErrorHandler = () => { }
            });
        }

        public void EnviarMensagem(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto) || GeneralChannel == null)
                return;

            var mensagem = GeneralChannel.Messages.CreateMessage(texto);

            GeneralChannel.Messages.SendMessage(mensagem, new StatusListener
            {
                SuccessHandler = () =>
                {
                    
                }
            });
        }
        

        public void OnAttributesChange(string p0)
        {
        }

        public void OnChannelAdd(IChannel p0)
        {
        }

        public void OnChannelChange(IChannel p0)
        {
        }

        public void OnChannelDelete(IChannel p0)
        {
        }

        public void OnChannelHistoryLoaded(IChannel p0)
        {
        }

        public void OnError(IErrorInfo p0)
        {
        }

        public void OnUserInfoChange(IUserInfo p0)
        {
        }

        public void OnAttributesChange(IDictionary<string, string> p0)
        {
        }

        public void OnMemberChange(IMember p0)
        {
        }

        public void OnMemberDelete(IMember p0)
        {
        }

        public void OnMemberJoin(IMember member)
        {
            //trocar para nome do usuario
            Toast.MakeText(Xamarin.Forms.Forms.Context, $"{member.UserInfo.Identity} entrou no servidor!", ToastLength.Long).Show();
        }

        public void OnMessageAdd(IMessage mensagem)
        {
            if (mensagem.Author == TokenControll.Identidade)
                return;

            MensagemAdicionada?.Invoke(new Mensagem
                {
                    Recebendo = true,
                    HoraEnvio = DateTime.Parse(mensagem.TimeStamp),
                    Texto = mensagem.MessageBody
                });
            }

        public void OnError(ITwilioAccessManager p0, string p1)
        {
        }

        public void OnTokenExpired(ITwilioAccessManager p0)
        {
        }

        public void OnTokenUpdated(ITwilioAccessManager p0)
        {
        }

        public void OnMessageChange(IMessage p0)
        {
        }

        public void OnMessageDelete(IMessage p0)
        {
        }

        public void OnTypingEnded(IMember p0)
        {
        }

        public void OnTypingStarted(IMember p0)
        {
        }
    }
    
    public class CreateChannelListener : ConstantsCreateChannelListener
    {
        public Action<IChannel> OnCreatedHandler { get; set; }
        public Action OnErrorHandler { get; set; }

        public override void OnCreated(IChannel channel)
        {
            OnCreatedHandler?.Invoke(channel);
        }

        public override void OnError(IErrorInfo errorInfo)
        {
            base.OnError(errorInfo);
        }
    }

}