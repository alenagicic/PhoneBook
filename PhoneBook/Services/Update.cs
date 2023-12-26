using PhoneBook.Interfaces;
using PhoneBook.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class Update : IphoneBook
    {


        public Boolean UpdateContact()
        {
            PhoneList phoneList = new PhoneList();
            var SavedList = phoneList.GetListSavedUsers();

            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("Ange personens E-post för att ändra på kontakten");
            Console.WriteLine("\n");
            var ReadUserInput = Console.ReadLine();


            var GetIndex = SavedList.FindIndex(x => x.Email.Equals(ReadUserInput, StringComparison.CurrentCultureIgnoreCase));

            // Om indexet hittas, gör följande

            if (GetIndex != -1)
            {
                SavedList.RemoveAt(GetIndex);


                Console.Clear();
                Console.WriteLine("\nDu modifierar nu användaren");
                Console.WriteLine("\n");
                Console.Write("Namn: ");
                var InputOne = Console.ReadLine();
                Console.Write("Efternamn: ");
                var InputTwo = Console.ReadLine();
                Console.Write("Telefonnummer: ");
                var InputThree = Console.ReadLine();
                Console.Write("E-post: ");
                var InputFour = Console.ReadLine();
                Console.Write("Address: ");
                var InputFive = Console.ReadLine();


                User user = new User(InputOne!, InputTwo!, InputThree!, InputFour!, InputFive!);

                SavedList.Add(user);


                var Options = new JsonSerializerOptions { WriteIndented = true };
                var SavedListConverter = JsonSerializer.Serialize(SavedList, Options);


                var something = Directory.GetCurrentDirectory();
                something = Directory.GetParent(something)!.FullName;
                something = Directory.GetParent(something)!.FullName;
                something = Directory.GetParent(something)!.FullName;


                var FilePath = Path.Combine(something, "User.json");


                try
                {
                    using (StreamWriter WriteFile = new StreamWriter(FilePath))
                    {
                        WriteFile.WriteLine(SavedListConverter);
                        Console.WriteLine("\nAnvändaren ändrad!");
                        Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn");
                        Console.ReadKey();
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }




            } else
            {
                Console.Clear();
                Console.WriteLine("\nDen här användaren finns inte!");
                Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn");
                Console.ReadKey();
                return false;
            }



        }

        public Boolean AddContact()
        {
            throw new NotImplementedException();
        }

        public Boolean RemoveContact()
        {
            throw new NotImplementedException();
        }

        public Boolean ShowAllContacts()
        {
            throw new NotImplementedException();
        }

        
    }
}
