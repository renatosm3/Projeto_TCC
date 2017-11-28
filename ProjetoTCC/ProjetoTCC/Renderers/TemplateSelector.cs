using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//permite usar diferentes renderers para o mesmo objeto
namespace ProjetoTCC
{
    class TemplateSelector : DataTemplateSelector
    {
        public TemplateSelector()
        {
            this.mensagemEnviadaTemplate = new DataTemplate(typeof(MensagemEnviada));
            this.mensagemRecebidaTemplate = new DataTemplate(typeof(MensagemRecebida));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var mensagem = item as Mensagem;
            if (mensagem == null)
                return null;
            return mensagem.Recebendo ? this.mensagemRecebidaTemplate : this.mensagemEnviadaTemplate;
        }

        private readonly DataTemplate mensagemEnviadaTemplate;
        private readonly DataTemplate mensagemRecebidaTemplate;
    }
}
