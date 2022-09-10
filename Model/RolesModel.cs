using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.Model
{
    public class RolesModel
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleType { get; set; }
    }
}
