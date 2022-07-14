using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IMajorService
    {
        public Task<List<Major>> GetMajorList();
        public Task<Major> AddMajor(Student student);
        public Task<Major> UpdateMajor(Student student);
        public Task<bool> DeleteMajor(int studentId);
    }
}