using System;

namespace GuestBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GuestBook guestBook = new GuestBook();
            int i = 0;

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("G Ä S T B O K");
                Console.WriteLine("==============");

                Console.WriteLine("1. Lägg till inlägg");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("X. Avsluta\n");

                // Lista alla inlägg

                i = 0;
                foreach (Post post in guestBook.GetPosts())
                {
                    Console.WriteLine($"{i}. {post.User} skrev: {post.Message}");
                    i++;
                }

                int choice = (int)Console.ReadKey(true).Key;
                switch (choice)
                {
                    case '1':
                        Console.Write("Ange namn: ");
                        string? user = Console.ReadLine();

                        Console.Write("Ange meddelande: ");
                        string? message = Console.ReadLine();

                        if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(message))
                        {
                            guestBook.AddPost(user, message);
                        }
                        else
                        {
                            Console.WriteLine("Namn och meddelande får inte vara tomma. Tryck på valfri tangent för att fortsätta.");
                            Console.ReadKey();
                        }
                        break;

                    case '2':
                        Console.Write("Ange index för inlägg att ta bort: ");

                        string? index = Console.ReadLine();

                        if (!string.IsNullOrEmpty(index))
                        {
                            try
                            {
                                if (!guestBook.DeletePost(Convert.ToInt32(index)))
                                {
                                    Console.WriteLine("Inlägget med det indexet finns inte. Tryck på valfri tangent för att fortsätta.");
                                    Console.ReadKey();
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Index måste vara en siffra. Tryck på valfri tangent för att fortsätta.");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 88: // X
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
