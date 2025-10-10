namespace fisioClin.Models
{
    public class Cargo_Funcionario
    {
        public int Id { get; set; }

        public int Id_Cargo_fk {  get; set; }

        public int Id_Funcionario_fk { get; set; }
    }
}
