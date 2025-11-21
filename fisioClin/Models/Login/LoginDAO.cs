using FisioClin.Configs;

namespace fisioClin.Models
{
    public class LoginDAO
    {
        private readonly Conexao _conexao;

        public LoginDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // lista todos (faz UNION entre pacientes e funcionários)
        public List<Login> ListarTodos()
        {
            var lista = new List<Login>();

            var sql = @"
                SELECT id_lop AS id, email_lop AS email, senha_lop AS senha, id_pac_fk AS id_paciente, NULL AS id_funcionario
                FROM login_paciente
                UNION ALL
                SELECT id_lof AS id, email_lof AS email, senha_lof AS senha, NULL AS id_paciente, id_fun_fk AS id_funcionario
                FROM login_funcionario;
            ";

            var comando = _conexao.CreateCommand(sql);
            var leitor = comando.ExecuteReader();

            // ordinais (mais seguro / performático)
            int ordId = leitor.GetOrdinal("id");
            int ordEmail = leitor.GetOrdinal("email");
            int ordSenha = leitor.GetOrdinal("senha");
            int ordIdPac = leitor.GetOrdinal("id_paciente");
            int ordIdFun = leitor.GetOrdinal("id_funcionario");

            while (leitor.Read())
            {
                var login = new Login
                {
                    Id = leitor.IsDBNull(ordId) ? 0 : leitor.GetInt32(ordId),
                    Email = leitor.IsDBNull(ordEmail) ? string.Empty : leitor.GetString(ordEmail),
                    Senha = leitor.IsDBNull(ordSenha) ? string.Empty : leitor.GetString(ordSenha),
                    IdPaciente = leitor.IsDBNull(ordIdPac) ? (int?)null : leitor.GetInt32(ordIdPac),
                    IdFuncionario = leitor.IsDBNull(ordIdFun) ? (int?)null : leitor.GetInt32(ordIdFun)
                };

                lista.Add(login);
            }

            leitor.Close();
            return lista;
        }

        // Inserir login de paciente
        public void InserirPaciente(Login login)
        {
            var comando = _conexao.CreateCommand(@"
                INSERT INTO login_paciente (email_lop, senha_lop, id_pac_fk)
                VALUES (@_email, @_senha, @_idPac);
            ");

            comando.Parameters.AddWithValue("@_email", login.Email);
            comando.Parameters.AddWithValue("@_senha", login.Senha);
            comando.Parameters.AddWithValue("@_idPac", login.IdPaciente ?? throw new ArgumentException("IdPaciente precisa estar preenchido"));

            comando.ExecuteNonQuery();
        }

        // Inserir login de funcionário
        public void InserirFuncionario(Login login)
        {
            var comando = _conexao.CreateCommand(@"
                INSERT INTO login_funcionario (email_lof, senha_lof, id_fun_fk)
                VALUES (@_email, @_senha, @_idFun);
            ");

            comando.Parameters.AddWithValue("@_email", login.Email);
            comando.Parameters.AddWithValue("@_senha", login.Senha);
            comando.Parameters.AddWithValue("@_idFun", login.IdFuncionario ?? throw new ArgumentException("IdFuncionario precisa estar preenchido"));

            comando.ExecuteNonQuery();
        }

        // Verificar login paciente (por email + senha)
        public bool VerificarLoginPaciente(string email, string senha)
        {
            var comando = _conexao.CreateCommand(
                "SELECT COUNT(*) FROM login_paciente WHERE email_lop = @_email AND senha_lop = @_senha"
            );

            comando.Parameters.AddWithValue("@_email", email);
            comando.Parameters.AddWithValue("@_senha", senha);

            int resultado = Convert.ToInt32(comando.ExecuteScalar());
            return resultado > 0;
        }

        // Verificar login funcionário (por email + senha)
        public bool VerificarLoginFuncionario(string email, string senha)
        {
            var comando = _conexao.CreateCommand(
                "SELECT COUNT(*) FROM login_funcionario WHERE email_lof = @_email AND senha_lof = @_senha"
            );

            comando.Parameters.AddWithValue("@_email", email);
            comando.Parameters.AddWithValue("@_senha", senha);

            int resultado = Convert.ToInt32(comando.ExecuteScalar());
            return resultado > 0;
        }
    }
}
