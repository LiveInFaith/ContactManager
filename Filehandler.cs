using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace MiniApp1_ContactManager
{
    internal class Filehandler
    {
        //string path = "contacts.json";
        static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "contacts.json");

        public static List<Contacts> Read()
        {
            try
            {
                string readJson = File.ReadAllText(path);
                var contacts = JsonSerializer.Deserialize<List<Contacts>>(readJson);

                return contacts ?? new List<Contacts>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during reading of json : {ex}");
                return new List<Contacts>(); 
            }
            
            
        }
       
        public static void Write(List<Contacts> contracts)
        {
            try
            {
                var writeJson = JsonSerializer.Serialize(contracts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, writeJson);
            }
            catch (Exception ex )
            {
                Console.WriteLine($"Error occurred during Write : {ex}");
            }
           
        }
        
        
    }
}
