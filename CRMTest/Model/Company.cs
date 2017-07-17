using System;
using System.ComponentModel;

namespace CRMTest.Model
{
    public class Company : INotifyPropertyChanged
    {
        private string name;
        private string address_line_1;
        private string address_line_2;
        private string zipCode;
        private string city;
        private short country_ID;
        private string siren;
        private string phone;
        private string fax;
        private string mail;

        public long ID
        {
            get;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public string Address_line_1
        {
            get
            {
                return address_line_1;
            }
            set
            {
                if (address_line_1 != value)
                {
                    address_line_1 = value;
                    RaisePropertyChanged("AdressLine1");
                }
            }
        }

        public string Address_line_2
        {
            get
            {
                return address_line_2;
            }
            set
            {
                if (address_line_2 != value)
                {
                    address_line_2 = value;
                    RaisePropertyChanged("AdressLine1");
                }
            }
        }

        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if (zipCode != value)
                {
                    zipCode = value;
                    RaisePropertyChanged("ZipCode");
                }
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (city != value)
                {
                    city = value;
                    RaisePropertyChanged("City");
                }
            }
        }

        public short Country_ID
        {
            get
            {
                return country_ID;
            }
            set
            {
                if (country_ID != value)
                {
                    country_ID = value;
                    RaisePropertyChanged("Country_ID");
                }
            }
        }

        public string Siren
        {
            get
            {
                return siren;
            }
            set
            {
                if (siren != value)
                {
                    siren = value;
                    RaisePropertyChanged("Siren");
                }
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (phone != value)
                {
                    phone = value;
                    RaisePropertyChanged("Phone");
                }
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                if (fax != value)
                {
                    fax = value;
                    RaisePropertyChanged("Fax");
                }
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                if (mail != value)
                {
                    mail = value;
                    RaisePropertyChanged("Mail");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
