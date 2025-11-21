using fisioClin.Components;
using fisioClin.Components.Pages;
using fisioClin.Models;
using FisioClin.Configs;

namespace fisioClin.Models
{
    public class PacienteDAO
    {
        private readonly Conexao _conexao;

        public PacienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Paciente> ListarTodos()
        {
            var lista = new List<Paciente>();

            var comando = _conexao.CreateCommand("SELECT * FROM paciente;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var paciente = new Paciente();
                paciente.Id = leitor.GetInt32("id_pac");
                paciente.Nome = DAOHelper.GetString(leitor, "nome_pac");
                paciente.Cpf = DAOHelper.GetString(leitor, "cpf_pac");
                paciente.Rg = DAOHelper.GetString(leitor, "rg_pac");
                paciente.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascimento_pac");
                paciente.Sexo = DAOHelper.GetString(leitor, "sexo_pac");
                paciente.Email = DAOHelper.GetString(leitor, "email_pac");
                paciente.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
                paciente.Cep = DAOHelper.GetString(leitor, "cep_pac");
                paciente.Bairro = DAOHelper.GetString(leitor, "bairro_pac");
                paciente.Rua = DAOHelper.GetString(leitor, "rua_pac");
                paciente.Numero = DAOHelper.GetString(leitor, "numero_pac");

                lista.Add(paciente);
            }

            leitor.Close(); // <--- fechar o leitor é crucial
            return lista;
        }

        public void Inserir(Paciente paciente)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    INSERT INTO paciente (nome_pac, cpf_pac, rg_pac, data_nascimento_pac, sexo_pac, telefone_pac, email_pac, cep_pac, rua_pac, numero_pac, bairro_pac) 
                    VALUES (@_nome, @_cpf, @_rg, @_datanascimento, @_sexo, @_telefone, @_email, @_cep, @_rua, @_numero, @_bairro);
                ");

                comando.Parameters.AddWithValue("@_nome", paciente.Nome);
                comando.Parameters.AddWithValue("@_cpf", paciente.Cpf);
                comando.Parameters.AddWithValue("@_rg", paciente.Rg);
                comando.Parameters.AddWithValue("@_datanascimento", paciente.DataNascimento);
                comando.Parameters.AddWithValue("@_sexo", paciente.Sexo);
                comando.Parameters.AddWithValue("@_telefone", paciente.Telefone);
                comando.Parameters.AddWithValue("@_email", paciente.Email);
                comando.Parameters.AddWithValue("@_cep", paciente.Cep);
                comando.Parameters.AddWithValue("@_rua", paciente.Rua);
                comando.Parameters.AddWithValue("@_numero", paciente.Numero);
                comando.Parameters.AddWithValue("@_bairro", paciente.Bairro);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir paciente", ex);
            }
        }

        public void Atualizar(Paciente paciente)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    UPDATE paciente
                    SET nome_pac = @_nome,
                        cpf_pac = @_cpf,
                        rg_pac = @_rg,
                        data_nascimento_pac = @_datanascimento,
                        sexo_pac = @_sexo,
                        telefone_pac = @_telefone,
                        email_pac = @_email,
                        cep_pac = @_cep,
                        rua_pac = @_rua,
                        numero_pac = @_numero,
                        bairro_pac = @_bairro
                    WHERE id_pac = @_id;
                ");

                comando.Parameters.AddWithValue("@_nome", paciente.Nome);
                comando.Parameters.AddWithValue("@_cpf", paciente.Cpf);
                comando.Parameters.AddWithValue("@_rg", paciente.Rg);
                comando.Parameters.AddWithValue("@_datanascimento", paciente.DataNascimento);
                comando.Parameters.AddWithValue("@_sexo", paciente.Sexo);
                comando.Parameters.AddWithValue("@_telefone", paciente.Telefone);
                comando.Parameters.AddWithValue("@_email", paciente.Email);
                comando.Parameters.AddWithValue("@_cep", paciente.Cep);
                comando.Parameters.AddWithValue("@_rua", paciente.Rua);
                comando.Parameters.AddWithValue("@_numero", paciente.Numero);
                comando.Parameters.AddWithValue("@_bairro", paciente.Bairro);
                comando.Parameters.AddWithValue("@_id", paciente.Id);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar paciente", ex);
            }
        }

        public void Deletar(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    DELETE FROM paciente WHERE id_pac = @_id;
                ");
                comando.Parameters.AddWithValue("@_id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar paciente", ex);
            }
        }

        public Paciente BuscarPorId(int id)
        {
            var paciente = new Paciente();

            var comando = _conexao.CreateCommand("SELECT * FROM paciente WHERE id_pac = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                paciente.Id = leitor.GetInt32("id_pac");
                paciente.Nome = DAOHelper.GetString(leitor, "nome_pac");
                paciente.Cpf = DAOHelper.GetString(leitor, "cpf_pac");
                paciente.Rg = DAOHelper.GetString(leitor, "rg_pac");
                paciente.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascimento_pac");
                paciente.Sexo = DAOHelper.GetString(leitor, "sexo_pac");
                paciente.Email = DAOHelper.GetString(leitor, "email_pac");
                paciente.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
                paciente.Cep = DAOHelper.GetString(leitor, "cep_pac");
                paciente.Bairro = DAOHelper.GetString(leitor, "bairro_pac");
                paciente.Rua = DAOHelper.GetString(leitor, "rua_pac");
                paciente.Numero = DAOHelper.GetString(leitor, "numero_pac");

                leitor.Close(); // <--- fecha leitor
                return paciente;
            }

            leitor.Close(); // <--- fecha leitor
            return null;
        }

        public bool VerificarCpfExistente(string cpf)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "SELECT COUNT(*) FROM paciente WHERE cpf_pac = @_cpf;"
                );
                comando.Parameters.AddWithValue("@_cpf", cpf); // corrigido
                var resultado = Convert.ToInt32(comando.ExecuteScalar());
                return resultado > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool VerificarRgExistente(string rg)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "SELECT COUNT(*) FROM paciente WHERE rg_pac = @_rg;"
                );
                comando.Parameters.AddWithValue("@_rg", rg);
                var resultado = Convert.ToInt32(comando.ExecuteScalar());
                return resultado > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
