using PushNotification.Domain;

namespace PushNotification.API.PushNotification;

public class Events
{
    public record MessageSent(string MessageId, Notification Notification);
    
    public class MessageSentHandler : IEventHandler<MessageSent>
    {
        private readonly ILogger _logger;

        public MessageSentHandler(ILogger<MessageSentHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(MessageSent messageSent, CancellationToken ct)
        {
            _logger.LogInformation("Message sent:[{MessageIdSent}]", messageSent.MessageId);
            return Task.CompletedTask;
        }
    }
}