using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;
using OJTManagementAPI.Repositories;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class MajorService : IMajorService
    {
        private readonly MajorRepository _majorRepository;

        public MajorService(MajorRepository majorRepository)
        {
            _majorRepository = majorRepository;
        }

        public async Task<IEnumerable<Major>> GetMajorList()
        {
            var majorList = await _majorRepository.GetMajorList();
            return majorList;
        }

        public Task<Major> AddMajor(Student student)
        {
            throw new System.NotImplementedException();
        }

        public Task<Major> UpdateMajor(Student student)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteMajor(int studentId)
        {
            throw new System.NotImplementedException();
        }
    }
}