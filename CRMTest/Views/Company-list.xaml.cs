﻿using CRMTest.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CRMTest
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// User clicks on Add company button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            Company_form CF = new Company_form();
            CF.Show();
            CF.Closed += CF_Form_closing;
            DataContext = new CompanyViewModel();
        }

        /// <summary>
        /// User clicks on Modify company button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            EditCompany();
            
        }

        private void CompanyListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditCompany();
        }

        private void EditCompany()
        {
            if (CompanyListView.SelectedItems.Count <= 0)
                return;

            DataRowView DRV = (DataRowView)CompanyListView.SelectedItems[0];

            Company_form CF = new Company_form(Convert.ToInt64(DRV.Row["ID"]));
            CF.Closed += CF_Form_closing;
            CF.Show();
        }

        private void CF_Form_closing(Object sender, EventArgs e)
        {
            DataContext = new CompanyViewModel();
        }

        /// <summary>
        /// User clicks on Delete company button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveCompanyButton_Click(object sender, EventArgs e)
        {
            if (CompanyListView.SelectedItems.Count <= 0)
                return;

            DataRowView DRV = (DataRowView)CompanyListView.SelectedItems[0];
            CompanyViewModel CVM = new CompanyViewModel();
            if (CVM.RemoveCompany(Convert.ToInt64(DRV.Row["ID"])))
            {
                DataContext = new CompanyViewModel();
            }
        }
    }
}
