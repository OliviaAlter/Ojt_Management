﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly OjtManagementContext _context;

        public StudentRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteStudent(int accountId)
        {
            var foundInStudent = await _context.Student
                .FirstOrDefaultAsync(s => s.AccountId == accountId);

            var foundInAccount = await _context.Account
                .FirstOrDefaultAsync(a => a.AccountId == accountId);

            if (foundInStudent == null || foundInAccount == null)
                return false;

            _context.Student.Remove(foundInStudent);
            _context.Account.Remove(foundInAccount);

            //TODO: Check if there are any ongoing OJT for the student

            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Student> GetStudentListAppliedByCompanyId(int companyId)
        {
            return _context.Student
                .Where(s => s.JobApplications
                    .Any(j => j.Company.CompanyId == companyId));
        }

        public IQueryable<Student> GetStudentListByMajorId(int majorId)
        {
            return _context.Student
                .Where(s => s.MajorId == majorId);
        }

        public IQueryable<Student> GetStudentListBySemesterId(int semesterId)
        {
            return _context.Student
                .Where(s => s.Semester.SemesterId == semesterId);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Student.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public IQueryable<Student> GetStudentList()
        {
            return _context.Student;
        }

        public IQueryable<Student> GetStudentListByName(string name)
        {
            return _context.Student
                .Where(s => s.Account.Username.ToLower().Contains(name.ToLower()));
        }
    }
}