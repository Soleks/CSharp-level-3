using System;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;

namespace MailExample
{
	internal class Program
	{
		static void Main()
		{
			MailMessage mm = new MailMessage("оправитель@yandex.ru", "получатель@yandex.ru")
			{
				Subject = "Заголовок письма",
				Body = "Содержимое письма"
			};

			// Авторизуемся на smtp-сервере и отправляем письмо
			SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25)
			{
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential("отправитель@yandex.ru", "password")
			};

			try
			{
				sc.Send(mm);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Невозможно отправить письмо {ex}");
			}
			 
		}
	}
}
