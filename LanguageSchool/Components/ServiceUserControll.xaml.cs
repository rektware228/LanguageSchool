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
using LanguageSchool.Pages;
using System.Linq.Expressions;

namespace LanguageSchool.Components
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class ServiceUserControll : UserControl
    {
        private Service service;

        public ServiceUserControll(Service _service)
        {
            InitializeComponent();
            service = _service;
            if(App.IsAdmin == false)
            {
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
                SignBtn.Visibility = Visibility.Hidden; 
            }
            TitleTb.Text = service.Title;
            CostTimeTb.Text = service.costTimeStr.ToString();
            CostTb.Visibility = service.CostVisibility;
            CostTb.Text = (service.Cost).ToString("N0") + "  ";
            DiscountTb.Text = service.DiscountStr.ToString();
            MainBorder.Background = service.ColorDiscount;
            
            MainImage.Source = GetImage(service.MainImage);
        }

        private BitmapImage GetImage(byte[] byteImage)
        {
            if(byteImage != null)
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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Редактирование услуги", new AddEditServicePage(service)));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(service.ClientService.Count != 0)
            {
                MessageBox.Show("Удаление запрещено! На эту услугу ещё есть записи.");
            }
            else
            {
                try
                {
                    var SelectedService = service as Service;
                    if (SelectedService != null)
                        App.db.Service.Remove(SelectedService);
                    else
                        MessageBox.Show("Невозможно удалить!");
                
                    App.db.SaveChanges();
                    Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
                }
                catch
                {
                    MessageBox.Show("Ошибка!!!");
                }
                
            }
        }

        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Запись на услугу", new SignUpService(service)));
        }
    }
}
