using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Index(nameof(StudentId), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int SchoolId { get; set; }

    [ForeignKey("SchoolId")]
    public School? School { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string StudentId { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Phone must be 10-11 digits.")]
    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}