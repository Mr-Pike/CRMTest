using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using CRMTest.Model;
using System.Windows;

namespace CRMTest
{
    class CompanyViewModel
    {
        public DataView CompanyList { get; private set; }

        public CompanyViewModel()
        {
            DataTable dt = new DataTable();

            try
            { 
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMTest"].ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("SELECT C.ID, C.Name, C.Siren, C.Address_line_1, C.ZipCode, C.City, C.Phone, C.Mail, CC.name AS CountryName " +
                        " FROM COMPANY C" +
                        " LEFT JOIN COUNTRY CC ON C.Country_ID = CC.ID" +
                        " ORDER BY C.ID", connection);
                    adapter.Fill(dt);
                }

                CompanyList = dt.DefaultView;
            }
            catch(Exception e)
            {
                MessageBox.Show("La liste des entreprises n'a pas été récupérée. \n\n L'erreur suivante s'est produite : " + e.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        public bool RemoveCompany(long ID)
        {
            try
            {
                using (var context = new ModelCRMTest())
                {
                    Company company = context.Company.Where(C => C.ID == ID).First();
                    context.Company.Remove(company);
                    context.SaveChanges();
                }

                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("L'entreprise n'a pas été supprimée. \n\n L'erreur suivante s'est produite : " + e.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }
        }
    }
}
