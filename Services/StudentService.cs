﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OJTManagementAPI.CustomEntities;
using OJTManagementAPI.Entities;
using OJTManagementAPI.Options;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly PaginationOptions _paginationOptions;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository, IOptions<PaginationOptions> options)
        {
            _studentRepository = studentRepository;
            _paginationOptions = options.Value;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var newStudent = await _studentRepository.AddStudent(student);
            return newStudent;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            var isDeleted = await _studentRepository.DeleteStudent(studentId);
            return isDeleted;
        }

        /*
        public async Task<PagedList<Student>> GetStudentList(int? page, int? pageSize)
        {
            var studentList = await _studentRepository.GetStudentList();
            return studentList ?? null;
            
            //var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            //var size = pageSize ?? _paginationOptions.DefaultPageSize;

            //var pagedList = await PagedList<Student>.Create(studentList, pageNum, size);
        }
        */
        
        /*
        public async Task<PagedList<Student>> GetStudentList(int? page, int? pageSize)
        {
            var studentList = _studentRepository.GetStudentList();
            if (studentList == null || !studentList.Any()) return null;
            var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            var size = pageSize ?? _paginationOptions.DefaultPageSize;

            var pagedList = await PagedList<Student>.Create(studentList, pageNum, size);

            return pagedList;
        }
        */

        public async Task<List<Student>> GetStudentList()
        {
            var studentList = await _studentRepository.GetStudentList();
            return studentList;
        }

        public async Task<PagedList<Student>> GetStudentListAppliedByCompanyId(int companyId, int? page, int? pageSize)
        {
            var studentList = _studentRepository.GetStudentListAppliedByCompanyId(companyId);
            if (studentList == null || !studentList.Any()) return null;
            var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            var size = pageSize ?? _paginationOptions.DefaultPageSize;

            var pagedList = await PagedList<Student>.Create(studentList, pageNum, size);

            return pagedList;
        }

        public async Task<PagedList<Student>> GetStudentListByMajorId(int majorId, int? page, int? pageSize)
        {
            var studentList = _studentRepository.GetStudentListByMajorId(majorId);
            if (studentList == null || !studentList.Any()) return null;
            var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            var size = pageSize ?? _paginationOptions.DefaultPageSize;

            var pagedList = await PagedList<Student>.Create(studentList, pageNum, size);

            return pagedList;
        }

        public async Task<PagedList<Student>> GetStudentListBySemesterId(int semesterId, int? page, int? pageSize)
        {
            var studentList = _studentRepository.GetStudentListBySemesterId(semesterId);
            if (studentList == null || !studentList.Any()) return null;
            var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            var size = pageSize ?? _paginationOptions.DefaultPageSize;

            var pagedList = await PagedList<Student>.Create(studentList, pageNum, size);

            return pagedList;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var updatedStudent = await _studentRepository.UpdateStudent(student);
            return updatedStudent;
        }
    }
}