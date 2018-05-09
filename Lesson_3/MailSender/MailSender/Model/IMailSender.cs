using System.Collections.ObjectModel;

namespace MailSender.Model
{
    public interface IMailSender
    {
        void MailSend(string args, string pswd);
        ObservableCollection<Dto.Email> SelectEmails();
        ObservableCollection<Dto.SmtpSettings> SelectSmtpSettings();
    }
}