using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MailSender.Validation
{
    public class ThemeValidation : ValidationRule
    {
        public override ValidationResult Validate(
            object value, 
            CultureInfo cultureInfo)
        {
            string theme = (string)value;

            if (theme.Length >= 100)
            {
                return new ValidationResult(false, "не больше 100 символов");
            }

            return new ValidationResult(true, null);
        }
    }
}
