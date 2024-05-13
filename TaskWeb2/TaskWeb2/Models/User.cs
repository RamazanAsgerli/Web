using Microsoft.AspNetCore.Identity;

namespace TaskWeb2.Models
{
    public class User:IdentityUser
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
    }
}
