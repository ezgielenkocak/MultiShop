using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class 
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public void Delete(int Id)
        {
            var values = _context.Set<T>().Find(Id);
            _context.Set<T>().Remove(values);
            _context.SaveChanges(); 
        }

        public List<T> GetAll()
        {
            var values=_context.Set<T>().ToList();
            return values;
        }

        public T GetById(int Id)
        {
           var value=_context.Set<T>().Find(Id);
            return value;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
