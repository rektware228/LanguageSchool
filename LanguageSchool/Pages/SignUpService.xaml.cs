using LanguageSchool.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignUpService.xaml
    /// </summary>
    public partial class SignUpService : Page
    {
        private Service service;
        public SignUpService(Service _service)
        {
            InitializeComponent();
            service = _service;
            if (service.MainImage == null)
                MainImage.Source = new BitmapImage(new Uri(@"\Resources\school_logo.png", UriKind.Relative));
            else
                MainImage.Source = GetImage(service.MainImage);
            NameTb.Text = service.Title;
            DurationTb.Text = $"{service.DurationInSeconds/60} мин.";
            PriceTb.Text = (service.Cost - service.Cost * Convert.ToDecimal(service.Discount)/100).ToString("N2");
            ClientCb.ItemsSource = App.db.Client.ToList();
            ClientCb.DisplayMemberPath = "FullName";
            DateDp.DisplayDateStart = DateTime.Now;


        }
        private BitmapImage GetImage(byte[] byteImage)
        {
            if (byteImage != null)
            {
                MemoryStream byteStream = new MemoryStream(byteImage);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                return image;
            }
            return null;
        }

        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            var selDateTime = $"{DateDp.SelectedDate.Value.ToString("yyyy-MM-dd")} {TimeTb.Text}";
            MessageBox.Show(IsValidTime(TimeTb.Text).ToString());
            if (DateDp.SelectedDate != null && !string.IsNullOrWhiteSpace(TimeTb.Text) && ClientCb.SelectedItem != null)
            {
                if (DateTime.TryParse(selDateTime, out DateTime result))
                {
                    if (DateTime.Now < result)
                    {
                        var selectClient = ClientCb.SelectedItem as Client;
                        App.db.ClientService.Add(new ClientService()
                        {
                            ClientID = selectClient.ID,
                            ServiceID = service.ID,
                            StartTime = result

                        });
                        MessageBox.Show("Записано");
                        App.db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Прошедшее время");
                    }
                }
                else
                {
                    MessageBox.Show("Неверное значение времни");
                }
            }
            else
            {
                MessageBox.Show("Выберите дату!");
            }
        }

        private bool IsValidTime(string time)
        {
            string formatTime = @"\d{2}:\d{2}"; //Задаем формат для регулярного выражения

            Regex regex = new Regex(formatTime);
            if (regex.IsMatch(time))
                return true;
            else 
                return false;
        }
    }
}
