using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IMajorService
    {
        public Task<IEnumerable<Major>> GetMajorList();
        public Task<IEnumerable<Major>> GetMajorListByName(string name);
        public Task<Major> GetMajorById(int majorId);
        public Task<Major> AddMajor(Major major);
        public Task<Major> UpdateMajor(Major major);
        public Task<Major> UpdateMajorById(int id, MajorUpdateDTO major);
        public Task<bool> DeleteMajor(int majorId);
    }
}