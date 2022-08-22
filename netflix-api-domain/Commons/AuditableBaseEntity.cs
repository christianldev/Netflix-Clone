using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflix_api_domain.Commons;


//clase entidad base para herencia de entidades
public abstract class AuditableBaseEntity
{
    public virtual int Id { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
