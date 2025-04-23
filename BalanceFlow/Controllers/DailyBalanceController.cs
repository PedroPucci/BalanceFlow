using BalanceFlow.Application.UnitOfWork;
using BalanceFlow.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BalanceFlow.Controllers
{
    [ApiController]
    [Route("api/v1/dailyBalance")]
    public class DailyBalanceController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public DailyBalanceController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DailyBalanceEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var list = await _serviceUoW.DailyBalanceService.Get();
            return Ok(list);
        }
    }
}