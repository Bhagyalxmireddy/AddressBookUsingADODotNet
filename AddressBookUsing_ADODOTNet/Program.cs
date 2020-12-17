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
            bool i = true;
            while (i)
            {
                Console.WriteLine("1.Retrevice All The data");
                Console.WriteLine("2.Retrevice data based on city or state");
                Console.WriteLine("3.Retrevice data based on city And state");
                Console.WriteLine("4.Exit");
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
