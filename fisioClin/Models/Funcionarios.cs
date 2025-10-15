namespace fisioClin.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string TipoVinculo { get; set; }

        public string Senha { get; set; }

        public string Rg { get; set; }

        public string Especialidade { get; set; }

        public string Subespecialidade { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Registro { get; set; }

        public string Certificados { get; set; }

        public DateTime? DataNascimento { get; set; }

        public DateTime? DataContratacao { get; set; }
    }
}
