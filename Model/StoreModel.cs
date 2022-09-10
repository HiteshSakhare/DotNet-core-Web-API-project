using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.Model
{
    public class StoreModel
    {
        [Key]
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
    }
}
