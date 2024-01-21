using Manager.Domain.Entities.Base;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; } 

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Validate();
        }

        public void SetName(string name)
        {
            Name = name;
            Validate();
        }

        public void SetPassword(string password) 
        {
            Password = password;
            Validate();
        }

        public void SetEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
           var validator = new UserValidator();
           var result = validator.Validate(this);

           if (!result.IsValid)
           {    
                var errors = new List<string>();
                
                foreach (var error in result.Errors)
                    errors.Add(error.ErrorMessage);

                throw new DomainValidationException($"Alguns campos do usuário são invalidos", errors);
           }

            return result.IsValid;
        }
    }
}