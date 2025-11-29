using FisioClin.Configs;
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

            var comando = _conexao.CreateCommand("SELECT * FROM funcionario;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var funcionario = new Funcionarios();
                funcionario.Id = leitor.GetInt32("id_fun");
                funcionario.Nome = DAOHelper.GetString(leitor, "nome_fun");
                funcionario.Cpf = DAOHelper.GetString(leitor, "cpf_fun");
                funcionario.Rg = DAOHelper.GetString(leitor, "rg_fun");
                funcionario.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascimento_fun");
                funcionario.Telefone = DAOHelper.GetString(leitor, "telefone_fun");
                funcionario.Email = DAOHelper.GetString(leitor, "email_fun");
                funcionario.TipoVinculo = DAOHelper.GetString(leitor, "tipo_vinculo_fun").ToLower();
                funcionario.RegistroProfissional = DAOHelper.GetString(leitor, "registro_profissional_fun");
                funcionario.Especialidade = DAOHelper.GetString(leitor, "especialidade_fun");
                funcionario.Subespecialidade = DAOHelper.GetString(leitor, "subespecialidade_fun");
                funcionario.Certificados = DAOHelper.GetString(leitor, "certificados_fun");
                funcionario.DataContratacao = DAOHelper.GetDateTime(leitor, "data_contratacao_fun");
                funcionario.Id_Cargo_fk = leitor.GetInt32("id_car_fk");

                lista.Add(funcionario);
            }

            leitor.Close();
            return lista;
        }


        public void Inserir(Funcionarios funcionario)
        {
            try
            {
        
                var comando = _conexao.CreateCommand(@"
                INSERT INTO funcionario
                (nome_fun, cpf_fun, rg_fun, data_nascimento_fun, telefone_fun, email_fun, tipo_vinculo_fun,
                 registro_profissional_fun, especialidade_fun, subespecialidade_fun, certificados_fun,
                 data_contratacao_fun, id_car_fk)
                VALUES
                (@_nome, @_cpf, @_rg, @_datanasc, @_telefone, @_email, @_vinculo,
                 @_registro, @_especialidade, @_subespecialidade, @_certificados,
                 @_datacontratacao, @_cargo);
            ");

                    comando.Parameters.AddWithValue("@_nome", funcionario.Nome);
                    comando.Parameters.AddWithValue("@_cpf", funcionario.Cpf);
                    comando.Parameters.AddWithValue("@_rg", funcionario.Rg);
                    comando.Parameters.AddWithValue("@_datanasc", funcionario.DataNascimento);
                    comando.Parameters.AddWithValue("@_telefone", funcionario.Telefone);
                    comando.Parameters.AddWithValue("@_email", funcionario.Email);
                    comando.Parameters.AddWithValue("@_vinculo", funcionario.TipoVinculo.ToLower());
                    comando.Parameters.AddWithValue("@_registro", funcionario.RegistroProfissional);
                    comando.Parameters.AddWithValue("@_especialidade", funcionario.Especialidade);
                    comando.Parameters.AddWithValue("@_subespecialidade", funcionario.Subespecialidade);
                    comando.Parameters.AddWithValue("@_certificados", funcionario.Certificados);
                    comando.Parameters.AddWithValue("@_datacontratacao", funcionario.DataContratacao);
                    comando.Parameters.AddWithValue("@_cargo", funcionario.Id_Cargo_fk);

                    comando.ExecuteNonQuery();
                }

    
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir funcionário", ex);
            }
        }

        public Funcionarios BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand("SELECT * FROM funcionario WHERE id_fun = @_id;");
            comando.Parameters.AddWithValue("@_id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var funcionario = new Funcionarios();
                funcionario.Id = leitor.GetInt32("id_fun");
                funcionario.Nome = DAOHelper.GetString(leitor, "nome_fun");
                funcionario.Cpf = DAOHelper.GetString(leitor, "cpf_fun");
                funcionario.Rg = DAOHelper.GetString(leitor, "rg_fun");
                funcionario.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascimento_fun");
                funcionario.Telefone = DAOHelper.GetString(leitor, "telefone_fun");
                funcionario.Email = DAOHelper.GetString(leitor, "email_fun");
                funcionario.RegistroProfissional = DAOHelper.GetString(leitor, "registro_profissional_fun");
                funcionario.TipoVinculo = DAOHelper.GetString(leitor, "tipo_vinculo_fun").ToLower();                
                funcionario.Especialidade = DAOHelper.GetString(leitor, "especialidade_fun");
                funcionario.Subespecialidade = DAOHelper.GetString(leitor, "subespecialidade_fun");
                funcionario.Certificados = DAOHelper.GetString(leitor, "certificados_fun");
                funcionario.DataContratacao = DAOHelper.GetDateTime(leitor, "data_contratacao_fun");
                funcionario.Id_Cargo_fk = leitor.GetInt32("id_car_fk");

                leitor.Close();
                return funcionario;
            }

            leitor.Close();
            return null;
        }



        public void Atualizar(Funcionarios funcionario)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                UPDATE funcionario SET
                nome_fun = @_nome,
                cpf_fun = @_cpf,
                rg_fun = @_rg,
                data_nascimento_fun = @_datanasc,
                telefone_fun = @_telefone,
                email_fun = @_email,
                tipo_vinculo_fun = @_vinculo,
                registro_profissional_fun = @_registro,
                especialidade_fun = @_especialidade,
                subespecialidade_fun = @_subespecialidade,
                certificados_fun = @_certificados,
                data_contratacao_fun = @_datacontratacao,
                id_car_fk = @_id_car
                 WHERE id_fun = @_id;");

                comando.Parameters.AddWithValue("@_id", funcionario.Id);
                comando.Parameters.AddWithValue("@_nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@_cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@_rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@_datanasc", funcionario.DataNascimento);
                comando.Parameters.AddWithValue("@_telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@_email", funcionario.Email);
                comando.Parameters.AddWithValue("@_vinculo", funcionario.TipoVinculo.ToLower());
                comando.Parameters.AddWithValue("@_registro", funcionario.RegistroProfissional);
                comando.Parameters.AddWithValue("@_especialidade", funcionario.Especialidade);
                comando.Parameters.AddWithValue("@_subespecialidade", funcionario.Subespecialidade);
                comando.Parameters.AddWithValue("@_certificados", funcionario.Certificados);
                comando.Parameters.AddWithValue("@_datacontratacao", funcionario.DataContratacao);
                comando.Parameters.AddWithValue("@_id_car", funcionario.Id_Cargo_fk);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar funcionário", ex);
            }
        }
        public void Excluir(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand("DELETE FROM funcionario WHERE id_fun = @_id;");
                comando.Parameters.AddWithValue("@_id", id);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir funcionário", ex);
            }
        }

    }
}
