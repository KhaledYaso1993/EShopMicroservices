using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstractions
{
    public abstract class Entity<Guid> : Entity<Guid>
    {
        public Guid Id {set;get;}
        public DateTime? CreatedAt {set;get;}
        public string? CreatedBy {set;get;}
        public DateTime? LastModified {set;get;}
        public string? LastModifiedBy {set;get;}
    }
}
