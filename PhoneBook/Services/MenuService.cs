namespace PhoneBook.Services;

internal class MenuService
{

    public int Menu()
    {
        while (true)
        {

        Console.Clear();

        Console.WriteLine("Hej och välkommna till Telefonboken");
        Console.WriteLine("\n\n");
        Console.WriteLine("Mata in nedanstående siffror för att köra programmets olika funktioner!");
        Console.WriteLine("\n\n");

            Console.WriteLine("1: För att lägga till en användare");
            Console.WriteLine("2: För att plocka bort en användare");
            Console.WriteLine("3: För att uppdatera en användare");
            Console.WriteLine("4: För att visa alla tillagda användare");
            Console.WriteLine("5: För att avsluta applikationen");

            Console.WriteLine();
            string UserInput = Console.ReadLine()!;

        if (UserInput == "")
            {
                UserInput = "hej";
            }


        try
            {
                var something = Convert.ToInt32(UserInput);


                if (something > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Mata in ett giltigt kommando");
                    Console.WriteLine("\nTryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                }


                if (something == 1 || something == 2 || something == 3 || something == 4 || something == 5)
                {

                    return Convert.ToInt32(UserInput);


                }
            } catch
            {
                Console.Clear();
                Console.WriteLine("Mata in ett giltigt kommando");
                Console.WriteLine("\nTryck på valfri knapp för att fortsätta");
                Console.ReadKey();
            }





        }






    }


}
