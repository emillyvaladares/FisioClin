using fisioClin.Configs;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace fisioClin.Models
{
    public class FuncionariosDAO
    {
        private readonly Conexao _conexao;

        public FuncionariosDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Funcionarios> ListarTodos()
        {
            var lista = new List<Funcionarios>();

            var comando = _conexao.CreateCommand("SELECT * FROM funcionarios;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var funcionario = new Funcionarios();
                funcionario.Id = leitor.GetInt32("id_funcionario");
                funcionario.Nome = DAOHelper.GetString(leitor, "nome_func");
                funcionario.Cpf = DAOHelper.GetString(leitor, "cpf_func");
                

                lista.Add(funcionario);
            }
           
            leitor.Close();
            return lista;
        }

        // ✅ INSERIR
        public void Inserir(Funcionarios f)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    INSERT INTO funcionarios 
                    (nome_func, cpf_func, rg_func, email_func, data_nascimento_func, especialidade_func, 
                     registro_profissional_func, data_contratacao_func, tipo_vinculo_func, certificados_func, telefone_func, senha_func)
                    VALUES 
                    (@nome, @cpf, @rg, @email, @dataNasc, @especialidade, @registro, 
                     @dataContratacao, @tipoVinculo, @certificados, @telefone, @senha);
                ");

                comando.Parameters.AddWithValue("@nome", f.Nome);
                comando.Parameters.AddWithValue("@cpf", f.Cpf);
                comando.Parameters.AddWithValue("@rg", f.Rg);
                comando.Parameters.AddWithValue("@email", f.Email);
                comando.Parameters.AddWithValue("@dataNasc", f.DataNascimento);
                comando.Parameters.AddWithValue("@especialidade", f.Especialidade);
                comando.Parameters.AddWithValue("@registro", f.Registro);
                comando.Parameters.AddWithValue("@dataContratacao", f.DataContratacao);
                comando.Parameters.AddWithValue("@TipoVinculo", f.TipoVinculo);
                comando.Parameters.AddWithValue("@certificados", f.Certificados);
                comando.Parameters.AddWithValue("@telefone", f.Telefone);
                comando.Parameters.AddWithValue("@senha", f.Senha);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir funcionário: " + ex.Message);
            }
        }

        // ✅ BUSCAR POR ID (para exibir na página de dados)
        public Funcionarios BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand("SELECT * FROM funcionarios WHERE id_funcionario = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var funcionario = new Funcionarios
                {
                    Id = leitor.GetInt32("id_funcionario"),
                    Nome = DAOHelper.GetString(leitor, "nome_func"),
                    Cpf = DAOHelper.GetString(leitor, "cpf_func"),
                    Rg = DAOHelper.GetString(leitor, "rg_func"),
                    Email = DAOHelper.GetString(leitor, "email_func"),
                    DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascimento_func"),
                    Especialidade = DAOHelper.GetString(leitor, "especialidade_func"),
                    Registro = DAOHelper.GetString(leitor, "registro_profissional_func"),
                    DataContratacao = DAOHelper.GetDateTime(leitor, "data_contratacao_func"),
                    TipoVinculo = DAOHelper.GetString(leitor, "tipo_vinculo_func"),
                    Certificados = DAOHelper.GetString(leitor, "certificados_func"),
                    Telefone = DAOHelper.GetString(leitor, "telefone_func"),
                    Senha = DAOHelper.GetString(leitor, "senha_func")
                };
                leitor.Close();
                return funcionario;
            }

            leitor.Close();
            return null;
        }
    }
}
