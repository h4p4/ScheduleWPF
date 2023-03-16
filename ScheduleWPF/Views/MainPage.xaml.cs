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
using Microsoft.EntityFrameworkCore;
using ScheduleWPF.ViewModels;

namespace ScheduleWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private List<DataGrid> weekDataGrids;
        public MainPage()
        {
            InitializeComponent();
            Helper.GetContext().Lectures.Load();
            this.DataContext = new MainViewModel();
            weekDataGrids = new List<DataGrid>(LecturesGrid.Children.OfType<DataGrid>().Where(n => n.Name.EndsWith("LecturesDataGrid")));
        }

        private void LecturesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
