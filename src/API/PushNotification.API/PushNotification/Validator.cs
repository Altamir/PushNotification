using FluentValidation;

namespace PushNotification.API.PushNotification;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Titulo da mensagem é obrigatório.")
            .MinimumLength(5)
            .WithMessage("Titulo da mensagem esta muito curto.!")
            .MaximumLength(15)
            .WithMessage("Titulo da mensagem esta muito longa, máximo é 15.");

        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("Mensagem é obrigatório.")
            .MinimumLength(5)
            .WithMessage("Mensagem esta muito curto.!")
            .MaximumLength(180)
            .WithMessage("Mensagem esta muito longa, máximo é 180.");
        
        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("Token é obrigatório.")
            .MinimumLength(120)
            .WithMessage("Token esta muito curto.!");
    }
}