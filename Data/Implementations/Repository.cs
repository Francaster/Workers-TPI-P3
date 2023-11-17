using InformacionCiudades.API.DBContexts;

namespace ConsultaTrabajadores.API.Data
{
    public class Repository : IRepository
    {
        internal readonly WorkersQuestionsContext _context;

        public Repository(WorkersQuestionsContext context)
        {
            this._context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
