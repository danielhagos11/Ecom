using Ecom.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategory Category { get; }
        IProduct Product { get; }
        ICompany Company { get; }
        IShoppingCart ShoppingCart { get; }
        IApplicationUser ApplicationUser { get; }
        IOrderDetail OrderDetail { get; }
        IOrderHeader OrderHeader { get; }
        void Save();
    }
}
