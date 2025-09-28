using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GuestBookApp
{
    public class GuestBook
    {
        // Json-filen där vi lagrar listan
        private string filename = @"guestbook.json";
        // En lista för alla poster i gästboken
        private List<Post> posts = new List<Post>();

        // Konstruktor
        public GuestBook()
        {
            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename);
                if (!string.IsNullOrWhiteSpace(jsonString)) // <-- fix för tom fil
                {
                    posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;
                }
            }
        }

        // Lägg till post
        public Post AddPost(string user, string message)
        {
            var post = new Post(user, message);
            posts.Add(post);
            SaveToFile();
            return post;
        }

        // Ta bort post
        public bool DeletePost(int index)
        {
            if (index < 0 || index >= posts.Count) return false;
            posts.RemoveAt(index);
            SaveToFile();
            return true;
        }

        // Hämta alla poster
        public List<Post> GetPosts()
        {
            return posts;
        }

        // Spara till fil
        private void SaveToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(posts, options);
            File.WriteAllText(filename, jsonString);
        }
    }
}
