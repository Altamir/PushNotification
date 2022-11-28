using System.Diagnostics;
using PushNotification.Domain;

namespace PushNotification.API.PushNotification;

public class Endpoint : EndpointWithMapping<Request, Response, Notification>
{
    private readonly IPushNotificationService _pushNotificationService;

    public Endpoint(IPushNotificationService pushNotificationService)
    {
        _pushNotificationService = pushNotificationService;
    }

    public override void Configure()
    {
        Post("/api/push-notification");
        AllowAnonymous();
        Version(1);
        SerializerContext(PushNotificationCtx.Default);
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        (NotificationError? error, Notification notificationResult)  = await _pushNotificationService.Send(MapToEntity(req), cancellationToken: ct);

        if (error is not null)
        {
            ThrowError($"Falha ao enviar notificação: {error.reason}");
        }
        
        await PublishAsync(new Events.MessageSent(notificationResult.MesageId!, notificationResult), cancellation:ct);
        
        await SendAsync(MapFromEntity(notificationResult), cancellation: ct);
    }

    public override Notification MapToEntity(Request r) => new(r.Title, r.Message, r.Image, r.Token, String.Empty);

    public override Response MapFromEntity(Notification e)
    {
        Debug.Assert(e.MesageId != null, "e.MesageId != null");
        return new(e.MesageId);
    }
}