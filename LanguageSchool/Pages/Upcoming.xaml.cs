using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для Upcoming.xaml
    /// </summary>
    public partial class Upcoming : Page
    {          
        DateTime endDate = DateTime.Now.AddDays(2).Date;
        DispatcherTimer timer = new DispatcherTimer();
        public Upcoming()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Update);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
            EntryList.ItemsSource = App.db.ClientService.Where
                (x => x.StartTime >= DateTime.Now && x.StartTime < endDate).OrderBy(x => x.StartTime).ToList();

        }
        private void Update(object sender, EventArgs e)
        {
            EntryList.ItemsSource = App.db.ClientService.Where
                (x => x.StartTime >= DateTime.Now && x.StartTime < endDate).OrderBy(x => x.StartTime).ToList();
        }
    }
}
