using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models.Database;

namespace WeatherApp.Interfaces
{
    public interface IBaseRepository<TEntity, TIdentifire> where TEntity : BaseModel<TIdentifire>
    {
        List<TEntity> GetAll();
        TEntity Find(TIdentifire id);
        void Create(TEntity entity);
        void CreateRange(List<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Delete(TIdentifire id);
    }
}
