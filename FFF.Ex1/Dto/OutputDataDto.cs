using System.Collections.Generic;

namespace FFF.Ex1.Dto
{
    /// <summary>
    /// Ответ сервиса
    /// </summary>
    public class OutputDataDto
    {

        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Общее количество элементов в таблице
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Данные
        /// </summary>
        public IEnumerable<DataDto> Data { get; set; }
    }

    /// <summary>
    /// Модель данных ответа сервиса
    /// </summary>
    public class DataDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }
    }
}
