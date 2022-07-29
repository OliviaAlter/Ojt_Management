using System.Linq;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly OjtManagementContext _context;

        public RoleRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public IQueryable<Role> GetRole(Role role)
        {
            return _context.Role
                .Where(a => a.RoleId == role.RoleId);
        }
    }
}