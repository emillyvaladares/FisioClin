namespace fisioClin.Models
{
    public class Login
    {
        public int Id { get; set; }

        public int Id_Paciente_fk { get; set; }
        
        public int Id_Funcionario_fk { get; set; }
    }
}
