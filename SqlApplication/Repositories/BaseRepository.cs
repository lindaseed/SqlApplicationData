﻿using SqlApplication.Context;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SqlApplication.Repositories;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected BaseRepository(DataContext context)
    {
        _context = context;
    }


    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.Write("ERROR :: " + ex.Message); }
        return null!;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            var result = _context.Set<TEntity>().ToList();
            if(result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.Write("ERROR :: " + ex.Message); }
        return null!;
    }

    public virtual TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.Write("ERROR :: " + ex.Message); }
        return null!;
    }


    //public TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    //{
    //    var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
    //    _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
    //    return entityToUpdate!;
    //}
    public virtual TEntity Update(TEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Set<TEntity>().Find(entity);
            if (entityToUpdate != null)
            {
                entityToUpdate = entity;
                _context.Set<TEntity>().Update(entityToUpdate);
                _context.SaveChanges();

                return entityToUpdate;
            }
        }
        catch (Exception ex) { Debug.Write("ERROR :: " + ex.Message); }
        return null!;
    }


    public virtual bool Delete(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();

                return true;
            }
        }
        catch (Exception ex) { Debug.Write("ERROR :: " + ex.Message); }
        return false;
    }

    public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = _context.Set<TEntity>().Any(predicate);
            return result;
        }
        catch (Exception ex) { Debug.Write("ERROR :: " + ex.Message); }
        return false;
    }
}
