using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IRoleService
    {
        public Task<Role> GetRole(Role role);
    }
}