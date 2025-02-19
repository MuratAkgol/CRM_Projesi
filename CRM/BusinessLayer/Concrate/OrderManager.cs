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
    public class OrderManager : IService<Orders>
    {
        private readonly IRepository<Orders> _order;

        public OrderManager(IRepository<Orders> manager)
        {
            _order = manager;
        }

        public void Add(Orders entity)
        {
            _order.Insert(entity);
        }

        public void Delete(Orders entity)
        {
            _order.Delete(entity);
        }

        public Orders GetById(int id)
        {
            return _order.Get(x=>x.OrderId.Equals(id));
        }

        public List<Orders> List()
        {
            return _order.List();
        }

        public List<Orders> List(Expression<Func<Orders, bool>> filter)
        {
            return _order.List(filter);
        }

        public void Update(Orders entity)
        {
            _order.Update(entity);
        }
    }
}
