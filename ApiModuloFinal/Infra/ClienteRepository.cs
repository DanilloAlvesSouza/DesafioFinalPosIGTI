using ApiModuloFinal.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace ApiModuloFinal.Infra
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        private readonly ILogger<ClienteRepository> _logger;

        public void Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }
        public void Count()
        {
            throw new NotImplementedException();
        }

        public void Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Delete(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetByID(int id)
        {
            try
            {
                var cliente = _context.Clientes.Find(id);

                if (cliente is null) throw new KeyNotFoundException("Cliente Não encontrado");

                return cliente;

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Erro ao acessar o banco de dados.");
                throw new Exception("Falha ao buscar cliente. Tente novamente.");
            }
        }

        public Cliente GetByName(string nome)
        {
            return _context.Clientes.Find(nome);
        }

    }
}
