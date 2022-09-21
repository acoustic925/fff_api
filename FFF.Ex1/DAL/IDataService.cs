using FFF.Ex1.DAL.Models;
using System.Threading;

namespace FFF.Ex1.DAL
{
    /// <summary>
    /// Сервис для работы с данными Datum
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Подсчитывает количество записей в таблице [data]
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CountDataAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет пакет данных в БД
        /// </summary>
        /// <param name="dataBatch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> InputDataBatchAsync(IEnumerable<Datum> dataBatch, CancellationToken cancellationToken);

        /// <summary>
        /// Получает страницу данных из БД
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<Datum>> GetDataPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
