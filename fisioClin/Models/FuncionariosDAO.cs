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
                funcionario.TipoVinculo = DAOHelper.GetString(leitor, "tipo_vinculo");
                funcionario.Senha = DAOHelper.GetString(leitor, "senha_func");
                funcionario.Rg = DAOHelper.GetString(leitor, "rg_func");
                funcionario.Especialidade = DAOHelper.GetString(leitor, "especialidade_func");
                funcionario.Subespecialidade = DAOHelper.GetString(leitor, "subespecialidade_func");
                funcionario.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
                funcionario.Email = DAOHelper.GetString(leitor, "email_func");
                funcionario.Registro = DAOHelper.GetString(leitor, "registro_profissional_func");
                funcionario.Certificados = DAOHelper.GetString(leitor, "certificados_func");
                funcionario.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascmento_func");
                

                lista.Add(funcionario);
            }
           
            leitor.Close();
            return lista;
        }

        public void Inserir(Funcionarios funcionarios)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO funcioinarios VALUES (@_id, @_nome, @_cpf, @_vinculo, @_senha, @_rg, @_especialidade, @_subespecialidade, @_telefone, @_email, @_registro, @_certificados, @_datanascimento, @_datacontratacao)");

                comando.Parameters.AddWithValue("@_id", funcionarios.Id);
                comando.Parameters.AddWithValue("@_nome", funcionarios.Nome);
                comando.Parameters.AddWithValue("@_cpf", funcionarios.Cpf);
                comando.Parameters.AddWithValue("@_vinculo", funcionarios.TipoVinculo);
                comando.Parameters.AddWithValue("@_senha", funcionarios.Senha);
                comando.Parameters.AddWithValue("@_rg", funcionarios.Rg);
                comando.Parameters.AddWithValue("@_especialidade", funcionarios.Especialidade);
                comando.Parameters.AddWithValue("@_subespecialidade", funcionarios.Subespecialidade);
                comando.Parameters.AddWithValue("@_telefone", funcionarios.Telefone);
                comando.Parameters.AddWithValue("@_email", funcionarios.Email);
                comando.Parameters.AddWithValue("@_certificados", funcionarios.Certificados);
                comando.Parameters.AddWithValue("@_datanascimento", funcionarios.DataNascimento);
                comando.Parameters.AddWithValue("@_datacontratacao", funcionarios.DataContratacao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
      
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
