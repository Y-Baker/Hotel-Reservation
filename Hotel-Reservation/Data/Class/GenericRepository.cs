using System;
using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Data.Class;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly HotelContext db;
    protected DbSet<TEntity> dbset;

    public GenericRepository(HotelContext _db)
    {
        this.db = _db;
        this.dbset = db.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await dbset.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetById(int id)
    {
        return await dbset.FindAsync(id);
    }
    public async Task<TEntity?> GetById(string id)
    {
        return await dbset.FindAsync(id);
    }

    public async Task Add(TEntity entity)
    {
        await dbset.AddAsync(entity);
    }

    public async Task Update(TEntity entity)
    {
        dbset.Entry(entity).State = EntityState.Modified;
        await db.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
        dbset.Remove(entity);
        await db.SaveChangesAsync();
    }
}