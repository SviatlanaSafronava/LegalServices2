using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Contract
    {

        public long Id { get; set; }

        public string? Data { get; set; }
        public string? Number { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Contract>? Contracts { get; set; }
        public Case Case { get; set; } = new Case();
    }       
}
