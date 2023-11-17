using ConsultaTrabajadores.API.Entities;
using InformacionCiudades.API.DBContexts;

namespace ConsultaTrabajadores.API.Data
{
    public class ResponseRepository : Repository, IResponseRepository
    {
        public ResponseRepository(WorkersQuestionsContext context) : base(context)
        {
        }

        public void AddResponse(Response newResponse)
        {
            _context.Responses.Add(newResponse);
        }

        public Response? GetResponse(int responseId)
        {
            return _context.Responses.Find(responseId);
        }
    }
}
