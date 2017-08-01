using System;
using System.Collections.Generic;
using IncidentService.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentService.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class Tenant: ILoggable
    {
        public int Id { get; set; }
        
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        
		[Index("TenantNameIndex", IsUnique = false)]
        [Column(TypeName = "VARCHAR")]     
        [StringLength(255)]		   
		public string Name { get; set; }
        
		public DateTime CreatedOn { get; set; }
        
		public DateTime LastModifiedOn { get; set; }
        
		public string CreatedBy { get; set; }
        
		public string LastModifiedBy { get; set; }
        
		public bool IsDeleted { get; set; }

        public Guid UniqueId { get; set; }
    }
}
