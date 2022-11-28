namespace LibraryApp.Models
{
    public class AuthenticationDTO
    {
    }

    public class AuthenticationRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }  
    
    public class AuthenticationResponse
    {
        public string? Token { get; set; }
        public DateTime? ExpirationTime { get; set; }
        public string Role { get; set; } 
        
        public Guid Id { get; set; }
    }
}
