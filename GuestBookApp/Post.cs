using System;

namespace GuestBookApp
{
    public class Post
    {
        public string User { get; set; }
        public string Message { get; set; }

        // Konstruktor för att ta emot parametrarna 
        public Post(string user, string message)
        {
            User = user;
            Message = message;
        }
    }
}
