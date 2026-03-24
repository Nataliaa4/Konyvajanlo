using System;

namespace BookCatalog
{
    class Program
    {
        static void Main()
        {
            BookManager manager = new BookManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1 - Könyv hozzáadása");
                Console.WriteLine("2 - Könyvek listázása");
                Console.WriteLine("3 - Keresés cím alapján");
                Console.WriteLine("4 - Szűrés kategória szerint");
                Console.WriteLine("5 - CSV mentés");
                Console.WriteLine("6 - CSV betöltés");
                Console.WriteLine("7 - HTML export");
                Console.WriteLine("0 - Kilépés");
                Console.Write("Választás: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("Id: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Cím: ");
                            string title = Console.ReadLine();

                            Console.Write("Szerző: ");
                            string author = Console.ReadLine();

                            Console.Write("Kategória: ");
                            string category = Console.ReadLine();

                            Console.Write("Leírás: ");
                            string description = Console.ReadLine();

                            Console.Write("Értékelés (1-10): ");
                            int rating = int.Parse(Console.ReadLine());

                            Console.Write("Kiadás éve: ");
                            int year = int.Parse(Console.ReadLine());

                            Console.Write("Kedvenc? (i/n): ");
                            bool isFavorite = Console.ReadLine().Trim().ToLower() == "i";

                            Book newBook = new Book(id, title, author, category, description, rating, year, isFavorite);
                            manager.AddBook(newBook);

                            Console.WriteLine("Könyv hozzáadva!\n");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Hiba a hozzáadás során: {ex.Message}\n");
                        }
                        break;
                    case "2":
                        manager.ListBooks();
                        break;
                    case "3":
                        Console.Write("Cím keresése: ");
                        var results = manager.SearchByTitle(Console.ReadLine());
                        results.ForEach(Console.WriteLine);
                        break;
                    case "4":
                        Console.Write("Kategória: ");
                        var filtered = manager.FilterByCategory(Console.ReadLine());
                        filtered.ForEach(Console.WriteLine);
                        break;
                    case "5":
                        manager.ExportToCSV("books.csv");
                        Console.WriteLine("Mentés kész.");
                        break;
                    case "6":
                        manager.ImportFromCSV("books.csv");
                        Console.WriteLine("Betöltés kész.");
                        break;
                    case "7":
                        HtmlExporter.Export(manager.Books); 
                        break;
                    case "0":
                        exit = true;
                        break;
                }
            }
        }
    }
}