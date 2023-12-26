using System.Diagnostics;
using System.Text.Json;
using PhoneBook.Modules;

namespace PhoneBook.Services;



public class PhoneList
{
    private string ReadData = null!;
    public string PathToFile { get; set; } = null!;

    public string LoadUsersString()
    {
        PathToFile = Directory.GetCurrentDirectory();
        PathToFile = Directory.GetParent(PathToFile)!.FullName;
        PathToFile = Directory.GetParent(PathToFile)!.FullName;
        PathToFile = Directory.GetParent(PathToFile)!.FullName;


        var FilePath = Path.Combine(PathToFile, "User.json");

        Trace.WriteLine(FilePath);



        try
        {

            using (StreamReader sr = new StreamReader(FilePath))
            {

                ReadData = sr.ReadToEnd()!;

            }



        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return ReadData;
    }

    public List<User> GetListSavedUsers()
    {

        if (LoadUsersString() != "")
        {
            List<User> SavedUsers = JsonSerializer.Deserialize<List<User>>(ReadData)!;
            return SavedUsers;
        }
        else
        {
            return new List<User>();
        }




    }

}
