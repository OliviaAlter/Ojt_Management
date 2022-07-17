using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return await _majorRepository.GetMajorList()
                .ToListAsync();
        }

        public async Task<IEnumerable<Major>> GetMajorListByName(string name)
        {
            return await _majorRepository.GetMajorListByName(name)
                .ToListAsync();
        }

        public async Task<Major> GetMajor(int majorId)
        {
            return await _majorRepository.GetMajor(majorId)
                .FirstOrDefaultAsync();
        }

        public async Task<Major> AddMajor(Major major)
        {
            return await _majorRepository.AddMajor(major);
        }

        public async Task<Major> UpdateMajor(Major major)
        {
            return await _majorRepository.UpdateMajor(major);
        }

        public async Task<bool> DeleteMajor(int majorId)
        {
            return await _majorRepository.DeleteMajor(majorId);
        }
    }
}