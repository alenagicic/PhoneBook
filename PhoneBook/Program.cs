using PhoneBook;
using PhoneBook.Interfaces;
using PhoneBook.Services;
using System.Security.Principal;



while (true)
{
    
    MenuService menuService = new MenuService();
    int option = menuService.Menu();


    if (option == 1)
    {
        IphoneBook add = new Add();
        add.AddContact();
        Console.Clear();
    }else if (option == 2) 
    {
       IphoneBook remove = new Remove();
        remove.RemoveContact();
        Console.Clear();
    }else if (option == 3)
    {
       IphoneBook update = new Update();
        update.UpdateContact();
        Console.Clear();
    }else if(option == 4)
    {
       IphoneBook show = new Show();
        show.ShowAllContacts();
        Console.Clear();
    }else if( option == 5)
    {
        return;
    }
    

}









