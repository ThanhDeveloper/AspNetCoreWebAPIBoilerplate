namespace Project.Service.Common.Security;

public class HashSalt
{
    public string Hash { get; set; }
    public byte[] Salt { get; set; }
}