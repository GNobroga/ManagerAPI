
using System.Text.Json.Serialization;

namespace Manager.Application.DTOs
{
    public sealed class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Password { get; set;}

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