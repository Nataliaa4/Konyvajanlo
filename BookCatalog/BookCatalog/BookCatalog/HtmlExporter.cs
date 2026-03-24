using System;
using System.Collections.Generic;
using System.Text;

namespace BookCatalog
{
    internal class HtmlExporter
    {
        public static void Export(List<Book> books)
        {
            string template = File.ReadAllText("template/template.html");

            // Összes könyv oldal
            string itemsHtml = "";
            foreach (var b in books)
            {
                itemsHtml += $"<div class='card {(b.IsFavorite ? "favorite" : "")}'>" +
                             $"<h3>{b.Title}</h3><p>{b.Author}</p>" +
                             $"<p>{b.Category}</p><p>{b.Description}</p>" +
                             $"<p>Értékelés: {b.Rating}/10</p><p>Kiadás: {b.Year}</p>" +
                             $"</div>\n";
            }
            string itemsPage = template.Replace("{{TITLE}}", "Összes könyv").Replace("{{CONTENT}}", itemsHtml);
            File.WriteAllText("outputs/items.html", itemsPage);

            // Kedvenc könyvek
            string favHtml = "";
            foreach (var b in books.FindAll(x => x.IsFavorite))
            {
                favHtml += $"<div class='card favorite'>" +
                           $"<h3>{b.Title}</h3><p>{b.Author}</p>" +
                           $"<p>{b.Category}</p><p>{b.Description}</p>" +
                           $"<p>Értékelés: {b.Rating}/10</p><p>Kiadás: {b.Year}</p>" +
                           $"</div>\n";
            }
            string favPage = template.Replace("{{TITLE}}", "Kedvencek").Replace("{{CONTENT}}", favHtml);
            File.WriteAllText("outputs/favorites.html", favPage);

            // Főoldal
            string indexHtml = template.Replace("{{TITLE}}", "Könyvajánló")
                                       .Replace("{{CONTENT}}", $"<p>Összes könyv száma: {books.Count}</p>");
            File.WriteAllText("outputs/index.html", indexHtml);

            Console.WriteLine("HTML export kész!");
        }
    }
}
