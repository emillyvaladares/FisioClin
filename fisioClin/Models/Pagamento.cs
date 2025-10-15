namespace fisioClin.Models
{
    public class Pagamento
    {
        public int Id { get; set; }

        public string DataPagamento { get; set; }

        public string NumeroParcelas { get; set; }

        public string ValorPagamento { get; set; }

        public string FormaPagamento { get; set; }

        public string Status { get; set; }

        public string Observacao { get; set; }

        public int IdPacienteFk { get; set; }  // FK para o paciente
    }
}
