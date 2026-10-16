using BTLT01.Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BTLT01.ViewModel;

namespace BTLT01 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            // Thiết lập DataContext chính cho View
            DataContext = new MainViewModel();
        }
    }
}