using ConsultaTrabajadores.API.Models.Responses;

namespace ConsultaTrabajadores.API.Services.Interfaces
{
    public interface IResponseService
    {
        ResponseDto CreateResponse(ResponseForCreationDto newResponse, int questionId, int userId);
        ResponseDto? GetResponse(int responseId);
    }
}