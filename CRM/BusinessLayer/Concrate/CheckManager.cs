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
    public class CheckManager : IService<Checks>
    {
        private readonly IRepository<Checks> _checks;

        public CheckManager(IRepository<Checks> checks)
        {
            _checks = checks;
        }

        public void Add(Checks entity)
        {
            _checks.Insert(entity);
        }

        public void Delete(Checks entity)
        {
            _checks.Delete(entity);
        }

        public Checks GetById(int id)
        {
            return _checks.Get(x=>x.CheckId == id);
        }

        public List<Checks> List()
        {
            return _checks.List();
        }

        public List<Checks> List(Expression<Func<Checks, bool>> filter)
        {
            return _checks.List(filter);
        }

        public void Update(Checks entity)
        {
            _checks.Update(entity);
        }
    }
}
