using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiModuloFinal.Model
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get;  set; }
        public string CPF { get;  set; }
        public string email { get;  set; }
        public string Telefone { get;  set; }
        public string Logradouro { get;  set; }
        public string Cidade { get;  set; }
        public string CEP {  get;  set; }
        public string UF { get;  set; }

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
