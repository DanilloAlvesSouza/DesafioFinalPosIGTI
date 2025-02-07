using ApiModuloFinal.Model;
using ApiModuloFinal.Service;
using ApiModuloFinal.DTO;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClienteDTO>))]
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
        [HttpGet("buscar-por-nome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByName(string name)
        {
            var cliente = _clienteService.GetByName(name);
            if (cliente is null || cliente is [])
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClienteDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult Add(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente(clienteDTO.Nome, clienteDTO.CPF, clienteDTO.email, clienteDTO.Telefone,
                                      clienteDTO.Logradouro, clienteDTO.Cidade, clienteDTO.CEP, clienteDTO.UF);

            _clienteService.Create(cliente);

            return Ok();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(List<ClienteDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (id <= 0)
                return BadRequest(new { mensagem = "ID inválido." });

            var clienteExistente = _clienteService.GetByID(id);
            if (clienteExistente == null)
                return NotFound(new { mensagem = "Cliente não encontrado." });

            // Atualiza os campos do cliente existente
            clienteExistente.Nome = clienteDto.Nome;
            clienteExistente.email = clienteDto.email;
            clienteExistente.Telefone = clienteDto.Telefone;
            clienteExistente.CEP = clienteDto.CEP;
            clienteExistente.UF = clienteDto.UF;
            clienteExistente.CPF = clienteDto.CPF;
            clienteExistente.Logradouro = clienteDto.Logradouro;
            clienteExistente.Cidade = clienteDto.Cidade;

            _clienteService.Update(clienteExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClienteDTO>))]
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
