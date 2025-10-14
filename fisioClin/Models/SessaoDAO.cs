using fisioClin.Configs;

namespace fisioClin.Models
{
    public class SessaoDAO
    {
        private readonly Conexao _conexao;

        public SessaoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Sessao> ListarTodos()
        {
            var lista = new List<Sessao>();

            var comando = _conexao.CreateCommand("SELECT * FROM sessao;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var sessao = new Sessao();
                sessao.Id = leitor.GetInt32("id_sessao");
                sessao.Data = DAOHelper.GetString(leitor, "data_sessao");
                sessao.Horario = DAOHelper.GetString(leitor, "horario_sessao");
                sessao.Tipo = DAOHelper.GetString(leitor, "tipo_sessao");
                sessao.Observacao = DAOHelper.GetString(leitor, "observacao_sessao");
                sessao.Id_Funcionario_fk = leitor.GetInt32("id_funcionario_fk");

                lista.Add(sessao);
            }
            return lista;
        }

        public void Inserir(Sessao sessao)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO sessao VALUES (@_id, @_data, @_horario, @_tipo, @_observacao, @_id_funcionario_fk, @_id_paciente_fk)");

                comando.Parameters.AddWithValue("@_id", sessao.Id);
                comando.Parameters.AddWithValue("@_data", sessao.Data);
                comando.Parameters.AddWithValue("@_horario", sessao.Horario);
                comando.Parameters.AddWithValue("@_tipo", sessao.Tipo);
                comando.Parameters.AddWithValue("@_observacao", sessao.Observacao);
                comando.Parameters.AddWithValue("@_id_funcionario_fk", sessao.Id_Funcionario_fk);
                comando.Parameters.AddWithValue("@_id_paciente_fk", sessao.Id_Paciente_fk_);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
