using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CRMTest
{
    class CompanyViewModel
    {
        public DataView CompanyList { get; private set; }

        public CompanyViewModel()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT C.Name, C.Siren, C.Address_line_1, C.ZipCode, C.City, C.Phone, C.Mail, CC.name AS CountryName " +
                    " FROM COMPANY C" +
                    " INNER JOIN COUNTRY CC ON C.Country_ID = CC.ID" +
                    " ORDER BY Name", connection);
                adapter.Fill(dt);
            }

            CompanyList = dt.DefaultView;
        }
    }
}
