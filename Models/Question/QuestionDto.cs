using ConsultaTrabajadores.Presentacion.Models.Responses;
using ConsultaTrabajadores.Presentacion.Enums;

namespace ConsultaTrabajadores.Presentacion.Models.Question
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EmployerId { get; set; }
        public int CreatorWorkerId { get; set; }
        public int BranchId { get; set; }
        public ICollection<ResponseDto> Responses { get; set; } = new List<ResponseDto>();
        public QuestionState QuestionState { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }
}
