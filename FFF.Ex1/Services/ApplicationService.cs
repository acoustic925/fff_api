using FFF.Ex1.DAL;
using FFF.Ex1.DAL.Models;
using FFF.Ex1.Dto;
using FFF.Ex1.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FFF.Ex1.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IDataService _dataService;
        private readonly IDbAuditLogger _dbLogger;

        public ApplicationService(IDataService dataService, IDbAuditLogger dbLogger)
        {
            _dataService = dataService;
            _dbLogger = dbLogger;
        }

        /// <inheritdoc/>
        /// 
        public async Task<(int Total, IEnumerable<DataDto> Data)> GetDataAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var data = await _dataService.GetDataPageAsync(pageNumber, pageSize, cancellationToken);
            var count = await _dataService.CountDataAsync(cancellationToken);

            var result = data.Select(x => new DataDto
            {
                Id = x.Id,
                Code = x.Code.Value,
                Value = x.Value
            });

            await LogServiceActionAsync(result, cancellationToken);

            return (count, result);
        }

        /// <inheritdoc/>
        /// 
        public async Task<int> InputDataBatchAsync(IEnumerable<InputDataDto> batchData, CancellationToken cancellationToken)
        {
            await LogQueryActionAsync(batchData, cancellationToken);

            var datums = batchData.OrderBy(x => x.Code).Select(x => new Datum { Code = x.Code, Value = x.Value });
            return await _dataService.InputDataBatchAsync(datums, cancellationToken);
        }

        private async Task LogQueryActionAsync(IEnumerable<InputDataDto> batchData, CancellationToken cancellationToken)
        {
            var queryAction = JsonSerializer.Serialize(batchData);

            await _dbLogger.LogQueryActionAsync(queryAction, cancellationToken);
        }

        private async Task LogServiceActionAsync(IEnumerable<DataDto> result, CancellationToken cancellationToken)
        {
            var serviceAction = JsonSerializer.Serialize(result);

            await _dbLogger.LogServiceActionAsync(serviceAction, cancellationToken);
        }
    }
}
