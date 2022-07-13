using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class MajorRepository : IMajorRepository
    {
        private readonly OjtManagementContext _context;

        public MajorRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Major>> GetMajorList()
        {
            return null;
        }

        public IQueryable<Major> GetMajorListByName(string majorName)
        {
            return null;
        }

        public IQueryable<Major> GetMajorListBbyId(int majorId)
        {
            return null;
        }

        public async Task<Major> AddMajor(Major major)
        {
            return null;
        }

        public async Task<Major> UpdateMajor(Major major)
        {
            return null;
        }

        public async Task<bool> DeleteMajor(int majorId)
        {
            return true;
        }
    }
}