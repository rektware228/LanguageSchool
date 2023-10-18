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

namespace LanguageSchool.Components
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class ServiceUserControll : UserControl
    {
        public ServiceUserControll(Service service)
        {
            InitializeComponent();
            if(App.IsAdmin == false)
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

        }
    }
}
