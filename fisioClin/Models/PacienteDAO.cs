using fisioClin.Configs;

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
                paciente.Id = leitor.GetInt32("id_paciente");
                paciente.Nome = DAOHelper.GetString(leitor, "nome_pac");
                paciente.Cpf = DAOHelper.GetString(leitor, "cpf_pac");
                paciente.Cep = DAOHelper.GetString(leitor, "cep_pac");
                paciente.Rg = DAOHelper.GetString(leitor, "rg_pac");
                paciente.Bairro = DAOHelper.GetString(leitor, "bairro_pac");
                paciente.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascmento_pac");
                paciente.Rua = DAOHelper.GetString(leitor, "rua_pac");
                paciente.Numero = DAOHelper.GetString(leitor, "numero_pac");
                paciente.Sexo = DAOHelper.GetString(leitor, "sexo_pac");
                paciente.Email = DAOHelper.GetString(leitor, "email_pac");
                paciente.Telefone = DAOHelper.GetString(leitor, "telefone_pac");

                // CORREÇÃO: Inclusão dos campos de endereço que estavam faltando na leitura
                paciente.Cep = DAOHelper.GetString(leitor, "cep_pac");
                paciente.Bairro = DAOHelper.GetString(leitor, "bairro_pac");
                paciente.Rua = DAOHelper.GetString(leitor, "rua_pac");
                paciente.Numero = DAOHelper.GetString(leitor, "numero_pac");

                lista.Add(paciente);
            }
            return lista;
        }

        public void Inserir(Paciente paciente)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
            INSERT INTO paciente 
                (nome_pac, cpf_pac, cep_pac, rg_pac, bairro_pac, data_nascmento_pac, rua_pac, numero_pac, sexo_pac, email_pac, telefone_pac) 
            VALUES 
                (@_nome, @_cpf, @_cep, @_rg, @_bairro, @_datanascimento, @_rua, @_numero, @_sexo, @_email, @_telefone);
        ");

                comando.Parameters.AddWithValue("@_nome", paciente.Nome);
                comando.Parameters.AddWithValue("@_cpf", paciente.Cpf);
<<<<<<< HEAD
                comando.Parameters.AddWithValue("@_cep", paciente.Cep ?? "");
                comando.Parameters.AddWithValue("@_rg", paciente.Rg ?? "");
                comando.Parameters.AddWithValue("@_bairro", paciente.Bairro ?? "");
                comando.Parameters.AddWithValue("@_datanascimento", paciente.DataNascimento);
                comando.Parameters.AddWithValue("@_rua", paciente.Rua ?? "");
                comando.Parameters.AddWithValue("@_numero", paciente.Numero ?? "");
                comando.Parameters.AddWithValue("@_sexo", paciente.Sexo ?? "");
                comando.Parameters.AddWithValue("@_email", paciente.Email ?? "");
                comando.Parameters.AddWithValue("@_telefone", paciente.Telefone ?? "");
=======
                comando.Parameters.AddWithValue("@_cep", paciente.Cep);
                comando.Parameters.AddWithValue("@_rg", paciente.Rg);
                comando.Parameters.AddWithValue("@_datanascimento", paciente.DataNascimento);
                comando.Parameters.AddWithValue("@_rua", paciente.Rua);
                comando.Parameters.AddWithValue("@_numero", paciente.Numero);
                comando.Parameters.AddWithValue("@_sexo", paciente.Sexo);
                comando.Parameters.AddWithValue("@_email", paciente.Email);
                comando.Parameters.AddWithValue("@_telefone", paciente.Telefone);
>>>>>>> 428703d97b4fa8d8f6e981bf1f76cb8b18d44fc9

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir paciente", ex);
            }
        }

        public Paciente BuscarPorId(int id)
        {
            var paciente = new Paciente();

            var comando = _conexao.CreateCommand("SELECT * FROM paciente WHERE id_paciente = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                paciente.Id = leitor.GetInt32("id_paciente");
                paciente.Nome = DAOHelper.GetString(leitor, "nome_pac");
                paciente.Cpf = DAOHelper.GetString(leitor, "cpf_pac");
                paciente.Rg = DAOHelper.GetString(leitor, "rg_pac");
                paciente.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascmento_pac");
                paciente.Sexo = DAOHelper.GetString(leitor, "sexo_pac");
                paciente.Email = DAOHelper.GetString(leitor, "email_pac");
                paciente.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
                paciente.Cep = DAOHelper.GetString(leitor, "cep_pac");
                paciente.Bairro = DAOHelper.GetString(leitor, "bairro_pac");
                paciente.Rua = DAOHelper.GetString(leitor, "rua_pac");
                paciente.Numero = DAOHelper.GetString(leitor, "numero_pac");

                leitor.Close();
                return paciente;
            }

            leitor.Close();
            return null;
        }
    }
}