using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Tirelires.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private TireliresContext _context;

        public Repository(TireliresContext context)
        {
            _context = context;
        }

        public T Create(T item)
        {
            try
            {
                _context.Set<T>().Add(item);
                _context.SaveChanges();
                return item;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public T Delete(T item)
        {
            try
            {
                _context.Set<T>().Remove(item);
                _context.SaveChanges();
                return item;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public T Edit(T item)
        {
            try
            {
                _context.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
                return item;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public T Get(int id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public T Get(string id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}
