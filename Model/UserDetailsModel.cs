using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.Model
{
    public class UserDetailsModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Location { get; set; }
        
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RolesModel RolesModel { get; set; }

    }
}
