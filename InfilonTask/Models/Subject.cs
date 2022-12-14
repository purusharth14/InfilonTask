using System.ComponentModel.DataAnnotations;

namespace InfilonTask.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}
