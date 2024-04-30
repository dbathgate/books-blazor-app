using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksApi.Data;

[Table("books")]
public class BookDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("name")]
    [Required]
    public string? Name { get; set; }
    
    [Column("author")]
    [Required]
    public string? Author { get; set; }
}