using System;
using System.Collections.Generic;
using System.Text;

namespace BookCatalog
{
    internal class BookManager
    {
        public List<Book> Books { get; set; } = new List<Book>();

        public void AddBook(Book book) => Books.Add(book);

        public void ListBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine(book);
            }
        }

        public List<Book> SearchByTitle(string title)
        {
            return Books.FindAll(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        public List<Book> FilterByCategory(string category)
        {
            return Books.FindAll(b => b.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        public void ExportToCSV(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Id,Title,Author,Category,Description,Rating,Year,IsFavorite");
                foreach (var b in Books)
                {
                    writer.WriteLine($"{b.Id},{b.Title},{b.Author},{b.Category},{b.Description},{b.Rating},{b.Year},{b.IsFavorite}");
                }
            }
        }

        public void ImportFromCSV(string filePath)
        {
            if (!File.Exists(filePath)) return;
            Books.Clear();
            var lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                Books.Add(new Book(
                    int.Parse(parts[0]),
                    parts[1],
                    parts[2],
                    parts[3],
                    parts[4],
                    int.Parse(parts[5]),
                    int.Parse(parts[6]),
                    bool.Parse(parts[7])
                ));
            }
        }
    }
}
