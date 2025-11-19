namespace fisioClin.Models
{
    public class Cargo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Departamento { get; set; }

        public string Descricao { get; set; }

        public int Carga { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public string Observacao { get; set; }
    }
}
