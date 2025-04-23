using BalanceFlow.Application.UnitOfWork;
using BalanceFlow.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BalanceFlow.Controllers
{
    [ApiController]
    [Route("api/v1/cashEntry")]
    public class CashEntryController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public CashEntryController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CashEntryEntity entry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _serviceUoW.CashEntryService.Add(entry);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CashEntryEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var entries = await _serviceUoW.CashEntryService.Get();
            return Ok(entries);
        }
    }
}