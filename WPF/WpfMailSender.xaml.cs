using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace WPF
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class WpfMailSender : Window
	{
		private const int TEST =0;
		public int Pest;
		public WpfMailSender()
		{
			InitializeComponent();


			SendEndWindow sew = new SendEndWindow();
			sew.ShowDialog();
		}

		private void MailSender(string args)
		{
			var listStrMails = new List<string> { ConstSorage.TestEmailGmail, ConstSorage.EmailYandex };
			string strPassword = passwordBox.Password; 
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
						sc.Credentials = new NetworkCredential(ConstSorage.SenderYandex, strPassword);
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

		private void btnSendEmail_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
