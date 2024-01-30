using DAL.Repository;
using DAL_Interface.Repository;
using Microsoft.EntityFrameworkCore;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable        
    {
        private readonly DbContext _context;

        private IGenericRepository<Role> roleRepository;

        private IGenericRepository<User> userRepository;

        private IGenericRepository<Document> documentRepository;

        private IGenericRepository<Contract> contractRepository;

        private IGenericRepository<Case> caseRepository; 

        public UnitOfWork (DbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Role> RoleRepository
        {
            get 
            { 
                if (roleRepository == null)
                {
                    roleRepository = new GenericRepository<Role>(_context);
                }
                return roleRepository; 

            }
            
        }  
        public IGenericRepository<User> UserRepository 
        {
            get 
            { 
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<User>(_context);
                }
                return userRepository; 
            }
        }  
        public IGenericRepository<Document> DocumentRepository 
        {
            get
            {
                if (documentRepository == null)
                {
                    documentRepository = new GenericRepository<Document>(_context);
                }
                return documentRepository;
            }
      
        }

        public IGenericRepository<Contract> ContractRepository
        {
            get
            {
                if (contractRepository == null)
                {
                    contractRepository = new GenericRepository<Contract>(_context);
                }
                return contractRepository;
            }


        }
        public IGenericRepository<Case> CaseRepository
        {
            get
            {
                if (caseRepository == null)
                {
                    caseRepository = new GenericRepository<Case>(_context);
                }
                return caseRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
  
    
}
