using GeekShopping.CartAPI.Messages;
using GeekShopping.MessageBus;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GeekShopping.CartAPI.RabbitMqSender;

public class RabbitMqMessageSender : IRabbitMqMessageSender
{
    private readonly string _hostName;
    private readonly string _password;
    private readonly string _userName;
    private IConnection _connection;

    public RabbitMqMessageSender()
    {
        _hostName = "localhost";
        _password = "guest";
        _userName = "guest";
    }

    public void SendMessage(BaseMessage baseMessage, string queueName)
    {
        var factory = new ConnectionFactory()
        {
            HostName = _hostName,
            UserName = _userName,
            Password = _password,
        };

        _connection = factory.CreateConnection();

        using var channel = _connection.CreateModel();
        channel.QueueDeclare(queueName, false, false, false);
        var body = GetMessageAsByteArray(baseMessage);
        channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
    }

    private byte[] GetMessageAsByteArray(BaseMessage baseMessage)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(baseMessage, options);
        return Encoding.UTF8.GetBytes(json);
    }
}
