using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.DAL.Entities
{
   public  class PropertyPhoto : BaseEntity
    {
        public string Path { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
