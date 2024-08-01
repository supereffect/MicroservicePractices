
using System.Text;
using CommandsService.EventProcessing;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CommandsService.AsyncDataServices
{
    //this class will work in background so we dont implement it with interface to not make things torturous
    //so we called it basically background service
    //its going to listen events ultimately

    public class MessageBusSubscriber : BackgroundService
    {
        private IConfiguration _configuration;
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;
        private readonly IEventProcessor _eventProcessor;

        public MessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
        {
            _configuration = configuration;
            _eventProcessor = eventProcessor;
            InıtializeRabbitMQ();
        }
        private void InıtializeRabbitMQ()
        {

            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                //You should choose best approach to your project reqs. Dirext / Fanout / Topic / Header...
                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _queueName = _channel.QueueDeclare().QueueName;
                _channel.QueueBind(queue: _queueName, exchange: "trigger", routingKey: "");
                Console.WriteLine("--> listening on the MessageBus");
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutDown;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Couldn't connect message bus:{_configuration["RabbitMQHost"]} - > {ex.Message}");
            }
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ModuleHandle, ea)=>
            {
                Console.WriteLine("--> Evenet received!");
                var body = ea.Body;
                var notificationMessage = Encoding.UTF8.GetString(body.ToArray());  

                _eventProcessor.ProcessEvent(notificationMessage);  
            };

            _channel.BasicConsume(queue:_queueName,autoAck:true, consumer:consumer);
            return Task.CompletedTask;
        }

        private void RabbitMQ_ConnectionShutDown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--> RabbitMQ Conn shutdown");
        }

        public override void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
            base.Dispose();
        }
    }
}