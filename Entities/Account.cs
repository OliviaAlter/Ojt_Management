using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Entities
{
    public class Account 
    {
        [Required]
        public int AccountId { get; set; }
        
        [Required]
        public string Username { get; set; }   
        
        [Required]
        public string Password { get; set; }    
        
        [Required]
        public int RoleId { get; set; }
        
        public virtual Role Roles { get; set; }
        public virtual Student Student { get; set; }
        
    }
}