namespace fisioClin.Models 
{
         public class Agenda
        {
            public int Id { get; set; }
            public DateTime? Data { get; set; }
            public string Horario { get; set; }
            public int Id_Sala_fk { get; set; }
            public int Id_Funcionario_fk { get; set; }
            public string Observacao { get; set; }

            // Não mapeado no Banco → preenchido manualmente
            public Sala Sala { get; set; }
            public Funcionarios Funcionario { get; set; }
         }    
}

