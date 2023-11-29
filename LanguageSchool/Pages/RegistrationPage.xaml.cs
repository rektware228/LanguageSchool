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
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            //PhoneAttribute phoneAttribute = new PhoneAttribute();
            //EmailAddressAttribute emailAddressAttribute = new EmailAddressAttribute();


            //if (phoneAttribute.IsValid(PhoneTb.Text))
            //{
            //    if (emailAddressAttribute.IsValid(EmailTb.Text))
            //    {
            //        Navigation.NextPage(new PageComponent("Авторизация", new AuthorizatePage()));
            //    }

            //    else
            //        MessageBox.Show("Некорректная почта");
            //}
            //else
            //    MessageBox.Show("Некорректный телефон");

            Regex regexPhone = new Regex(@"^(\+7|8)\s\d{3}\s\d{3}\s\d{2}\s\d{2}$");
            Regex regexEmail = new Regex(@"(\S+@(mail\.ru|yandex\.ru)$)");
            if (regexPhone.IsMatch(PhoneTb.Text))
            {

            }
            else
                MessageBox.Show("Некорректный телефон");

            if (regexEmail.IsMatch(EmailTb.Text))
            {

            }
            else
                MessageBox.Show("Некорректная почта");





        }
    }
}
