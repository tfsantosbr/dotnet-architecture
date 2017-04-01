using System.ComponentModel.DataAnnotations;
using Project.Resources.Core.Messages;

namespace Project.API.Core.Models.Conta
{
    public class ContaSolicitarRedefinicaoSenhaModel
    {
        /// <summary>
        ///     E-MAIL
        /// </summary>
        [Display(Name = "E-mail")]
        [Required(ErrorMessageResourceName = "REQUIRED_FIELD", ErrorMessageResourceType = typeof (VALIDATION_MESSAGES))]
        public virtual string Email { get; set; }
    }
}