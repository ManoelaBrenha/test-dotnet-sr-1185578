using System;
using System.Collections.Generic;
using System.Linq;
using ApplicantTracking.Infrastructure.Database.Context;
using ApplicantTracking.Infrastructure.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApplicantTracking.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
    {
        protected readonly ApplicantTrackingDbContext _context;
        private readonly SqlConnection Connection;
        public BaseRepository(ApplicantTrackingDbContext applicantTrackingDbContext, IConfiguration configuration) {
            _context = applicantTrackingDbContext;
            Connection = new SqlConnection(configuration.GetConnectionString("ApplicantTrackingDb"));
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Add(T obj)
        {

            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public virtual void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public virtual void Edit(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public void Dispose()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
                Connection.Dispose();
            }
            GC.SuppressFinalize(this);
        }

    }
}
