using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MailSender.Validation
{
    public class PasswordValidation : ValidationRule
    {
        public override ValidationResult Validate(
            object value, 
            CultureInfo cultureInfo)
        {
            string pass = (string)value;

            if (string.IsNullOrEmpty(pass))
            {
                return new ValidationResult(false, "Пароль не должен быть пустым ");

            } else if (pass.Length < 8)
            {
                return new ValidationResult(false, "Пароль должен быть не менее 8 символов");
            }

            return new ValidationResult(true, null);
        }
    }
}
