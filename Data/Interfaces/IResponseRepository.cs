using ConsultaTrabajadores.API.Entities;

namespace ConsultaTrabajadores.API.Data
{
    public interface IResponseRepository : IRepository
    {
        void AddResponse(Response newResponse);
        Response? GetResponse(int responseId);
    }
}