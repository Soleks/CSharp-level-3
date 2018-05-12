using System.Windows;
using System.Windows.Controls;
using MailSender.ViewModel;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void TextBox_Error(object sender, System.Windows.Controls.ValidationErrorEventArgs e)
        {
            ((Control)sender).ToolTip = e.Action == ValidationErrorEventAction.Added ? e.Error.ErrorContent.ToString() : "";
        }
    }
}