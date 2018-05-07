using System.Collections.ObjectModel;
using WPF.Dto;

namespace WPF
{
    public interface IMailSender
    {
        void MailSend(string args, string pswd);
        ObservableCollection<Email> SelectEmails();
        ObservableCollection<SmtpSettings> SelectSmtpSettings();
    }
}