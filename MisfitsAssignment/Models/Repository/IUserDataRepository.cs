using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisfitsAssignment.Models.Repository
{
    public interface IUserDataRepository <TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Get(string UserId);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);

    }
}
