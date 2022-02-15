using System.ComponentModel.DataAnnotations;

namespace BliLiberProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Renditja")]
        [Range(1, 100, ErrorMessage = "Renditja mund të jetë vetem midis 1 dhe 100!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
