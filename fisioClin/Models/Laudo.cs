namespace fisioClin.Models
{
    public class Laudo
    {
        public int Id { get; set; }

        public string Validade { get; set; }

        public string Exame { get; set; }

        public string Diagnostico { get; set; }

        public string Observacao { get; set; }

        public string Status { get; set; }

        public int Id_paciente_fk { get; set; }
    }
}
