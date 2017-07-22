using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CRMTest.Model;
using System.Data.Entity;
using System.Windows;

namespace CRMTest
{
    class CompanyFormViewModel
    {
        public Company SelectedCompany {get; set;}
        public List<Country> Countries { get; set; }
        public Country SelectedCountry { get; set; }
        protected ModelCRMTest model = new ModelCRMTest();

        public CompanyFormViewModel()
        {
            Countries = model.Country.ToList();
            SelectedCountry = Countries.Where(x => x.ID == (short)14).FirstOrDefault<Country>();
        }

        public CompanyFormViewModel(Company company)
        {
            SelectedCompany = company;
            Countries = model.Country.ToList();
            SelectedCountry = company.Country;
        }

        public void AddOrUpdateCompany(Company company)
        {
            Countries = model.Country.ToList();
            SelectedCountry = Countries.Where(x => x.ID == (short)14).FirstOrDefault<Country>();

            try
            {
                using (var context = new ModelCRMTest())
                {
                    context.Company.Add(company);
                    context.Entry(company).State = company.ID == 0 ? EntityState.Added : EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("L'entreprise n'a pas été ajoutée / modifiée. \n\n L'erreur suivante s'est produite : " + e.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
   
        }
    }
}
