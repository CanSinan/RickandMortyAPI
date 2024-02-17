using Microsoft.EntityFrameworkCore;
using RickAndMorty.Data.Contexts;
using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        //private RickAndMortyDbContext _dbContext;
        //private DbSet<T> _table;
        //public GenericRepository(RickAndMortyDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    _table = dbContext.Set<T>();
        //}

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await _table.ToListAsync();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await _table.FirstOrDefaultAsync(x =>x.Id== id);
        //}

        //public async Task<T> CreateAsync(T entity)
        //{
        //    await _table.AddAsync(entity);
        //    return entity;
        //}

        
        //public async Task<T> UpdateAsync(T entity)
        //{
        //    var entry = _dbContext.Entry(entity);

        //    if (entry.State == EntityState.Detached)
        //    {
        //        var oldEntity = await _table.FindAsync(entity.Id);

        //        if (oldEntity != null)
        //        {
        //            var properties = typeof(T).GetProperties();

        //            foreach (var property in properties)
        //            {
        //                if (property.CanWrite && property.CanRead)
        //                {
        //                    var newValue = property.GetValue(entity, null);
        //                    var oldValue = property.GetValue(oldEntity, null);

        //                    if ((newValue != null && oldValue == null) || (newValue != null && !newValue.Equals(oldValue)))
        //                    {
        //                        _dbContext.Entry(oldEntity).Property(property.Name).IsModified = true;
        //                        _dbContext.Entry(oldEntity).Property(property.Name).CurrentValue = newValue;
        //                    }
        //                }
        //            }

        //            entity = oldEntity;
        //        }
        //        else
        //        {
        //            // Eğer veri bulunamazsa, yeni bir veri ekleniyor.
        //            _table.Add(entity);
        //        }
        //    }
        //    else if (entry.State == EntityState.Modified)
        //    {
        //        // EntityState.Modified durumundaysa, SaveChangesAsync() metodunu çağırmadan önce özelliği manuel olarak güncelle
        //        entry.Property("UpdateDate").CurrentValue = DateTime.Now;
        //    }

        //    await _dbContext.SaveChangesAsync();

        //    return entity;
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    T entity = await _table.FirstOrDefaultAsync(x => x.Id == id);
        //    _dbContext.Remove(entity);
        //    return true;
        //}

        //public async Task SaveAsync()
        //{
        //    await _dbContext.SaveChangesAsync();
        //}
    }
}
