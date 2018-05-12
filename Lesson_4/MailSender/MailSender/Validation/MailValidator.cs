using System;
using System.Globalization;
using System.Windows.Controls;
using System.Net.Mail;
using System.Windows;

namespace MailSender.Validation
{
    public class MailValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Недопустимые символы.");
            }

            string email = (string)value;

            try
            {
                MailAddress mail = new MailAddress(email);

                return new ValidationResult(true, null);
            }
            catch(FormatException)
            {
                return new ValidationResult(false, "Недопустимые символы.");
            }
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
        }
    }
}