using ApiModuloFinal.Model;
using ApiModuloFinal.Service;
using ApiModuloFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiModuloFinal.Controllers
{
    [ApiController]
    [Route("api/v1/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteRepository)
        {
            _clienteService = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        [HttpGet("buscar-todos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClienteViewModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetAll()
        {
            var cliente = _clienteService.GetAll();

            return Ok(cliente);
        }

        [HttpGet("buscar-por-id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByiD(int id)
        {
            var cliente = _clienteService.GetByID(id);
            if (cliente == null)
                return NotFound(new { mensagem = "Cliente não encontrado." });

            return Ok(cliente);

        }

        [HttpGet("contagem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Contagem()
        {
            var contagem = _clienteService.Count();
            return Ok(contagem);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClienteViewModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Add(ClienteViewModel clienteView)
        {
            var cliente = new Cliente(clienteView.Nome, clienteView.CPF, clienteView.email, clienteView.Telefone,
                                      clienteView.Logradouro, clienteView.Cidade, clienteView.CEP, clienteView.UF);

            _clienteService.Create(cliente);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClienteViewModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteService.GetByID(id);
            
            if (cliente == null)
                return NotFound(new { mensagem = "Cliente não encontrado." });

            _clienteService.Delete(id);
            return Ok();

        }

    }
}
