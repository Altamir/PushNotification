namespace PushNotification.Domain;

public interface IPushNotificationService
{
    public Task<(NotificationError? error,Notification notificationResult)> Send(Notification notification, CancellationToken cancellationToken);
}