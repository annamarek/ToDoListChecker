using System.ComponentModel.DataAnnotations;

namespace ToDoChecker_Pro.Models
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool IsDone { get; set; } = false;
    }
}
