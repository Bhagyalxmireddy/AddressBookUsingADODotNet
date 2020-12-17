using System;

namespace AddressBookUsing_ADODOTNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook");
            AddressBookModel model = new AddressBookModel();
            AddressBookrRepo repo = new AddressBookrRepo();
            repo.RetreveTheData_FromDB();
            model.FirstName = "Anitha";
            model.LastName = "Vanampally";
            model.Address = "Nagarkurnool";
            model.City = "Hyd";
            model.State = "UP";
            model.Zip = "500001";
            model.PhoneNumber = "9874103562";
            model.Email = "Anitha@gmail.com";
            //repo.AddPersonToDB(model);
        }
    }
}
