using cpn_ctasMasivasSubscribe_service.Dtos;
using cpn_ctasMasivasSubscribe_service.MQ;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace cpn_ctasMasivasSubscribe_service.Services
{
    public class RabbitMQListenerService : BackgroundService
    {
        private readonly ILogger<RabbitMQListenerService> _logger;
        private readonly RabbitMQSettings _rabbitMQSettings;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQListenerService(ILogger<RabbitMQListenerService> logger, IOptions<RabbitMQSettings> rabbitMQSettings)
        {
            _logger = logger;
            _rabbitMQSettings = rabbitMQSettings.Value;

            var factory = new ConnectionFactory()
            {
                HostName = _rabbitMQSettings.Hostname,
                Port = _rabbitMQSettings.Port,
                UserName = _rabbitMQSettings.Username,
                Password = _rabbitMQSettings.Password,
                VirtualHost = _rabbitMQSettings.VirtualHost
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "cuentasMasivas",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var cuentas = JsonSerializer.Deserialize<List<CuentaDTO>>(message);

                _logger.LogInformation("Mensaje recibido: {Message}", message);

                foreach (var cuenta in cuentas)
                {
                    _logger.LogInformation($"Id: {cuenta.Id}, Lote: {cuenta.Lote}, Descripción: {cuenta.Descripcion}, Fecha: {cuenta.Fecha}");
                }
            };

            _channel.BasicConsume(queue: "cuentasMasivas",
                                 autoAck: true,
                                 consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }

    }
}
