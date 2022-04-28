using System.Windows;

namespace CourseProject.InformationWindows
{
    /// <summary>
    /// Логика взаимодействия для EncryptWindow.xaml
    /// </summary>
    public partial class EncryptWindow : Window
    {
        public EncryptWindow()
        {
            InitializeComponent();
        }

        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MessageTextBox.Text))
            {
                MessageBox.Show("Вы ничего не ввели :(");
                return;
            }
            DialogResult = true;
        }
    }
}
