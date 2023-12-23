// Repository Design Pattern = data access, handle operation with DB
// Unit of Work ~ Transaction
// epository is class for entity with all database operations
using System.Linq;

namespace Patterns
{
    // Interfaces
    public interface ITransaction : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
    public interface IDatabase
    {
        Task<ITransaction> BeginTransactionAsync();
    }
    public interface IStore : IDatabase
    {
        IQueryable<Tentity> GetSet<Tentity>() where Tentity : Entity;
        void Add(Tentity newOrder) where Tentity :Entity;
    }
    public interface IOrderRepository
    {
        void Add(Order order);
    }
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
    }

    // Abstract Class
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }

    // Class
    public class Order : Entity
    {
    }
    // we do not start, commit transaction inside repository
    public class OrderRepository : IOrderRepository
    {
        private readonly IStore _dbcontext;

        public OrderRepository(IStore database)
        {
            _dbcontext = database;
        }
        public void Add(Order order)
        {
            _dbcontext.Add(order);
        }
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabase _dbcontext;
        private ITransaction? _currentTransaction;

        public UnitOfWork(IDatabase database)
        {
            _dbcontext = database;
        }
        // called at the start of each operation, only once.
        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction is not null)
                throw new InvalidOperationException("There is already a transaction!");
            
            _currentTransaction = await _dbcontext.BeginTransactionAsync();
        }
        public async Task CommitAsync()
        {
            if (_currentTransaction is null)
                throw new InvalidOperationException("There is no transaction to commit!");

            try
            {
                await _currentTransaction.CommitAsync();

                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
            catch (Exception)
            {
                if (_currentTransaction is not null)
                    await _currentTransaction.RollbackAsync(); //  write code defensively.
                throw;
            }
        }
    }

    // Dummy Implementation
    public class Transaction : ITransaction
    {
        public Task CommitAsync() => Task.CompletedTask;
        public Task RollbackAsync() => Task.CompletedTask;

        public void Dispose()
        {}
    }
    public class DummyStoreDB : IStore
    {
        private readonly List<Order> _orders = new List<Order>();
        
        public IQueryable<Tentity> GetSet<Tentity>()
            where Tentity : Entity =>
                _orders.AsQueryable() as IQueryable<Tentity>;
        
        public Task<ITransaction> BeginTransactionAsync()
        {
            return Task.FromResult(new Transaction() as ITransaction);
        }
        
        public void Add<Tentity>(Tentity order) where Tentity : Entity
        {
            _orders.Add(order as Order);
        }
    }
}