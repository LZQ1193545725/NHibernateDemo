using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Data
{
    public class DataRepository<T>:IDataRepository<T> where T:class,new()
    {
        NHibernateHelper context = new NHibernateHelper();
        public List<T> GetAll()
        {
            using (ISession db = context.GetSession()) {
                return db.Query<T>().ToList();
            }
        }
        public T Get(Expression<Func<T, bool>> expression)
        {
            using (ISession db = context.GetSession())
            {
                return db.Query<T>().Where(expression).FirstOrDefault();
            }
        }
        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            using (ISession db = context.GetSession())
            {
                return db.Query<T>().Where(expression).ToList();
            }
        }
        public void Dispose() { }
    }
    public interface IDataRepository<T> : IDisposable where T : class, new()
    {
        List<T> GetAll();
        T Get(Expression<Func<T,bool>> expression);
        List<T> GetList(Expression<Func<T, bool>> expression);
    }
}
