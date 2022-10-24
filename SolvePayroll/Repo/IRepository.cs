using SolvePayroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SolvePayroll.Repo
{
    public interface IGenericRepository<T> where T : class
    {
        public void Add(T entity);
        public void AddRange(IEnumerable<T> entities);
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
        //public T GetById(int id);
        //public T Delete(int id);
        //public T Update(T item);
        //public IEnumerable<T> FetchAll();
        //public T Add(T item);


    }
}
