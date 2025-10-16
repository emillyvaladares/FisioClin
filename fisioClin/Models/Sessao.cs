namespace fisioClin.Models
{
    public class Sessao
    {
        public int Id { get; set; }

        public DateTime? Data { get; set; }

        public string Horario { get; set; }

        public string Tipo { get; set; }

        public string Observacao { get; set; }

        public int Id_Funcionario_fk { get; set; }

        public int Id_Paciente_fk {  get; set; }
    }
}
