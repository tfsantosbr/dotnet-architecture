using System.ComponentModel.DataAnnotations;
using Project.Resources.Core.Messages;

namespace Project.API.Core.Models.Conta
{
    public class ContaPostModel : ContaModel
    {
        /// <summary>
        ///     CONFIRMAR E-MAIL
        /// </summary>
        [Display(Name = "Confirmar E-mail")]
        [Required(ErrorMessageResourceName = "REQUIRED_FIELD", ErrorMessageResourceType = typeof (VALIDATION_MESSAGES))]
        public virtual object EmailConfirmar { get; set; }

        /// <summary>
        ///     SENHA
        /// </summary>
        [Display(Name = "Senha")]
        [Required(ErrorMessageResourceName = "REQUIRED_FIELD", ErrorMessageResourceType = typeof (VALIDATION_MESSAGES))]
        public virtual object Senha { get; set; }

        /// <summary>
        ///     CONFIRMAR SENHA
        /// </summary>
        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessageResourceName = "REQUIRED_FIELD", ErrorMessageResourceType = typeof (VALIDATION_MESSAGES))]
        public virtual object SenhaConfirmar { get; set; }
    }
}