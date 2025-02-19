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
    public class UserManager : IService<Users>
    {
        private readonly IRepository<Users> _user;   
        public void Add(Users entity)
        {
            _user.Insert(entity);
        }

        public void Delete(Users entity)
        {
            _user.Delete(entity);
        }

        public Users GetById(int id)
        {
            return _user.Get(x=> x.UserId.Equals(id)); 
        }

        public List<Users> List()
        {
            return _user.List();
        }

        public List<Users> List(Expression<Func<Users, bool>> filter)
        {
            return _user.List(filter);
        }

        public void Update(Users entity)
        {
            _user.Update(entity);
        }
    }
}
