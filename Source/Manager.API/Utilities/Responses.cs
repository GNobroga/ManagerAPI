namespace Manager.API.Utilities
{
    public sealed class Responses 
    {
        public class Result 
        {
            public string Message { get; init; } = "Erro interno, tente novamente mais tarde.";
            
            public bool Success { get; init; }

            public object? Data { get; set; }
        }

        public static Result DomainErrorMessage(string message)
        {
            return new Result 
            { 
                Message = message 
            };
        }

        public static Result DomainErrorMessage(string message, IEnumerable<string>? errors)
        {
            return new Result 
            { 
                Message = message, 
                Data = errors 
            };
        }

        public static Result UnauthorizedErrorMEssage()
        {
            return new Result 
            {
                Message = "Não authorizado"
            };  
        }

        public static Result SuccessOperation(string message, object data)
        {
            return new Result 
            {
                Message = message,
                Success = true,
                Data = data
            };
        }
    }
}