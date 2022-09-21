using FFF.Ex1.DAL.Models;
using Microsoft.AspNetCore.Http;

namespace FFF.Ex1.Logging
{
    /// <inheritdoc/>
    /// 
    public class DbAuditLogger : IDbAuditLogger
    {
        private readonly ServiceDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbAuditLogger(ServiceDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc/>
        /// 
        public async Task LogQueryActionAsync(string queryAction, CancellationToken cancellationToken)
        {
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;

            await _context.QueryLogActions.AddAsync(new QueryLogAction
            {
                ActionDate = DateTime.UtcNow,
                Action = queryAction,
                UserIp = ip.ToString(),
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        /// 
        public async Task LogServiceActionAsync(string answerAction, CancellationToken cancellationToken)
        {
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;

            await _context.ServiceLogActions.AddAsync(new ServiceLogAction
            {
                ActionDate = DateTime.UtcNow,
                Action = answerAction,
                UserIp = ip.ToString()
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
