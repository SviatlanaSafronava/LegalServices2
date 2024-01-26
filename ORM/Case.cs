﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Case
    {
        public long Id { get; set; }

        public string? Subject { get; set; }
        public long ContractId { get; set; }
        public virtual Contract? Contract { get; set; }
        public virtual ICollection<Document>? Documents { get; set; }
    }
}
