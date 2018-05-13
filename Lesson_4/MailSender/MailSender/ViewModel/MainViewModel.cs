using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using MailSender.Model;

namespace MailSender.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IMailSender _sender;
        private ObservableCollection<Dto.Email> _emails;
        private ObservableCollection<Dto.SmtpSettings> _smtp;

        public RelayCommand SendCommand { get; set; }
        public RelayCommand SaveEmailCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IMailSender sender)
        {
            _sender = sender;
            Emails = _sender.SelectEmails();
            Smtp = _sender.SelectSmtpSettings();

            SendCommand = new RelayCommand(
               () => _sender.MailSend(Message, Pass),
               () => !string.IsNullOrEmpty(Message) &&
                     !string.IsNullOrEmpty(Pass));

            SaveEmailCommand = new RelayCommand(
                () => _sender.InsertEmail(Email));
        }

        public ObservableCollection<Dto.Email> Emails
        {
            get => _emails;

            set
            {
                _emails = value;

                RaisePropertyChanged(nameof(Emails));
            }
        }

        public ObservableCollection<Dto.SmtpSettings> Smtp
        {
            get => _smtp;

            set
            {
                _smtp = value;

                RaisePropertyChanged(nameof(Smtp));
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        public string Message { get; set; }
        public string Theme { get; set; }
        public string Pass { get; set; }       
    }
}