using fisioClin.Configs;

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

            while (funcionarios.Read())
            {
                var funcionarios = new Funcionarios();
                funcionarios.Id = leitor.GetInt32("id_fucionarios");
                funcionarios. = DAOHelper.GetString(leitor, "tipo_exame");
                funcionarios.Diagnostico = DAOHelper.GetString(leitor, "diagnostico_laudo");
                funcionarios.Observacao = DAOHelper.GetString(leitor, "observacao_laudo");
                funcionarios.Id_paciente_fk = leitor.GetInt32("id_paciente_fk");

                lista.Add(funcionarios);
            }
            return lista;
        }

        public void Inserir(Laudo laudo)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO laudo VALUES (@_id, @_exame, @_diagnostico, @_observacao, @_id_fk)");

                comando.Parameters.AddWithValue("@_id", laudo.Id);
                comando.Parameters.AddWithValue("@_exame", laudo.Exame);
                comando.Parameters.AddWithValue("@_diagnostico", laudo.Diagnostico);
                comando.Parameters.AddWithValue("@_observacao", laudo.Observacao);
                comando.Parameters.AddWithValue("@_id_fk", laudo.Id_paciente_fk);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
