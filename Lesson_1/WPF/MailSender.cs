using System;
using System.Collections.Generic;
using System.Windows;
using System.Net.Mail;
using System.Net;

namespace WPF
{
    public class MailSender
    {
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
    }
}
