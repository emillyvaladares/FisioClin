using System.ComponentModel.DataAnnotations;

// isso é importante

// nao precisa fazer isso pra todos os models
//apenas para aqueles que forem ser usados em forms
//esse monte de codigo são as validações do formulario
namespace fisioClin.Models
{
    public class Paciente
    {

        public int Id { get; set; }

        // NOME ------------------------------------------
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(200, ErrorMessage = "O nome pode ter no máximo 200 caracteres")]
        public string Nome { get; set; } = "";

        // CPF -------------------------------------------
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [CustomValidation(typeof(Paciente), nameof(ValidarCpf))]
        public string Cpf { get; set; } = "";

        // CEP -------------------------------------------
        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage = "CEP inválido")]
        public string Cep { get; set; } = "";

        // RG --------------------------------------------
        [Required(ErrorMessage = "O RG é obrigatório")]
        public string Rg { get; set; } = "";

        // BAIRRO ----------------------------------------
        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; } = "";

        // DATA NASCIMENTO -------------------------------
        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [CustomValidation(typeof(Paciente), nameof(ValidarDataNascimento))]
        public DateTime? DataNascimento { get; set; }

        // RUA -------------------------------------------
        [Required(ErrorMessage = "A rua é obrigatória")]
        public string Rua { get; set; } = "";

        // NÚMERO ----------------------------------------
        [Required(ErrorMessage = "O número é obrigatório")]
        public string Numero { get; set; } = "";

        // SEXO ------------------------------------------
        [Required(ErrorMessage = "O sexo é obrigatório")]
        public string Sexo { get; set; } = "";

        // EMAIL -----------------------------------------
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = "";

        // TELEFONE --------------------------------------
        [Required(ErrorMessage = "O telefone é obrigatório")]
        [RegularExpression(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; } = "";

        // ============================================================
        // VALIDADORES PERSONALIZADOS
        // ============================================================

        // Validador CPF
        public static ValidationResult ValidarCpf(string? cpf, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return new ValidationResult("O CPF é obrigatório");

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
                return new ValidationResult("CPF inválido");

            // CPFs iguais (000.000.000.00 etc)
            if (cpf.Distinct().Count() == 1)
                return new ValidationResult("CPF inválido");

            return ValidationResult.Success!;
        }

        // Validador de Data de Nascimento
        public static ValidationResult ValidarDataNascimento(DateTime? data, ValidationContext context)
        {
            if (data == null)
                return new ValidationResult("A data de nascimento é obrigatória");

            if (data > DateTime.Today)
                return new ValidationResult("A data não pode ser futura");

            if (data < new DateTime(1900, 1, 1))
                return new ValidationResult("Data de nascimento muito antiga");

            return ValidationResult.Success!;
        }

       
    }
}
