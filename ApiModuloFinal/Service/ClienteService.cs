using ApiModuloFinal.Model;
using ApiModuloFinal.Repository;
using Microsoft.Data.SqlClient;

namespace ApiModuloFinal.Service
{
    public class ClienteService : IClienteService
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        private readonly ILogger<ClienteService> _logger;

        public void Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }
        public int Count()
        {
            return _context.Clientes.Count();
        }

        public void Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

            var cliente = GetByID(id);
            _context.Clientes.Remove(cliente);
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

        public List<Cliente> GetByName(string nome)
        {
            return _context.Clientes
                           .Where(c => c.Nome.Contains(nome))
                           .ToList();
        }

}
}
