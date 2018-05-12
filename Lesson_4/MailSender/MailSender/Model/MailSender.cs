using System;
using System.Collections.Generic;
using System.Windows;
using System.Net.Mail;
using System.Net;
using System.Collections.ObjectModel;
using WPF;

namespace MailSender.Model
{
    public class MailSender : IMailSender
    {
        private DbClientTest _dbTest;
        private ObservableCollection<Dto.Email> _email;
        private ObservableCollection<Dto.SmtpSettings> _smtpSettings;

        public MailSender()
        {
            _dbTest = new DbClientTest();
            _email = new ObservableCollection<Dto.Email>();
            _smtpSettings = new ObservableCollection<Dto.SmtpSettings>();
        }

        public void MailSend(string args, string pswd)
        {
            var listStrMails = new List<string> { ConstSorage.TestEmailGmail, ConstSorage.EmailYandex };

            foreach (var mail in listStrMails)
            {
                using (MailMessage mm = new MailMessage(ConstSorage.SenderYandex, mail))
                {
                    mm.Subject = ConstSorage.HelloFromC;
                    mm.Body = ConstSorage.HelloWorld;
                    mm.IsBodyHtml = false;

                    using (SmtpClient sc = new SmtpClient(ConstSorage.SmtpYandexClient, ConstSorage.SmtpYandexPort))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(ConstSorage.SenderYandex, pswd);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception)
                        {
                            var error = new Error();
                            error.ShowDialog();
                        }
                    }
                }
            }

            MessageBox.Show(ConstSorage.WorkEnd);
        }

        public ObservableCollection<Dto.Email> SelectEmails() =>
            _dbTest.SelectEmails();

        public ObservableCollection<Dto.SmtpSettings> SelectSmtpSettings() => 
            _dbTest.SelectSmtpSettings();

        public void InsertEmail(string email) => 
            _dbTest.Insert(email);
    }
}
