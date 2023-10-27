using Ecom.DataAccess.Data;
using Ecom.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategory Category { get; private set; }

        public IProduct Product { get; private set; }
        public ICompany Company { get; private set; }
        public IShoppingCart ShoppingCart { get; private set; }
        public IApplicationUser ApplicationUser { get; private set; }
        public IOrderDetail OrderDetail { get; private set; }
        public IOrderHeader OrderHeader { get; private set; }


        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
