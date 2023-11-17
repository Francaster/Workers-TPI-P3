using System.ComponentModel.DataAnnotations;

namespace ConsultaTrabajadores.Presentacion.Models.Question
{
    public class QuestionForCreationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int EmployerId { get; set; }
        [Required]
        public int BranchId { get; set; }
    }
}
