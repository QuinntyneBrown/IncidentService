using System;
using IncidentService.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static IncidentService.Constants;

namespace IncidentService.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class Incident: ILoggable
    {
        public int Id { get; set; }
        
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        
		[Index("IncidentNameIndex", IsUnique = false)]
        [Column(TypeName = "VARCHAR")]     
        [StringLength(MaxStringLength)]		   
		public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
        
		public DateTime LastModifiedOn { get; set; }
        
		public string CreatedBy { get; set; }
        
		public string LastModifiedBy { get; set; }
        
		public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
