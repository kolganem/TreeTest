﻿namespace StoreProject.Infrastructure;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(Guid id);
    Task Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}