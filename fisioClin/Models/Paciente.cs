namespace fisioClin.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public int Id_end_fk { get; set; }
    }
}
