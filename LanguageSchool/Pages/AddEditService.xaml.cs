﻿using System;
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
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
