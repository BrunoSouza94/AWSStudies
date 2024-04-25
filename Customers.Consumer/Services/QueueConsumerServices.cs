
using Amazon.SQS;
using Amazon.SQS.Model;
using Customers.Consumer.Contracts.Messages;
using Customers.Consumer.Messaging;
using MediatR;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Customers.Consumer.Services;

public class QueueConsumerServices : BackgroundService
{
    private readonly IAmazonSQS _sqs;
    private readonly IMediator _mediator;
    private readonly ILogger<QueueConsumerServices> _logger;
    private readonly IOptions<QueueSettings> _queueSettings;

    public QueueConsumerServices(IAmazonSQS sqs, IMediator mediator, IOptions<QueueSettings> queueSettings, ILogger<QueueConsumerServices> logger)
    {
        _sqs = sqs;
        _mediator = mediator;
        _queueSettings = queueSettings;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueUrlResponse = await _sqs.GetQueueUrlAsync(_queueSettings.Value.Name, stoppingToken);

        var receiveMessageRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrlResponse.QueueUrl,
            AttributeNames = new List<string> { "All" },
            MessageAttributeNames = new List<string> { "All" },
            MaxNumberOfMessages = 1
        };

        while(!stoppingToken.IsCancellationRequested)
        {
            var response = await _sqs.ReceiveMessageAsync(receiveMessageRequest, stoppingToken);

            foreach(var message in response.Messages)
            {
                var messageType = message.MessageAttributes["MessageType"].StringValue;
                var type = Type.GetType($"Customers.Consumer.Contracts.Messages.{messageType}");

                if (type is null)
                {
                    _logger.LogWarning("Unknown message type: {MessageType}", messageType);

                    continue;
                }

                var typedMessage = (ISQSMessage)JsonSerializer.Deserialize(message.Body, type)!;

                try
                {
                    await _mediator.Send(typedMessage, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Message failed during processing");

                    continue;
                }

                await _sqs.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}