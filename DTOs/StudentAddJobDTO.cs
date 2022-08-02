using System.Collections.Generic;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOs
{
    public class StudentAddJobDTO
    {
        public int MajorId { get; set; }
        public int SemesterId { get; set; }
    }
}