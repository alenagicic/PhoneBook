using PhoneBook.Interfaces;
using PhoneBook.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class Remove : IphoneBook
    {
        public string Email { get; set; } = null!;

        public Boolean RemoveContact()
        {
            Console.Clear();

            PhoneList phoneList = new PhoneList();


            Console.WriteLine("\n");
            Console.WriteLine("Mata in E-posten på den användare som du vill plocka bort: ");
            Console.WriteLine("\n");
            Email = Console.ReadLine()!;

            var GetList = phoneList.GetListSavedUsers();

            var GetIndex = GetList.FindIndex(x => x.Email.Equals($"{Email}", StringComparison.CurrentCultureIgnoreCase));


                if (GetIndex == -1)
                {
                    Console.Clear();
                    Console.WriteLine("\nDet finns ingen användare med den E-posten!");
                    Console.WriteLine("\nTryck på valfri knapp för att återgå till menyn");
                    Console.ReadKey();
                    return false;
                }


            GetList.RemoveAt(GetIndex);
            

            var Options = new JsonSerializerOptions { WriteIndented = true };
            var SavedListConverter = JsonSerializer.Serialize(GetList, Options);


            var something = Directory.GetCurrentDirectory();
            something = Directory.GetParent(something)!.FullName;
            something = Directory.GetParent(something)!.FullName;
            something = Directory.GetParent(something)!.FullName;


            var FilePath = Path.Combine(something, "User.json");


            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    sw.WriteLine(SavedListConverter);
                    Console.Clear() ;
                    Console.WriteLine("\nAnvändaren plockades bort!");
                    Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn");
                    Console.ReadKey();
                    return true;
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }




        }

        Boolean IphoneBook.AddContact()
        {
            throw new NotImplementedException();
        }

        Boolean IphoneBook.ShowAllContacts()
        {
            throw new NotImplementedException();
        }

        Boolean IphoneBook.UpdateContact()
        {
            throw new NotImplementedException();
        }
    }




    
}
