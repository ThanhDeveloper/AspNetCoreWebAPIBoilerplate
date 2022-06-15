namespace Project.Core.Entities;

public class User: BaseEntity
{
    public string UserName { set; get; }
    public string Password { get; set; }
    
    public byte[] StoredSalt { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}