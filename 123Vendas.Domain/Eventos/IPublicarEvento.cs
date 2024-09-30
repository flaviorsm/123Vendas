namespace Eventos
{
    public interface IPublicarEvento
    {
        Task Publicar<T>(T evento) where T : class;
    }
}
