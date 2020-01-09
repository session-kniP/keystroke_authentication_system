using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KeyboardWriting
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        bool isBrushRed = false;

        public RegWindow()
        {
            InitializeComponent();
            label1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;


            Task.Run(new Action(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (isBrushRed)
                        {
                            isBrushRed = false;
                            label1.Foreground = Brushes.Red;
                            label1.FontSize = 32;
                        }
                        else
                        {
                            isBrushRed = true;
                            label1.Foreground = Brushes.Green;
                            label1.FontSize = 30;
                        }
                    }));
                }
            }));
        }

        private void BtnReadme_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Поставь курсор в поле и нажми \"Shift\", чего сложного?");
        }

        static bool registrationProcessStarted = false;
        DateTime timer = DateTime.MinValue;
        static int registrationStage = 0;
        RegistrationArray ra;

        static int userQuestionID;

        private void TbWrittenPhrase_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbWrittenPhrase.Text.Length == tbSamplePhrase.Text.Length - 1)
            {
                string phrase = tbWrittenPhrase.Text + e.Key.ToString().ToLower();
                string samplePhrase = tbSamplePhrase.Text;

                int treshold = samplePhrase.Length * 10 / 100;

                int similarity = 0;

                for (int i = 0; i < samplePhrase.Length; i++)
                {
                    if (phrase[i] == samplePhrase[i]) similarity++;
                }

                if (similarity < samplePhrase.Length - treshold)
                {
                    MessageBox.Show("Вообще мимо");
                    return;
                }

                registrationStage++;
                tbWrittenPhrase.Text = "";

                timer = DateTime.MinValue;
                label2.Content = 3 - registrationStage;
                e.Handled = true;
            }

            if (registrationStage == 3)
            {
                double perfect = ra.CountPerfect();

                label1.Visibility = Visibility.Hidden;
                label2.Visibility = Visibility.Hidden;

                tbUsername.IsEnabled = true;

                if (DBHandler.RegisterUser(tbUsername.Text, perfect, userQuestionID))
                {
                    MessageBox.Show("Регистрация прошла успешно");
                    registrationProcessStarted = false;
                    registrationStage = 0;
                    return;
                }

                MessageBox.Show("Что-то пошло не так");
                registrationProcessStarted = false;
                registrationStage = 0;
                return;
            }

            if (e.Key == Key.LeftShift)
            {
                if (!registrationProcessStarted)
                    if (tbUsername.Text != "")
                    {
                        if (DBHandler.IsUserExists(tbUsername.Text))
                        {
                            MessageBox.Show("Пользователь с таким именем уже существует");
                            return;
                        }

                        label1.Visibility = Visibility.Visible;
                        label2.Visibility = Visibility.Visible;

                        label2.Content = 3;

                        tbUsername.IsEnabled = false;

                        registrationProcessStarted = true;

                        string regStrEncrypted = DBHandler.GetRegistrationString(ref userQuestionID);

                        string regStr = Decryptor.Decrypt(regStrEncrypted);

                        ra = new RegistrationArray(regStr.Length * 3 - 3);

                        tbSamplePhrase.Text = regStr;
                    }
                    else MessageBox.Show("Имя напиши, гадость!");

            }

            if (e.Key == Key.Back)
            {
                ra.Pop();
            }

            if (registrationProcessStarted && e.Key != Key.Back && e.Key != Key.LeftShift)
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
