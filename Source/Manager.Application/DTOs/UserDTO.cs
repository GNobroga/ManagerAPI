
namespace Manager.Application.DTOs
{
    public record UserDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
 
        public string Password { get; init; }

        public UserDTO() {}
    
        public UserDTO(int id, string name, string email, string password) {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }    
    }
}