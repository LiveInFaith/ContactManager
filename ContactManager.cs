using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp1_ContactManager
{
    public class ContactManager
    {
        //Search
        public static List<Contacts> Search(List<Contacts> contacts, string criteria, string value)
        {
            try
            {
                return criteria.ToLower() switch
                {
                    "id" => contacts.Where(c => c.Id_V == int.Parse(value)).ToList(),
                    "name" => contacts.Where(c => c.Name_V.Contains(value, StringComparison.OrdinalIgnoreCase)).ToList(),
                    "email" => contacts.Where(c => c.Email_V.Contains(value, StringComparison.OrdinalIgnoreCase)).ToList(),
                    _ => new List<Contacts>()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error something went wrong during search : {ex}");
                return new List<Contacts>(); 
            }
            
        }
        //Add
        public static void Add(List<Contacts> contacts)
        {
            try
            {
                Console.WriteLine("Enter ID of contact");
                string inputID = Console.ReadLine();
                if (!int.TryParse(inputID, out  int id))
                {
                    Console.WriteLine("Enter an numeric value for ID");
                    return;
                }

                if (contacts.Any(c =>  c.Id_V == id))
                {
                    Console.WriteLine("May not have any duplicate ID's");
                    return;
                }

                Console.WriteLine("Enter Name of contact");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty");
                    return;
                }

                Console.WriteLine("Enter Email of contact");
                string email = Console.ReadLine();
                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Email cannot be null or empty"); 
                    return;
                }

                Console.WriteLine("Enter Phone Number of contact");
                string phone = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(phone) || !phone.All(char.IsDigit))
                {
                    Console.WriteLine("Phone number must be a digit and not empthy");
                    return;
                }

                Contacts newContact = new Contacts(id, name, email, phone);
                contacts.Add(newContact);

                Filehandler.Write(contacts);
                Console.WriteLine("Contact was added!");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Something when wrong when trying to add a Contact");
            }
        }

        //Delete
        public static void DeleteContactByID(List<Contacts> contacts)
        {
            try
            {
                Console.WriteLine("Enter the ID of the contact to delete");
                string inputId = Console.ReadLine();

                if (!int.TryParse(inputId, out int id))
                {
                    Console.WriteLine("Id must be an integer");
                    return;
                }

                var contact = contacts.FirstOrDefault(c => c.Id_V == id);
                if (contact == null)
                {
                    Console.WriteLine("Could not find contact with that id");
                    return;
                }

                contacts.Remove(contact);
                Filehandler.Write(contacts);
                Console.WriteLine("Contact was deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during deletion of contact : {ex}");
            }
        }

        //Update
        public static void UpdateContactByID(List<Contacts> contacts)
        {
            try
            {
                Console.WriteLine("Enter the ID of the contact to update");
                string inputId = Console.ReadLine();

                if (!int.TryParse(inputId,out int id))
                {
                    Console.WriteLine("Id must be an numeric value");
                    return;
                }

                var contact = contacts.FirstOrDefault(c => c.Id_V == id); 
                if (contact == null)
                {
                    Console.WriteLine("Could not find a contact with that ID");
                    return;
                }

                Console.Write("Enter new name (or press Enter to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    contact.Name_V = name;
                }

                Console.Write("Enter new email (or press Enter to keep current): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email))
                {
                    contact.Email_V = email;
                }

                Console.Write("Enter new phone number (or press Enter to keep current): ");
                string phone = Console.ReadLine();
                if (!string.IsNullOrEmpty(phone))
                {
                    contact.Phone_V = phone;
                }

                Filehandler.Write(contacts);
                Console.WriteLine("Contact was updated!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during updating of contact : {ex}");
            }
        }

        //Show All
        public static void DisplayAllContacts(List<Contacts> contacts)
        {
            if(contacts.Count == 0)
            {
                Console.WriteLine("No contacts are found");
                return;
            }
            foreach (Contacts con in contacts)
            {
                Console.WriteLine(con);
            }
        }
    }
}
