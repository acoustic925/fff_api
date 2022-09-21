namespace FFF.Ex1.Logging
{
    /// <summary>
    /// Сервис для записи запросов к сервису и ответов сервиса
    /// </summary>
    public interface IDbAuditLogger
    {
        /// <summary>
        /// Записывает запрос к сервису в базу данных
        /// </summary>
        /// <param name="queryAction"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task LogQueryActionAsync(string queryAction, CancellationToken cancellationToken);

        /// <summary>
        /// Записывает ответ сервиса в базу данных
        /// </summary>
        /// <param name="answerAction"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task LogServiceActionAsync(string answerAction, CancellationToken cancellationToken);
    }
}
