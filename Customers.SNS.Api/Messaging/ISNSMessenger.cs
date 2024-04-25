using Amazon.SimpleNotificationService.Model;

namespace Customers.Api.Messaging;

public interface ISNSMessenger
{
    Task<PublishResponse> PublishMessageAsync<T>(T message);
}