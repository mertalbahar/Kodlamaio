using Kodlamaio.Core.DataAccess;
using Kodlamaio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.DataAccess.Concretes.EntityFramework;

public class EfEntityRepositoryBase<T> : IEntityRepository<T>
    where T : class, IEntity, new()
{
    protected readonly KodlamaioContext _context;

    public EfEntityRepositoryBase(KodlamaioContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        return _context.Set<T>().SingleOrDefault(filter);
    }

    public List<T> GetAll(Expression<Func<T, bool>> filter = null)
    {
        return filter == null
            ? _context.Set<T>().ToList()
            : _context.Set<T>().Where(filter).ToList();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
}
