using fisioClin.Components;
using fisioClin.Components.Pages;
using fisioClin.Models;
using FisioClin.Configs;


//antes de criar qualquer coisa que faça integração com o banco de dados, crie primeiro dentro do banco
//se for criar um select por exemplo, faça primeiro do banco e depois passe pra ca
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
                paciente.Cep = DAOHelper.GetString(leitor, "cep_pac");
                paciente.Rg = DAOHelper.GetString(leitor, "rg_pac");
                paciente.Bairro = DAOHelper.GetString(leitor, "bairro_pac");
                paciente.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascimento_pac");
                paciente.Rua = DAOHelper.GetString(leitor, "rua_pac");
                paciente.Numero = DAOHelper.GetString(leitor, "numero_pac");
                paciente.Sexo = DAOHelper.GetString(leitor, "sexo_pac");
                paciente.Email = DAOHelper.GetString(leitor, "email_pac");
                paciente.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
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

        public Paciente BuscarPorId(int id)
        {
            var paciente = new Paciente();

            var comando = _conexao.CreateCommand("SELECT * FROM paciente WHERE (id_pac = @id);");
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

                leitor.Close();
                return paciente;
            }

            leitor.Close();
            return null;
        }
        
        // o cpf e o rg estao marcados como unique no bd, entao precisa verificar antes de cadastrar se ja existe algum cadastro com o cpf ou rg que foi digitado
        public bool VerificarCpfExistente(String cpf)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "SELECT COUNT(*) FROM paciente WHERE (cpf_pac = @_cpf);"
                );
                comando.Parameters.AddWithValue("@_rg", cpf);

                var resultado = Convert.ToInt32(comando.ExecuteScalar());

                return resultado > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }


        }
        public bool VerificarRgExistente(String rg)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "SELECT COUNT(*) FROM paciente WHERE (rg_pac = @_rg);"
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


