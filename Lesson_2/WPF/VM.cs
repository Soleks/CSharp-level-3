using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF
{
    internal class VM : INotifyPropertyChanged
    {
        private MailSender _sender = new MailSender();
        private ActionCommand _send;
        private ObservableCollection<Dto.Email> _emails;
        private ObservableCollection<Dto.SmtpSettings> _smtp;
        
        public VM()
        {
            Emails = _sender.SelectEmails();
            Smtp = _sender.SelectSmtpSettings();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChangedEventHandler(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SendCommand => _send ?? (
            _send = new ActionCommand(ExecuteCommand, CanExecuteCommand));

        private void ExecuteCommand(object obj) =>
            _sender.MailSend(Message, Pass);

        private bool CanExecuteCommand(object obj) => 
            !string.IsNullOrEmpty(Message) && 
            !string.IsNullOrEmpty(Pass);

        public string Message { get; set; }
        public string Theme { get; set; }
        public string Pass { get; set; }

        public ObservableCollection<Dto.Email> Emails
        {
            get => _emails;

            set
            {
                _emails = value;

                OnPropertyChangedEventHandler(nameof(Emails));
            }
        }

        public ObservableCollection<Dto.SmtpSettings> Smtp
        {
            get => _smtp;

            set
            {
                _smtp = value;

                OnPropertyChangedEventHandler(nameof(Smtp));
            }
        }
    }
}
