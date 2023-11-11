namespace Lib.Models;

public class UserLogin
{
    public Guid UserLoginId { get; set; }
    public string LoginProvider { get; set; }
    public string ProviderKey { get; set; }
    public string ProviderDisplayName { get; set; }
    public Guid UserId { get; set; } 
}
