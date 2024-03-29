﻿namespace ORM
{
    public class User
    {
        public long Id { get; set; }                    

        public string? Name { get; set; }  
        public string? Surname { get; set; }
        public string? SecondName { get; set; }
        public string? Email { get; set; }
        public string? NumberPassport { get; set; }  
        public string? NumberLicence { get; set; }
        public string? Password { get; set; }
        public long RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
     }
}
