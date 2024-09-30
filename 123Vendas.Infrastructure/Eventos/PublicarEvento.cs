using Eventos;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Serilog;
using System.Text;

namespace _123Vendas.Infraestrutura.Eventos
{
    public class PublicarEvento(IConnection connection) : IPublicarEvento
    {
        private readonly IConnection _connection = connection;

        public async Task Publicar<T>(T evento) where T : class
        {
            using (var channel = _connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evento));
                channel.BasicPublish(exchange: "vendas-exchange",
                                      routingKey: "compra-criada",
                                      basicProperties: null,
                                      body: body);

                Log.Information("Evento publicado: {body}", body);
            }

            await Task.CompletedTask;
        }
    }
}
