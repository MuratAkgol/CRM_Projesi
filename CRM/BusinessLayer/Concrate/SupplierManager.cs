using BusinessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class SupplierManager : IService<Suppliers>
    {
        private readonly IRepository<Suppliers> _supplier;

        public SupplierManager(IRepository<Suppliers> supplier)
        {
            _supplier = supplier;
        }

        public void Add(Suppliers entity)
        {
            _supplier.Insert(entity);
        }

        public void Delete(Suppliers entity)
        {
            _supplier.Delete(entity);
        }

        public Suppliers GetById(int id)
        {
            return _supplier.Get(x => x.SupplierId.Equals(id));
        }

        public List<Suppliers> List()
        {
            return _supplier.List();
        }

        public List<Suppliers> List(Expression<Func<Suppliers, bool>> filter)
        {
            return _supplier.List(filter);  
        }

        public void Update(Suppliers entity)
        {
            _supplier.Update(entity);
        }
    }
}
