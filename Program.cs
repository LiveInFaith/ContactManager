using System;
using System.Collections.Generic;

namespace MiniApp1_ContactManager
{
    enum MenuOption
    {
        Add = 1,
        Delete,
        Update,
        ShowAll,
        Search,
        Exit
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contacts> contacts = Filehandler.Read();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n CONTACT MANAGER MENU");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Delete Contact");
                Console.WriteLine("3. Update Contact");
                Console.WriteLine("4. Show All Contacts");
                Console.WriteLine("5. Search Contacts");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option (1–6): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                    continue;
                }

                Console.WriteLine(); // spacing

                switch ((MenuOption)choice)
                {
                    case MenuOption.Add:
                        ContactManager.Add(contacts);
                        break;
                    case MenuOption.Delete:
                        ContactManager.DeleteContactByID(contacts);
                        break;
                    case MenuOption.Update:
                        ContactManager.UpdateContactByID(contacts);
                        break;
                    case MenuOption.ShowAll:
                        ContactManager.DisplayAllContacts(contacts);
                        break;
                    case MenuOption.Search:
                        HandleSearch(contacts);
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine(" Exiting Contact Manager...");
                        exit = true;
                        break;
                }
            }
        }

        static void HandleSearch(List<Contacts> contacts)
        {
            Console.WriteLine("Search by: id / name / email");
            string criteria = Console.ReadLine();

            Console.Write("Enter search value: ");
            string value = Console.ReadLine();

            var results = ContactManager.Search(contacts, criteria, value);

            if (results.Count == 0)
            {
                Console.WriteLine(" No contacts found.");
            }
            else
            {
                Console.WriteLine("Search Results:");
                foreach (var contact in results)
                {
                    Console.WriteLine(contact);
                }
            }
        }
    }
}
