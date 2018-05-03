using System.ComponentModel;
using System.Windows.Input;

namespace WPF
{
    internal class VM : INotifyPropertyChanged
    {
        private MailSender _sender = new MailSender();
        private ActionCommand _send;

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
    }
}
