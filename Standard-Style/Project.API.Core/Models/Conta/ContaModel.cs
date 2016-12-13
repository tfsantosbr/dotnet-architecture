using System.ComponentModel.DataAnnotations;
using Project.API.Base.Models;
using Project.Resources.Core.Messages;

namespace Project.API.Core.Models.Conta
{
    public class ContaModel : IdentityModelBase<long>, IIdentityModelBase<long>
    {
        /// <summary>
        ///     E-MAIL
        /// </summary>
        [Display(Name = "E-mail")]
        [Required(ErrorMessageResourceName = "REQUIRED_FIELD", ErrorMessageResourceType = typeof (VALIDATION_MESSAGES))]
        public virtual object Email { get; set; }
    }
}