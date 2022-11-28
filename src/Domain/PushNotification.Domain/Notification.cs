namespace PushNotification.Domain;

public record class Notification(
    string Title,
    string Message,
    string? Image,
    string? Token,
    string? MesageId);