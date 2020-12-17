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
        }
    }
}
