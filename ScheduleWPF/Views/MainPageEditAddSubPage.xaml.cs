﻿using CommunityToolkit.Mvvm.Input;
using ScheduleWPF.Models;
using ScheduleWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ScheduleWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPageEditAddSubPage.xaml
    /// </summary>
    public partial class MainPageEditAddSubPage : Page
    {
        private EditAddViewModelBase _editAddViewModel;
        private EditAddViewModelBase EditAddViewModel
        {
            get => _editAddViewModel;
            set
            {
                _editAddViewModel = value;
                this.DataContext = _editAddViewModel;
            }
        }
        public MainPageEditAddSubPage(Lecture lecture)
        {
            InitializeComponent();
            EditAddViewModel = new EditViewModel(lecture);
        }
        public MainPageEditAddSubPage(ref ObservableCollection<Lecture> lectures, DateOnly dateOnly, Group group)
        {
            InitializeComponent();
            EditAddViewModel = new AddViewModel(ref lectures, dateOnly, group);
        }
        private void IsShortDayChBox_Click(object sender, RoutedEventArgs e)
        {
            TimeCBox.SelectedIndex = 0;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Helper.ExecuteCommand(EditAddViewModel.SaveChangesCommand);
            ExitPage();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Helper.ExecuteCommand(EditAddViewModel.CancelChangesCommand);
            ExitPage();
        }
        private void ExitPage()
        {
            NavigationService.Navigate(null);
        }
    }
}
