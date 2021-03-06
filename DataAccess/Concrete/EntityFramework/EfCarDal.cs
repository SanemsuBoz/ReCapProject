﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapDemoDatabaseContext context = new ReCapDemoDatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDemoDatabaseContext context = new ReCapDemoDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDemoDatabaseContext context = new ReCapDemoDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDemoDatabaseContext context = new ReCapDemoDatabaseContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetById(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetCarsByBrandId(Expression<Func<Car, int>> filter = null)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetCarsByColorId(Expression<Func<Car, int>> filter = null)
        {
            throw new NotImplementedException();
        }
        public void Update(Car entity)
        {
            using (ReCapDemoDatabaseContext context = new ReCapDemoDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
