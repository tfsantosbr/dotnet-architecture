using System.ComponentModel.DataAnnotations;
using Project.Resources.Core.Messages;

namespace Project.API.Core.Models.Conta
{
    public class ContaRedefinirSenhaViewModel
    {
        // SENHA
        [Display(Name = "Senha")]
        [Required(ErrorMessageResourceName = "REQUIRED_FIELD", ErrorMessageResourceType = typeof (VALIDATION_MESSAGES))]
        public virtual string Senha { get; set; }

        // CONFIRMAR SENHA
        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessageResourceName = "REQUIRED_FIELD", ErrorMessageResourceType = typeof (VALIDATION_MESSAGES))]
        public virtual string ConfirmarSenha { get; set; }
    }
}