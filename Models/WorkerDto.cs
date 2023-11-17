namespace ConsultaTrabajadores.Presentacion.Models
{
    public class WorkerDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CompleteName
        {
            get
            {
                return Name + " " + LastName;
            }
        }
        public BranchDto Branch { get; set; }
    }
}
