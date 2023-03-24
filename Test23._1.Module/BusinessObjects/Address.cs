using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test23._1.Module.BusinessObjects
{
    [DefaultClassOptions]
    [UniversalSearchAttribute("Line1;Line2;City;PostalCode", "Street:{0} {1}- Description:{2}  - Description:{3}")]
    public class Address : BaseObject
    {
        public Address(Session session) : base(session) { }

        private string _line1;
        public string Line1
        {
            get { return _line1; }
            set { SetPropertyValue(nameof(Line1), ref _line1, value); }
        }

        private string _line2;
        public string Line2
        {
            get { return _line2; }
            set { SetPropertyValue(nameof(Line2), ref _line2, value); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { SetPropertyValue(nameof(City), ref _city, value); }
        }

        private string _state;
        public string State
        {
            get { return _state; }
            set { SetPropertyValue(nameof(State), ref _state, value); }
        }

        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set { SetPropertyValue(nameof(PostalCode), ref _postalCode, value); }
        }

        [Association]
        public Customer Customer
        {
            get { return GetPropertyValue<Customer>(nameof(Customer)); }
            set { SetPropertyValue<Customer>(nameof(Customer), value); }
        }
    }
}
