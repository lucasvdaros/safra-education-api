namespace SafraEducacional.Domain.DTO.Login
{
    public class LoginAccessDTO
    {
        public bool Authenticated { get; set; }       
        public string AccessToken { get; set; } 
    }
}