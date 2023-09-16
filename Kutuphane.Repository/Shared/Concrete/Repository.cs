using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly KutuphaneContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(KutuphaneContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public void Add(T item)
        {
            _dbSet.Add(item);

        }

        public void AddRange(IEnumerable<T> items)
        {
            _db.AddRange(items);
        }

        public virtual IQueryable<T> GetAll() //virtual bir metodu başka yerde ovveride edeceksek (ezeceksek) kullanılır
        {
            return _dbSet.Where(t => t.IsDeleted == false);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public void Remove(T item)
        {
            item.IsDeleted = true;

            _dbSet.Update(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            _dbSet.RemoveRange(items);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
