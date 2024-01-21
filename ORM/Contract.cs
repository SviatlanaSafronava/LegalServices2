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
            public long UserId { get; set; }
            public virtual User? User { get; set; }
        
    }
}
