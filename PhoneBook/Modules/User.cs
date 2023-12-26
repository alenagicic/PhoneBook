namespace PhoneBook.Modules;

public class User
{

    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;


    public User(string name, string lastname, string phonenumber, string email, string address)
    {

        Name = name;
        LastName = lastname;
        PhoneNumber = phonenumber;
        Email = email;
        Address = address;

    }



}
