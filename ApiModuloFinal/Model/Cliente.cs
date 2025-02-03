using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiModuloFinal.Model
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string email { get; private set; }
        public string Telefone { get; private set; }
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string CEP {  get; private set; }
        public string UF { get; private set; }

        public Cliente(string nome, string CPF, string email, string telefone, string logradouro, string cidade, string CEP, string UF )
        {
            this.Nome = nome ?? throw new ArgumentNullException( nameof( nome ) );
            this.CPF = CPF;
            this.email = email;
            this.Telefone = telefone;
            this.Logradouro = logradouro;
            this.Cidade = cidade;
            this.CEP = CEP;
            this.UF = UF;
        }
    }
}
