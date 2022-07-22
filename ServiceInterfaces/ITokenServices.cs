using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface ITokenServices
    {
        string CreateToken(Account account);
    }
}