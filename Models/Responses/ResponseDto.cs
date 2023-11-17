using ConsultaTrabajadores.Presentacion.Entities;

namespace ConsultaTrabajadores.Presentacion.Models.Responses
{
    public class ResponseDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public User Creator { get; set; }
    }
}
