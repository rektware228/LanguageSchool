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
                UpcomingBtn.Visibility = Visibility.Hidden;
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
            if(FilterDiscountCb.SelectedIndex != 0)
            {
                if (FilterDiscountCb.SelectedIndex == 1)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 0 && x.Discount < 5);
                else if (FilterDiscountCb.SelectedIndex == 2)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 5 && x.Discount < 15);
                else if (FilterDiscountCb.SelectedIndex == 3)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 15 && x.Discount < 30);
                else if (FilterDiscountCb.SelectedIndex == 4)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 30 && x.Discount < 70);
                else if (FilterDiscountCb.SelectedIndex == 5)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 70 && x.Discount <= 100);

            }

            if(SearchTb.Text != null)
            {
                serviceSortList = serviceSortList.Where(x => x.Title.ToLower().Contains
                (SearchTb.Text.ToLower()) || x.Description.ToLower().Contains
                (SearchTb.Text.ToLower()));
            }
            CountDataTb.Text = serviceSortList.Count() + " из " + App.db.Service.Count();
            ServicesWp.Children.Clear();
            foreach (var service in serviceSortList)
            {
                ServicesWp.Children.Add(new ServiceUserControll(service));
            }
            
            


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh(); 
        }

        private void FilterDiscountCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Navigation.NextPage(new PageComponent("Добавление услуги", new AddEditServicePage(new Service())));
        }

        private void UpcomingBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Ближайшие записи", new Upcoming()));
        }
    }
}
