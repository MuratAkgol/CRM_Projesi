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
    public class OrderItemManager : IService<OrderItems>
    {
        private readonly IRepository<OrderItems> _orderItems;

        public OrderItemManager(IRepository<OrderItems> orderItems)
        {
            _orderItems = orderItems;
        }

        public void Add(OrderItems entity)
        {
            _orderItems.Insert(entity);
        }

        public void Delete(OrderItems entity)
        {
            _orderItems.Delete(entity);
        }

        public OrderItems GetById(int id)
        {
            return _orderItems.Get(x=> x.OrderId.Equals(id));
        }

        public List<OrderItems> List()
        {
            return _orderItems.List();
        }

        public List<OrderItems> List(Expression<Func<OrderItems, bool>> filter)
        {
            return _orderItems.List(filter);
        }

        public void Update(OrderItems entity)
        {
            _orderItems.Update(entity);
        }
    }
}
