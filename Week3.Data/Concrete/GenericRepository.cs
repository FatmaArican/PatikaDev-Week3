﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Abstract;
using Week3.Data.Context;
using Week3.Domain;

namespace Week3.Data.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly Week3DbContext _Context;
        private readonly DbSet<TEntity> _Entity;


        public GenericRepository(Week3DbContext context)
        {
            _Context = context;
            _Entity = _Context.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return _Entity.Where(x => !x.IsDeleted).ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return _Entity.Where(expression).ToList();
        }

        public TEntity GetById(int id)
        {
            return _Entity.FirstOrDefault(x => x.Id == id);
        }

        public TEntity Add(TEntity entity)
        {
            entity.IsDeleted = false;
            _Entity.Add(entity);
            _Context.SaveChanges();
            return entity;
        }


        public TEntity Update(TEntity entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            _Context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var data = _Entity.Find(id);

            if (data != null)
            {
                data.IsDeleted = true;

                Update(data);
                return true;
            }
            return false;
        }
    }
}
