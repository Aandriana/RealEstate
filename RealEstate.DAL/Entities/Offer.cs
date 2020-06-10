using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.DAL.Entities
{
   public class Offer : BaseEntity
    {
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int PropertyId { get; set; }
        public int Status { get; set; }
        public Property Property { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
