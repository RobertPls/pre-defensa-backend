using Application.UseCase.Command.Empleados.AccesoDenegado;
using Application.UseCase.Command.Empleados.Ausencia;
using Application.UseCase.Command.Empleados.CrearEmpleado;
using Application.UseCase.Command.Empleados.Sobrecarga;
using Application.UseCase.Query.Accounts.GetAccountListByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ILogger<EmpleadoController> _logger;
        private readonly IMediator _mediator;

        public EmpleadoController(IMediator mediator, ILogger<EmpleadoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearEmpleado([FromBody] CrearEmpleadoCommand command)
        {

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(new
                {
                    result
                });
            }
            else
            {
                _logger.LogError("Error al crear el empleado");
                return BadRequest(new { result });
            }
        }

        [Route("acceso")]
        [HttpPost]
        public async Task<IActionResult> AccesoDenegado([FromBody] AccesoDenegadoCommand command)
        {

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(new
                {
                    result
                });
            }
            else
            {
                _logger.LogError("Error al procesar el acceso denegado del empleado");
                return BadRequest(new { result });
            }
        }

        [Route("sobrecarga")]
        [HttpPost]
        public async Task<IActionResult> Sobrecarga([FromBody] SobrecargaCommand command)
        {

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(new
                {
                    result
                });
            }
            else
            {
                _logger.LogError("Error al procesar la sobrecarga del empleado");
                return BadRequest(new { result });
            }
        }

        [Route("ausencia")]
        [HttpPost]
        public async Task<IActionResult> Ausencia([FromBody] AusenciaCommand command)
        {

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(new
                {
                    result
                });
            }
            else
            {
                _logger.LogError("Error al procesar la ausencia del empleado");
                return BadRequest(new { result });
            }
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> ListaEmpleados()
        {

            var query = new GetListaEmpleadoQuery();
            var result = await _mediator.Send(query);

            if (result.Success)
            {
                return Ok(new
                {
                    success = result.Success,
                    data = result.Value!.ToList(),
                });
            }
            else
            {
                _logger.LogError("Error al cargar lista de empleados.");
                return BadRequest(result);
            }
        }
    }
}