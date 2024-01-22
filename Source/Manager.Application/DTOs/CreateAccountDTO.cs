namespace Manager.Application.DTOs
{
    public record CreateAccountDTO(
        string Email,
        string Password,
        string ConfirmationPassword
    );
}