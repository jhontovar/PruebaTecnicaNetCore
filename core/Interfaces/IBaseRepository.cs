using core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entity);

        bool Delete(TEntity entity);

        TEntity Get(Expression<Func<TEntity, bool>> expression);

        List<TEntity> List(Expression<Func<TEntity, bool>> expression, bool tracking = true);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities);
    }
}
