using System.ComponentModel.DataAnnotations;


namespace TodoApi.Models.Request {
    public class AuthenticateRequest {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
