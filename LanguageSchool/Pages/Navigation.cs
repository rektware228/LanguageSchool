using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace LanguageSchool.Pages
{
    class Navigation
    {
        private static List<PageComponent> components = new List<PageComponent>();
        public static MainWindow mainWindow;

        public static void ClearHistory()
        {
            App.IsAdmin = false;
            components.Clear();
        }

        public static void Update(PageComponent pageComponent)
        {
            mainWindow.TitleTb.Text = pageComponent.Title;
            mainWindow.BackBTN.Visibility = components.Count() > 1? System.Windows.Visibility.Visible: System.Windows.Visibility.Hidden;
            mainWindow.ExitBTN.Visibility = App.IsAdmin? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.MyFrame.Navigate(pageComponent.Page);
        }
        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);
            Update(pageComponent); 

        }

        public static void BackPage()
        {
            if(components.Count > 1)
            {
                components.RemoveAt(components.Count - 1);
                Update(components[components.Count - 1]);
            }
        }

    }


    class PageComponent {
        public string Title { get; set; }
        public Page Page { get; set; }

        public PageComponent(string title, Page page)
        {
            Page = page;
            Title = title;
        }

    }

}
