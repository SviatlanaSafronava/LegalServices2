namespace ORM
{
    public class User
    {
        public long Id { get; set; }                    

        public string? Name { get; set; }  
        public string? Surname { get; set; }
        public string? SecondName { get; set; }
        public string? Email { get; set; }
        public string? NumberPassword { get; set; }  
        public string? NumberLicence { get; set; }
        public long RoleId { get; set; }
        public virtual Role? Role { get; set; }
    }
}
