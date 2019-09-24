using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisfitsAssignment.Models.Repository
{
    public interface ICalculationDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity GetByUser(string UserId);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
