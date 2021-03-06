﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookUsing_ADODOTNet
{
    public class AddressBookModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Relationship_ID { get; set; }
        public string RelationShip_name { get; set; }

    }
}
