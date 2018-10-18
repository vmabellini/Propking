using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Propking.Api.Models;
using System.Data;
using System.Threading.Tasks;

namespace Propking.Api.Data
{
    public class SystemContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {

        }

        public DbSet<Fii> Fiis { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionChange> PositionChanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fii>().ToTable("Fii");
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<PositionChange>().ToTable("PositionChange");
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
