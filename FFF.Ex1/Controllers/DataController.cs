using FFF.Ex1.Dto;
using FFF.Ex1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace FFF.Ex1.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : Controller
    {
        private readonly IApplicationService _service;

        public DataController(IApplicationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Добавляет данные
        /// </summary>
        /// <param name="dataBatch">Данные</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("input-data")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> InputBatchDataAsync([FromBody] IEnumerable<InputDataDto> dataBatch, CancellationToken cancellationToken)
        {
            try
            {
                var rows = await _service.InputDataBatchAsync(dataBatch, cancellationToken);

                return Ok(rows);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse((int)HttpStatusCode.InternalServerError, ex.Message));
            }         
        }

        /// <summary>
        /// Постранично читает данные
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="size">Размер страницы</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-data")]
        [ProducesResponseType(typeof(OutputDataDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetDataAsync([FromQuery] int page, [FromQuery] int size, CancellationToken cancellationToken)
        {
            try
            {
                var (total, data) = await _service.GetDataAsync(page, size, cancellationToken);

                return Ok(new OutputDataDto { Total = total, Data = data, Page = page });
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse((int)HttpStatusCode.InternalServerError, ex.Message) );
            }           
        }
    }
}
