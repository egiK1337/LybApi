using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.EfClasses;

public class Tag
{
    public Tag()
    {
    }

    [Key]
    [Required]
    [MaxLength(40)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Id { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; }
}
