using PhoneBook.Interfaces;
using PhoneBook.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class Show : IphoneBook
    {

        public Boolean ShowAllContacts()
        {
            PhoneList phoneList = new PhoneList();
            var SavedList = phoneList.GetListSavedUsers();


            if (SavedList.Count != 0)
            {
                Console.Clear();

                Console.WriteLine("\n");
                Console.WriteLine("Här är en lista på alla sparade användare!");
                Console.WriteLine("\n");

                foreach (User user in SavedList)
                {
                    Console.WriteLine($"Förnamn: {user.Name}");
                    Console.WriteLine($"Efternamn: {user.LastName}");
                    Console.WriteLine($"E-post: {user.Email}");
                    Console.WriteLine($"Telefonnummer: {user.PhoneNumber}");
                    Console.WriteLine($"Address: {user.Address}");
                    Console.WriteLine("\n");
                }

                Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
                Console.ReadKey();
                return true;
            }else
            {
                return false;
            }

            

        }

        Boolean IphoneBook.AddContact()
        {
            throw new NotImplementedException();
        }

        Boolean IphoneBook.RemoveContact()
        {
            throw new NotImplementedException();
        }

        Boolean IphoneBook.UpdateContact()
        {
            throw new NotImplementedException();
        }
    }
}
