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
    [UniversalSearchAttribute("Name;Description;Category", "Name:{0} - Description:{1}  - Description:{2}")]
    public class Customer : BaseObject
    {
        public Customer(Session session) : base(session) { }

        string category;
        string description;
        private string _name;
        [Persistent(nameof(Name))]
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue(nameof(Name), ref _name, value); }
        }

        private string _vatId;
        [Persistent(nameof(VATID))]
        public string VATID
        {
            get { return _vatId; }
            set { SetPropertyValue(nameof(VATID), ref _vatId, value); }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Category
        {
            get => category;
            set => SetPropertyValue(nameof(Category), ref category, value);
        }

        [Association]
        public XPCollection<Address> Addresses
        {
            get { return GetCollection<Address>(nameof(Addresses)); }
        }

        private string _notes;
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get { return _notes; }
            set { SetPropertyValue(nameof(Notes), ref _notes, value); }
        }
    }
}
