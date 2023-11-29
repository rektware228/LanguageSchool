using System;
using System.Collections.Generic;
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
using LanguageSchool.Pages;
using LanguageSchool.Components;
using LanguageSchool.Base;
using System.IO;
using Microsoft.Win32;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditService.xaml
    /// </summary>
    public partial class AddEditService : Page
    {
        private Service service;
        public AddEditService(Service _service)
        {
            InitializeComponent();
            service = _service;
               this.DataContext = service;
        }

        private void DownloadimageBTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };

            if (openFile.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (service.DurationInSeconds < 0||service.DurationInSeconds > 14400)
            {
                error.AppendLine("Время услуги не может привышать 4 часа!");
            }

            if (service.ID == 0)
            {
                if (App.db.Service.Any(x => x.Title == service.Title)) /// any  возвращает да или нет, далее проверяется условие 
                {
                    error.AppendLine("Услуга уже существует");
                    MessageBox.Show(error.ToString());
                }

                else
                {
                    App.db.Service.Add(service);
                }

            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            App.db.SaveChanges();
            MessageBox.Show("Сохранено!");
            Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

    }
}
