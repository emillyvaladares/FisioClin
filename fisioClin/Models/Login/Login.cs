namespace fisioClin.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdFuncionario { get; set; }
    }
}
