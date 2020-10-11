using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Pumox.Test.Web.Models
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "ExternalAccessToken", ResourceType = typeof(Resources.Common))]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType = typeof(Resources.Common))]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "StringLength_GreaterAndLess", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(Resources.Common))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Common))]
        [Compare("NewPassword", ErrorMessageResourceName = "Compare", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "StringLength_GreaterAndLess", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Common))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Common))]
        [Compare("Password", ErrorMessageResourceName = "Compare", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "LoginProvider", ResourceType = typeof(Resources.Common))]
        public string LoginProvider { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "ProviderKey", ResourceType = typeof(Resources.Common))]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "StringLength_GreaterAndLess", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(Resources.Common))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Common))]
        [Compare("NewPassword", ErrorMessageResourceName = "Compare", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        public string ConfirmPassword { get; set; }
    }
}
