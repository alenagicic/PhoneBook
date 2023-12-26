using PhoneBook.Interfaces;
using PhoneBook.Modules;
using System.Text.Json;

namespace PhoneBook.Services;

public class Add : IphoneBook
{
    public string  Name {get; set;}= null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;


    public Boolean AddContact()
    {
        Console.Clear();
        
        PhoneList phoneList = new PhoneList();

        Console.WriteLine("\n");
        Console.WriteLine("Mata in nedanstående fält för att lägga till en användare!");
        Console.WriteLine("\n");
        Console.Write("Förnamn: ");
            Name = Console.ReadLine()!;
        Console.Write("Efternamn: ");
            LastName = Console.ReadLine()!;
        Console.Write("Telefonnummer: ");
            PhoneNumber = Console.ReadLine()!;
        Console.Write("Email: ");
            Email = Console.ReadLine()!;
        Console.Write("Address: ");
            Address = Console.ReadLine()!;

        var SavedList = phoneList.GetListSavedUsers();

        foreach(User Exist in SavedList)
        {
            if (Exist.Email.ToLower() == $"{Email.ToLower()}")
            {
                Console.WriteLine("\n");
                Console.WriteLine("En användare med denna E-post är redan registrerad!");
                Console.WriteLine("\n");
                Console.WriteLine("Tryck på valfri tangent för att återgå till menyn!");
                Console.ReadKey();
                return false;
            }
        }

        
        User user = new User(Name, LastName, PhoneNumber, Email, Address);

        SavedList.Add(user);

        var Options = new JsonSerializerOptions{ WriteIndented = true };
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
                Console.WriteLine("\n");
                Console.WriteLine("Användaren Tillagd!");
                Console.WriteLine("\n");
                Console.WriteLine("Tryck på valfri knapp för att återgå till menyn");
                Console.ReadKey();
                 return true;


            }
           

        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        


    }



    Boolean IphoneBook.RemoveContact()
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
