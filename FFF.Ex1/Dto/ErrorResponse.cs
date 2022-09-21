using System.ComponentModel.DataAnnotations;

namespace FFF.Ex1.Dto
{
    /// <summary>
    /// Ответ сервиса в случае ошибки выполнения запроса
    /// </summary>

    public class ErrorResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ErrorResponse(int code, string message = null, string data = null)
        {
            Error = new ErrorResponseInfo()
            {
                Code = code,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// 
        /// </summary>
        public ErrorResponse()
        {

        }

        /// <summary>
        /// Информация об ошибке
        /// </summary>
        public ErrorResponseInfo Error { get; set; }

    }

    /// <summary>
    /// Подробная информация об ошибке
    /// </summary>
    public class ErrorResponseInfo
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        [Required]
        public int Code { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// Дополнительная информация об ошибке в строковом представлении
        /// </summary>
        public string Data { get; set; }
    }

}
