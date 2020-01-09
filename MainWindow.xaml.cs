using System;
using System.Windows;
using System.Windows.Input;

namespace KeyboardWriting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBHandler.Connect();
        }

        private void BtnReadme_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Поставь курсор в поле \"Не юзернейм\"\nи нажми Shift. Чего сложного?");
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow rw = new RegWindow();
            tbUsername.IsEnabled = true;
            authorizationProcessStarted = false;
            tbSamplePhrase.Text = string.Empty;
            rw.Show();
        }

        DateTime timer = DateTime.MinValue;
        bool authorizationProcessStarted = false;
        RegistrationArray ra;

        private void TbWrittenPhrase_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbWrittenPhrase.Text.Length == tbSamplePhrase.Text.Length - 1)
            {
                string phrase = tbWrittenPhrase.Text + e.Key.ToString().ToLower();
                string sample = tbSamplePhrase.Text;
                tbWrittenPhrase.Text = phrase;

                int nonSimilarity = 0;

                for (int i = 0; i < sample.Length; i++)
                {
                    if (phrase[i] != sample[i]) nonSimilarity++;
                }

                if (nonSimilarity > 5)
                {
                    ra = new RegistrationArray(sample.Length - 1);
                    MessageBox.Show("Не совпадаеть");
                    tbSamplePhrase.Text = "";
                    tbWrittenPhrase.Text = "";
                    tbUsername.IsEnabled = true;

                    authorizationProcessStarted = false;

                    
                    return;
                }

                if (DBHandler.Authorize(tbUsername.Text, ra.CountPerfect()))
                {
                    MessageBox.Show("Авторизация успешна");

                    timer = DateTime.MinValue;

                    tbSamplePhrase.Text = "";
                    tbWrittenPhrase.Text = "";
                    tbUsername.IsEnabled = true;
                    authorizationProcessStarted = false;

                    ApplicationWindow aw = new ApplicationWindow();
                    aw.Show();

                }
                else
                {
                    MessageBox.Show("Скорости не совпадают, повторите попытку");
                    ra = new RegistrationArray(sample.Length - 1);
                    timer = DateTime.MinValue;
                    tbSamplePhrase.Text = "";
                    tbWrittenPhrase.Text = "";
                    tbUsername.IsEnabled = true;
                    authorizationProcessStarted = false;

                    e.Handled = true;
                }


            }
            if (e.Key == Key.LeftShift)
            {
                if (!authorizationProcessStarted)
                {
                    if (!DBHandler.IsUserExists(tbUsername.Text))
                    {
                        MessageBox.Show("Такого пользователя не существует");
                        return;
                    }
                    string sampleEncrypted = DBHandler.GetAuthorizationString(tbUsername.Text);

                    string sample = Decryptor.Decrypt(sampleEncrypted);

                    authorizationProcessStarted = true;
                    tbUsername.IsEnabled = false;

                    ra = new RegistrationArray(sample.Length - 1);
                    tbSamplePhrase.Text = sample;
                }
            }
            if (e.Key == Key.Back)
            {
                ra.Pop();
            }

            if (authorizationProcessStarted && e.Key != Key.Back && e.Key != Key.LeftShift)
            {
                if (timer != DateTime.MinValue)
                {
                    ra.Add(DateTime.Now - timer);
                }
                timer = DateTime.Now;
            }

        }
    }
}
