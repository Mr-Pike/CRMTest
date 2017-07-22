using CRMTest.Model;
using System;
using System.Windows;
using System.Linq;


namespace CRMTest.Views
{
    /// <summary>
    /// Logique d'interaction pour Company_form.xaml
    /// </summary>
    public partial class Company_form : Window
    {
        CompanyFormViewModel companyFormViewModel { get; set; }
        long CompanyID = 0;

        public Company_form()
        {
            InitializeComponent();
            Title = "Création d'une nouvelle entreprise";
            companyFormViewModel = new CompanyFormViewModel();
            DataContext = companyFormViewModel;
        }

        public Company_form(long ID)
        {
            InitializeComponent();
            CompanyID = ID;
            Title = "Modification d'une entreprise";

            try
            {
                ModelCRMTest m = new ModelCRMTest();
                Company company = m.Company.Where(x => x.ID == ID).First();
                companyFormViewModel = new CompanyFormViewModel(company);
                DataContext = companyFormViewModel;
            }
            catch
            {
                MessageBox.Show("L'entreprise n'a pas été trouvée.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Stop);
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Company company = new Company
            {
                ID = CompanyID,
                Name = Name.Text,
                Address_line_1 = Address_line_1.Text,
                Address_line_2 = Address_line_2.Text,
                ZipCode = ZipCode.Text,
                City = City.Text,
                Siren = Siren.Text,
                Phone = Phone.Text,
                Fax = Fax.Text,
                Mail = Mail.Text,
                Country_ID = (short?)CountryID.SelectedValue
            };
            companyFormViewModel.AddOrUpdateCompany(company);
            this.Close();
        }
    }
}
