using System.ComponentModel.DataAnnotations;

namespace BookStoreMVCAPP.Models
{
    public enum Language
    {
        English,Hindi,Japaneses,German
    }

    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Author name is required")]
        [Display(Name ="Author Name")]
        public string Author { get; set; }

        [Required(ErrorMessage ="Book description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Language is required")]
        public Language? Language { get; set; }
    }
}
