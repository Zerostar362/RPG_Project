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
using System.IO;
using System.Data.SqlClient;
using RPG_Project.GameData.Visuals;
using RPG_Project.Code.Logic.Session;
using RPG_Project.GameData.Creation;

namespace RPG_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CurrentSession.Initiate(MainFrame);
        }

        private void openChaCr_Click_Button(object sender, RoutedEventArgs e) 
        {
            MainFrame.Navigate(new CharacterCreation());
        }

        private void OnClick_ExitButton(object sender, RoutedEventArgs e) 
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void OpenWorldGrid(object sender, RoutedEventArgs e) 
        {
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            MainFrame.Navigate(new WorldMap());
        }
    }
}
