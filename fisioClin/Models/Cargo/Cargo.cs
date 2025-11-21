using System.ComponentModel.DataAnnotations;

namespace fisioClin.Models
{
    public class Cargo
    {
        public int Id { get; set; }

        // NOME ------------------------------------------
        [Required(ErrorMessage = "O nome do cargo é obrigatório")]
        [StringLength(200, ErrorMessage = "O nome pode ter no máximo 200 caracteres")]
        [CustomValidation(typeof(Cargo), nameof(ValidarNomeCargo))]
        public string Nome { get; set; } = "";

        // DEPARTAMENTO ----------------------------------
        [Required(ErrorMessage = "O departamento do cargo é obrigatório")]
        [StringLength(200, ErrorMessage = "O departamento pode ter no máximo 200 caracteres")]
        public string Departamento { get; set; } = "";

        // CARGA HORÁRIA ---------------------------------
        [Required(ErrorMessage = "A carga horária é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "A carga horária deve ser um número válido")]
        public int Carga { get; set; }

        // DATAS -----------------------------------------
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        // OBSERVAÇÃO ------------------------------------
        [StringLength(200, ErrorMessage = "A observação pode ter no máximo 200 caracteres")]
        public string Observacao { get; set; } = "";

        // DESCRIÇÃO -------------------------------------
        [StringLength(300, ErrorMessage = "A descrição pode ter no máximo 300 caracteres")]
        public string Descricao { get; set; } = "";

        // ============================================================
        // VALIDADORES PERSONALIZADOS
        // ============================================================

        // Validador de Nome (não permite duplicidade)
        public static ValidationResult ValidarNomeCargo(string? nome, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return new ValidationResult("O nome do cargo é obrigatório");

            var dao = (CargoDAO)context.GetService(typeof(CargoDAO))!;

            if (dao.VerificarNomeExistente(nome))
                return new ValidationResult("Já existe um cargo cadastrado com esse nome");

            return ValidationResult.Success!;
        }
    }
}
