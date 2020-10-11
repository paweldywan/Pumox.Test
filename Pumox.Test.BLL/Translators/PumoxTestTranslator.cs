using PDCore.Helpers.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pumox.Test.BLL.Translators
{
    public class PumoxTestTranslator : Translator
    {
        protected override Dictionary<string, Func<string>> Sentences => new Dictionary<string, Func<string>>
        {
            ["Passwords must have at least one non letter or digit character."] = () => Resources.ErrorMessages.PasswordSymbolRequred,
            ["Passwords must have at least one digit ('0'-'9')."] = () => Resources.ErrorMessages.PasswordDigitRequired,
            ["Passwords must have at least one uppercase ('A'-'Z')."] = () => Resources.ErrorMessages.PasswordUppercaseRequired,
            ["Passwords must have at least one lowercase ('a'-'z')."] = () => Resources.ErrorMessages.PasswordLowercaseRequired,
            ["Invalid token."] = () => Resources.Common.InvalidToken,
            ["is already taken"] = () => Resources.ErrorMessages.IsAlreadyTaken
        };

        protected override Dictionary<string, Func<string>> Words => new Dictionary<string, Func<string>>
        {
            ["Name"] = () => Resources.Common.Name,
            ["already"] = () => Resources.Common.already,
            ["taken"] = () => Resources.Common.taken
        };
    }
}
