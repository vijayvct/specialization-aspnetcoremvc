namespace BookStoreMVCAPP.Models
{
    public enum Language
    {
        English,Hindi,Japaneses,German
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Language? Language { get; set; }
    }
}
