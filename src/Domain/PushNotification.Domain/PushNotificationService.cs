using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using static FirebaseAdmin.Messaging.FirebaseMessaging;

namespace PushNotification.Domain;

public class PushNotificationService : IPushNotificationService
{
    public async Task<(NotificationError? error, Notification notificationResult)> Send(Notification notification, CancellationToken cancellationToken)
    {
        FirebaseAdmin.Messaging.Notification mNotifications = new()
        {
            Title = notification.Title,
            Body = notification.Message,
            ImageUrl = notification.Image
        };

        Message message = new()
        {
            Notification = mNotifications,
            Token = notification.Token,
        };

        if (FirebaseApp.DefaultInstance == null)
        {
            var options = new AppOptions
            {
                Credential = await GoogleCredential.GetApplicationDefaultAsync(cancellationToken)
            };
            FirebaseApp.Create(options);
        }

        try
        {
            var response = await DefaultInstance.SendAsync(message, cancellationToken);
            return (null, notification with { MesageId = response });
        }
        catch (Exception e)
        {
            return (new NotificationError(e.Message), notification);
        }

    }
}