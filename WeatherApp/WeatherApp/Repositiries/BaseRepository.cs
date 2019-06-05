using Prism.Events;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Interfaces;
using WeatherApp.Models.Database;

namespace WeatherApp.Repositiries
{
    public class BaseRepository<TEntity, TIdentifire> : IBaseRepository<TEntity, TIdentifire>
      where TEntity : BaseModel<TIdentifire>, new()
    {
        protected SQLiteConnection _connection;
        

        public BaseRepository(SQLiteConnection databaseConnectionService)
        {
            _connection = databaseConnectionService;
           
        }

        #region Public methods
        public List<TEntity> GetAll()
        {
            List<TEntity> entities = _connection.Table<TEntity>().ToList();

            return entities;
        }

        public TEntity Find(TIdentifire id)
        {
            TEntity entity = _connection.Table<TEntity>().FirstOrDefault(item => item.Equals(id));

            return entity;
        }

        public void Update(TEntity entity)
        {
            _connection.Update(entity);
        }

        public void UpdateRange(List<TEntity> entity)
        {
            _connection.UpdateAll(entity, true);
        }

        public void Delete(TIdentifire id)
        {
            _connection.Delete<TEntity>(id);
        }

        public void Create(TEntity entity)
        {
             _connection.Insert(entity);
        }

        public void CreateRange(List<TEntity> entities)
        {
            _connection.InsertAll(entities, true);
        }
        #endregion

        #region Private methods
       
        #endregion
    }
}
