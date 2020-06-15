using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.DAL.Entities
{
   public abstract class BaseEntity
    {
        public int Id { get; set; }

        public string CreatedById { get; set; }

        public string UpdatedById { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public DateTime? UpdatedDateUtc { get; set; }

        public bool Archive { get; set; }
    }
}
