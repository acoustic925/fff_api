using FFF.Ex1.DAL.Models;

namespace FFF.Ex1.DAL
{
    /// <inheritdoc/>
    /// 
    public class DataService : IDataService
    {
        private readonly ServiceDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public DataService(ServiceDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        /// 
        public async Task<int> CountDataAsync(CancellationToken cancellationToken) => 
            await _context.Data.CountAsync(cancellationToken);

        /// <inheritdoc/>
        /// 
        public async Task<IEnumerable<Datum>> GetDataPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Data
                .AsNoTracking()
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        /// 
        public async Task<int> InputDataBatchAsync(IEnumerable<Datum> dataBatch, CancellationToken cancellationToken)
        {
            await ClearDataTable();

            await _context.AddRangeAsync(dataBatch, cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task ClearDataTable() => 
            await _context.Database.ExecuteSqlRawAsync("truncate table [fffdb].[dbo].[data]");
        
    }
}
