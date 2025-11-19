namespace fisioClin.Models
{
    public class Prontuario
    {
        public int Id { get; set; }

        public DateTime? Data { get; set; }

        public string Alergia { get; set; }

        public string Comorbidade { get; set; }

        public string Doenca { get; set; }

        public string Hostorico { get; set; }

        public string Habito { get; set; }

        public string Avaliacao { get; set; }

        public int Id_Paciente_Fk {  get; set; }
    }
}
