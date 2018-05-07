using Autofac;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
	{
        public App()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MailSender>().As<IMailSender>();
            builder.RegisterType<VM>().AsSelf();

            var container = builder.Build();
            var model = container.Resolve<VM>();
            var view = new WpfMailSender { DataContext = model };

            view.Show();
        }
    }
}
