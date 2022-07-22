using System.Linq;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IRoleRepository
    {
        public IQueryable<Role> GetRole(Role role);
    }
}