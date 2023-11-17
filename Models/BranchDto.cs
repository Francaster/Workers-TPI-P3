namespace ConsultaTrabajadores.Presentacion.Models
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployerDto> Employers { get; set; } = new List<EmployerDto>();

    }
}
