using CourseProject.InformationWindows;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string key = "скорпион";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.AddExtension = true;

            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            using (var stream = openFileDialog.OpenFile())
            {
                if (Path.GetExtension(openFileDialog.FileName) != ".txt")
                {
                    MessageBox.Show("Выбран не текстовый файл!");
                    return;
                }

                using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(1251)))
                {
                    ResultTextBlock.Text = AlgorithmEncryption.Encrypt(reader.ReadToEnd(), key, false);
                    ActionLabel.Content = "Расшифровано:";
                }
            }
        }

        private void ShowKeyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Текущий ключ: {key}");
        }

        private void ChangeKeyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NewKeyTextBox.Text) || !string.IsNullOrWhiteSpace(NewKeyTextBox.Text))
            {
                key = NewKeyTextBox.Text;
                NewKeyTextBox.Text = "";
                MessageBox.Show("Ключ изменён!");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FileName = "message";

            if (saveFileDialog.ShowDialog() == false)
            {
                return;
            }

            using (FileStream fileStream = File.OpenWrite(saveFileDialog.FileName))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(ResultTextBlock.Text);
                }
            }

            if (File.Exists(saveFileDialog.FileName))
            {
                MessageBox.Show("Сохранено!");
            }
        }

        private void ToDecryptButton_Click(object sender, RoutedEventArgs e)
        {
            EncryptWindow encryptWindow = new EncryptWindow();

            if (encryptWindow.ShowDialog() == false)
            {
                return;
            }

            var spesialKey = encryptWindow.KeyTextBox.Text;
            var message = encryptWindow.MessageTextBox.Text;

            if (string.IsNullOrEmpty(spesialKey) || string.IsNullOrWhiteSpace(spesialKey))
            {
                ResultTextBlock.Text = AlgorithmEncryption.Encrypt(message, key, true);
            }
            else
            {
                ResultTextBlock.Text = AlgorithmEncryption.Encrypt(message, spesialKey, true);
            }
            
            ActionLabel.Content = "Зашифровано:";
        }
    }
}
