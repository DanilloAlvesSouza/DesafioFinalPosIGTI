namespace ApiModuloFinal.Model
{
    public interface IClienteRepository
    {
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
        void Count();
        List<Cliente> GetAll();
        Cliente GetByID(int id);
        Cliente GetByName(string name);
    }
}
