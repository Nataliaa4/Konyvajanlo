namespace BookCatalog
{
    internal class Book
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; } 
        public int Year { get; set; }         
        public bool IsFavorite { get; set; }  

        public Book(int id, string title, string author, string category, string description, int rating, int year, bool isFavorite)
        {
            Id = id;
            Title = title;
            Author = author;
            Category = category;
            Description = description;
            Rating = rating;
            Year = year;
            IsFavorite = isFavorite;
        }

        public override string ToString()
        {
            return $"{Id}. {Title} ({Author}) - {Category} - Értékelés: {Rating}/10 - Kiadás: {Year} {(IsFavorite ? "[Kedvenc]" : "")}";
        }
    }
}
