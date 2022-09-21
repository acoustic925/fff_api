using FFF.Ex1.Dto;

namespace FFF.Ex1.Services
{
    /// <summary>
    /// Сервис для инкапсуляции БЛ
    /// </summary>
    public interface IApplicationService
    {
        /// <summary>
        /// Добавляет пакет данных
        /// </summary>
        /// <param name="batchData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> InputDataBatchAsync(IEnumerable<InputDataDto> batchData, CancellationToken cancellationToken);

        /// <summary>
        /// Получает данные
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<(int Total, IEnumerable<DataDto> Data)> GetDataAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
