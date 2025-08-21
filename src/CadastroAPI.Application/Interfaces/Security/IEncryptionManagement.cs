namespace CadastroAPI.Application.Interfaces.Security
{
    public interface IEncryptionManagement
    {
        (byte[] hash, byte[] salt) HashPassword(string password);
        bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
    }
}