using FluentValidation;
using Manager.Application.Users.Commands;

namespace Manager.Application.Users.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("O Id não pode ser nulo");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("O e-mail não é válido.");
            
            RuleFor(x => x.Password) 
                .MinimumLength(3).WithMessage("A senha precisa ter no mínimo 3 caracteres")
                .MaximumLength(100).WithMessage("A senha pode ter no máximo 100 caracteres");
            
            RuleFor(x => x.Password)
                .Equal(y => y.ConfirmationPassword).WithMessage("A senha de confirmação não bate com a senha.");
        }
    }
}