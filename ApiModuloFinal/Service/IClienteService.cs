using ApiModuloFinal.Model;

namespace ApiModuloFinal.Service
{
    public interface IClienteService
    {
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
        int Count();
        List<Cliente> GetAll();
        Cliente GetByID(int id);
        List<Cliente> GetByName(string name);
    }
}
