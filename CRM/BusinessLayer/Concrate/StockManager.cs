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
    public class StockManager : IService<Stocks>
    {
        private readonly IRepository<Stocks> _stock;

        public StockManager(IRepository<Stocks> stock)
        {
            _stock = stock;
        }

        public void Add(Stocks entity)
        {
            _stock.Insert(entity);
        }

        public void Delete(Stocks entity)
        {
            _stock.Delete(entity);
        }

        public Stocks GetById(int id)
        {
            return _stock.Get(x=>x.StockId.Equals(id));
        }

        public List<Stocks> List()
        {
            return _stock.List();
        }

        public List<Stocks> List(Expression<Func<Stocks, bool>> filter)
        {
            return _stock.List(filter);
        }

        public void Update(Stocks entity)
        {
            _stock.Update(entity);
        }
    }
}
