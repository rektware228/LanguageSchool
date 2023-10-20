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
using LanguageSchool.Components;
using LanguageSchool.Pages;
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
            service = _service;
            InitializeComponent();
            if (App.IsAdmin == false)
            {
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
            TitleTb.Text = service.Title;
            CostTimeTb.Text = service.costTimeStr.ToString();
            CostTb.Visibility = service.CostVisibility;
            CostTb.Text = (service.Cost).ToString("N0") + "  ";
            DiscountTb.Text = service.DiscountStr.ToString();
            MainBorder.Background = service.ColorDiscount;
            MainImage.Source = GetImageSource(service.MainImage);
        }

        private BitmapImage GetImageSource(byte[] byteImage)
        {
            MemoryStream byteStream = new MemoryStream(byteImage);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Редактирование услуги", new AddEditService(service)));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (service.ClientService != null)
            {
                MessageBox.Show("Удаление запрещено");
            }

            else
            {
                App.db.Service.Remove(service);
                App.db.SaveChanges();
            }
        }
    }
}
