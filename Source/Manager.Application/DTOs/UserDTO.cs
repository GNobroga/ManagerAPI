
using System.Text.Json.Serialization;

namespace Manager.Application.DTOs
{
    public sealed class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Password { get; set;}

        public UserDTO() {}

        public UserDTO(string name, string email, string password) {
            Name = name;
            Email = email;
            Password = password;
        }

        public UserDTO(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}