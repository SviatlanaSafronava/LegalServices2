using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Document
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Date { get; set; }
        public long ContractId { get; set; }
        public virtual User? User { get; set; }

    }
}
