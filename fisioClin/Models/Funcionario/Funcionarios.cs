using System;
using System.ComponentModel.DataAnnotations;

namespace fisioClin.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }

        // NOME
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(200, ErrorMessage = "O nome pode ter no máximo 200 caracteres.")]
        public string Nome { get; set; }

        // CPF
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14, ErrorMessage = "O CPF deve ter 14 caracteres (incluindo pontuação).")]
        public string Cpf { get; set; }

        // RG
        [StringLength(20, ErrorMessage = "O RG pode ter no máximo 20 caracteres.")]
        public string Rg { get; set; }

        // DATA DE NASCIMENTO
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime? DataNascimento { get; set; }

        // TELEFONE
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(20, ErrorMessage = "O telefone pode ter no máximo 20 caracteres.")]
        public string Telefone { get; set; }

        // EMAIL
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(200, ErrorMessage = "O e-mail pode ter no máximo 200 caracteres.")]
        public string Email { get; set; }

        // TIPO DE VÍNCULO
        [Required(ErrorMessage = "O tipo de vínculo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tipo de vínculo pode ter no máximo 100 caracteres.")]
        public string TipoVinculo { get; set; }

        // REGISTRO PROFISSIONAL
        [StringLength(200, ErrorMessage = "O registro profissional pode ter no máximo 200 caracteres.")]
        public string RegistroProfissional { get; set; }

        // ESPECIALIDADE
        [StringLength(200, ErrorMessage = "A especialidade pode ter no máximo 200 caracteres.")]
        public string Especialidade { get; set; }

        // SUBESPECIALIDADE
        [StringLength(200, ErrorMessage = "A subespecialidade pode ter no máximo 200 caracteres.")]
        public string Subespecialidade { get; set; }

        // CERTIFICADOS
        [StringLength(200, ErrorMessage = "Os certificados podem ter no máximo 200 caracteres.")]
        public string Certificados { get; set; }

        // DATA DE CONTRATAÇÃO
        [Required(ErrorMessage = "A data de contratação é obrigatória.")]
        public DateTime? DataContratacao { get; set; }

        // FK PARA CARGO
        [Required(ErrorMessage = "O cargo é obrigatório.")]
        public int? Id_Cargo_fk { get; set; }
    }
}
