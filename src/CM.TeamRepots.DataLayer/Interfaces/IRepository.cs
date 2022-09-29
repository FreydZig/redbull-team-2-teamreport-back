﻿namespace CM.TeamRepots.DataLayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);

        TEntity Read(int entityCode);

        void Update(TEntity entity);

        void Delete(int entityCode);

        List<TEntity> GetAll(int entityCode);
    }
}
