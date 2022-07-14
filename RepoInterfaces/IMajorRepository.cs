using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IMajorRepository
    {
        public Task<List<Major>> GetMajorList();
        public Task<List<Major>> GetMajorListByName(string majorName);
        public Task<Major> AddMajor(Major major);
        public Task<Major> UpdateMajor(Major major);
        public Task<bool> DeleteMajor(int majorId);
    }
}