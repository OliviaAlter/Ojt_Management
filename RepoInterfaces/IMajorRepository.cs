using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IMajorRepository
    {
        public IQueryable<Major> GetMajorList();
        public IQueryable<Major> GetMajorByName(string majorName);
        public IQueryable<Major> GetMajorById(int majorId);
        public Task<Major> AddMajor(Major major);
        public Task<Major> UpdateMajor(Major major);
        public Task<bool> DeleteMajor(int majorId);
    }
}