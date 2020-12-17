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
            repo.GetCountByPersonType();
            bool i = true;
            while (i)
            {
                Console.WriteLine("1.Retreve All The data");
                Console.WriteLine("2.Retreve data based on city or state");
                Console.WriteLine("3.Retreve data based on city And state");
                Console.WriteLine("4.Retreve data in sorted order based on firstName for givenCity");
                Console.WriteLine("5.Get count by person Type");
                Console.WriteLine("6.Exit");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            repo.RetreveTheData_FromDB();
                            break;
                        case 2:
                            Console.WriteLine("Enter city name : ");
                            model.City = Console.ReadLine();
                            Console.WriteLine("Enter state name : ");
                            model.State = Console.ReadLine();
                            repo.RetrevingDataBased_OnCityOrState(model);
                            break;
                        case 3:
                            Console.WriteLine("Enter city name : ");
                            model.City = Console.ReadLine();
                            Console.WriteLine("Enter state name : ");
                            model.State = Console.ReadLine();
                            repo.RetrevingDataBased_OnCityANDState(model);
                            break;
                        case 4:
                            Console.WriteLine("Enter city name : ");
                            model.City = Console.ReadLine();
                            repo.RetreveData_InSortedOrder(model);
                            break;
                        case 5:
                            repo.GetCountByPersonType();
                            break;
                        case 6:
                            i = false;
                            break;
                        default:
                            Console.WriteLine("Choose proper option");
                            break;
                    }
                }
                catch (System.FormatException formatException)
                {
                    Console.WriteLine(formatException);
                }
            }
        }
    }
}
