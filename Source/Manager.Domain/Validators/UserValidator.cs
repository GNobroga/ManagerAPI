using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("A entidade não pode ser null");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("O e-mail é inválido")
                .MaximumLength(100).WithMessage("O email não pode ser maior que 100 caracteres");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome não pode ser vazio ou nulo")
                .MinimumLength(3).WithMessage("O nome não pode ser menor que 6 caracteres")
                .MaximumLength(100).WithMessage("O nome não pode ser maior que 100 caracteres");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha não pode ser vazia")
                .MinimumLength(3).WithMessage("O nome não pode ser menor que 6 caracteres")
                .MaximumLength(100).WithMessage("O nome não pode ser maior que 100 caracteres");
                
        }
    }
}