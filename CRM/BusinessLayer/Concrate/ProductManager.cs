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
    public class ProductManager : IService<Products>
    {
        private readonly IRepository<Products> _products;

        public ProductManager(IRepository<Products> products)
        {
            _products = products;
        }

        public void Add(Products entity)
        {
            _products.Insert(entity);
        }

        public void Delete(Products entity)
        {
            _products.Delete(entity);
        }

        public Products GetById(int id)
        {
            return _products.Get(x=>x.ProductId.Equals(id));
        }

        public List<Products> List()
        {
            return _products.List();
        }

        public List<Products> List(Expression<Func<Products, bool>> filter)
        {
            return _products.List(filter);
        }

        public void Update(Products entity)
        {
            _products.Update(entity);
        }
    }
}
