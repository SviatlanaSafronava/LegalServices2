using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Interface.Repository
{ 
    public interface IUnitOfWork : IDisposable
    {
    IGenericRepository<Role> RoleRepository { get; }
    IGenericRepository<User> UserRepository { get; }
    IGenericRepository<Document> DocumentRepository { get; }
    IGenericRepository<Contract> ContractRepository { get; }
    IGenericRepository<Case> CaseRepository { get; }
    void Save();
    void Dispose();

    }

}
