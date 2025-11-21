namespace fisioClin.Models
{
    public class Agenda
    {
        public int Id { get; set; }

        public DateTime? Data { get; set; }

        public DateTime? Horario { get; set; }

        public int Id_Sala_fk {  get; set; }

        public int Id_Funcionario_fk { get; set; }

        public int Id_Sessao_fk { get; set; }

        public int Id_Paciente_fk { get; set; }

        public string Observacao { get; set; }
    }
}
