﻿using GeekShopping.MessageBus;

namespace GeekShopping.CartAPI.RabbitMqSender;

public interface IRabbitMqMessageSender
{
    void SendMessage(BaseMessage baseMessage, string queueName);
}
