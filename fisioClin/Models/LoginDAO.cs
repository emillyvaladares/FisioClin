using fisioClin.Configs;

namespace fisioClin.Models
{
    public class LoginDAO
    {
        private readonly Conexao _conexao;

        public LoginDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Login> ListarTodos()
        {
            var lista = new List<Login>();

            var comando = _conexao.CreateCommand("SELECT * FROM login;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var login = new Login();
                login.Id = leitor.GetInt32("id_login");
                login.Id_Funcionario_fk = leitor.GetInt32("id_funcionario_fk");
                login.Id_Paciente_fk = leitor.GetInt32("id_paciente_fk");

                lista.Add(login);
            }
            return lista;
        }

        public void Inserir(Login login)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO login VALUES (@_id, @_id_funcionario_fk), @_id_paciente_fk)");

                comando.Parameters.AddWithValue("@_id", login.Id);
                comando.Parameters.AddWithValue("@_id_funcionario_fk", login.Id_Funcionario_fk);
                comando.Parameters.AddWithValue("@_id_paciente_fk", login.Id_Paciente_fk);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public bool VerificarLogin(string cpf, string senha)
        {
            var comando = _conexao.CreateCommand(
                "SELECT COUNT(*) FROM login WHERE cpf = @_cpf AND senha = @_senha");

            comando.Parameters.AddWithValue("@_cpf", cpf);
            comando.Parameters.AddWithValue("@_senha", senha);

            var resultado = Convert.ToInt32(comando.ExecuteScalar());

            return resultado > 0;
        }

    }


}

