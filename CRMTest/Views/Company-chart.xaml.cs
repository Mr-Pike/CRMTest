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
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;

namespace CRMTest.Views
{
    /// <summary>
    /// Logique d'interaction pour company_chart.xaml
    /// </summary>
    public partial class company_chart : Window
    {
        public company_chart()
        {
            InitializeComponent();

            ChartInvoices.DataContext = CompanyChartViewModel;
        }
    }
}
