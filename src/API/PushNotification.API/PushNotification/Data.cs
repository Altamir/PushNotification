using System.Text.Json.Serialization;

namespace PushNotification.API.PushNotification;

public class Response
{
    public Response(string messageId)
    {
        MessageId = messageId;
    }

    public string MessageId { get; set; }
}
public class Request
{ 
    public string Title { get; set; }
    public string Message { get; set; }
    public string? Image { get; set; }
    public string Token { get; set; }
}

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Request))]
[JsonSerializable(typeof(Response))]
public partial class PushNotificationCtx : JsonSerializerContext
{
}