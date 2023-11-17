namespace ConsultaTrabajadores.API.Services.Interfaces
{
    public interface IMailService
    {
        void Enviar(string asunto, string mensaje, string correoDestino);
    }
}