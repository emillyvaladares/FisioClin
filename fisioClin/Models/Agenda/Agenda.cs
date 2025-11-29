using System.ComponentModel.DataAnnotations;

namespace fisioClin.Models
{
    public class Agenda
    {
        public int Id { get; set; }

        // DATA
        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime? Data { get; set; }

        // HORÁRIO
        [Required(ErrorMessage = "O horário é obrigatório.")]      
        public string Horario { get; set; }

        // OBSERVAÇÃO
        [StringLength(200, ErrorMessage = "A observação pode ter no máximo 200 caracteres.")]
        public string Observacao { get; set; }

        // FOREIGN KEYS
        [Required(ErrorMessage = "A sala é obrigatória.")]
        public int? Id_Sala_fk { get; set; }

        [Required(ErrorMessage = "O funcionário é obrigatório.")]
        public int? Id_Funcionario_fk { get; set; }

        [Required(ErrorMessage = "O paciente é obrigatório.")]
        public int? Id_Paciente_fk { get; set; }

        [Required(ErrorMessage = "O tipo de atendimento é obrigatório.")]
        public int? Id_Tipo_fk { get; set; }

        // Objetos carregados manualmente
        public Sala Sala { get; set; }
        public Funcionarios Funcionario { get; set; }
        public Paciente Paciente { get; set; }
        public Tipo Tipo { get; set; }
    }
}
