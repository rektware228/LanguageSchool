using LanguageSchool.Base;
using LanguageSchool.Components;
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
using System.Windows.Shapes;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            if (App.IsAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            var serviceList = App.db.Service.ToList();
            refresh();
        }
        private void refresh()
        {
            IEnumerable<Service> serviceSortList = App.db.Service;
            if(SortCb.SelectedIndex > 0)
            {
                if(SortCb.SelectedIndex == 1)
                {
                    serviceSortList = serviceSortList.OrderBy(x => x.CostAfterDiscount);
                }
                else
                {
                    serviceSortList = serviceSortList.OrderByDescending(x => x.CostAfterDiscount);
                }
            }
            if(DiscountFilterCb.SelectedIndex != 0)
            {
                if (DiscountFilterCb.SelectedIndex == 1)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 0 && x.Discount < 0.05);

                if (DiscountFilterCb.SelectedIndex == 2)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 0.05 && x.Discount < 0.15);

                if (DiscountFilterCb.SelectedIndex == 3)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 0.15 && x.Discount < 0.3);

                if (DiscountFilterCb.SelectedIndex == 4)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 0.3 && x.Discount < 0.7);

                if (DiscountFilterCb.SelectedIndex == 5)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 0.7 && x.Discount < 1);
            }

            if(SearchTb.Text != null)
            {
                serviceSortList = serviceSortList.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower())
                || x.Description.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            ServicesWp.Children.Clear();
            foreach (var service in serviceSortList)
            {
                ServicesWp.Children.Add(new ServiceUserControl(service));
            }

            CountDatatb.Text = serviceSortList.Count() + " из " + App.db.Service.Count();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh(); 
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }
    }
}
