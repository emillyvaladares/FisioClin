using FisioClin.Configs;

namespace fisioClin.Models
{
    public class LaudoDAO
    {
        private readonly Conexao _conexao;

        public LaudoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Laudo> ListarTodos()
        {
            var lista = new List<Laudo>();

            var comando = _conexao.CreateCommand("SELECT * FROM laudo;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var laudo = new Laudo();
                laudo.Id = leitor.GetInt32("id_laudo");
                laudo.Validade = DAOHelper.GetString(leitor, "Validade_laudo");
                laudo.Exame = DAOHelper.GetString(leitor, "Tipo_exame");
                laudo.Diagnostico = DAOHelper.GetString(leitor, "diagnostico_laudo");
                laudo.Observacao = DAOHelper.GetString(leitor, "observacao_laudo");
                laudo.Status = DAOHelper.GetString(leitor, "status_laudo");
                laudo.Id_paciente_fk = leitor.GetInt32("id_paciente_fk");

                lista.Add(laudo);
            }
            return lista;
        }

        public void Inserir(Laudo laudo)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO laudo VALUES (@_id, @_validade, @_exame, @_diagnostico, @_observacao, @_status, @_id_fk)");

                comando.Parameters.AddWithValue("@_id", laudo.Id);
                comando.Parameters.AddWithValue("@_validade", laudo.Validade);
                comando.Parameters.AddWithValue("@_exame", laudo.Exame);
                comando.Parameters.AddWithValue("@_diagnostico", laudo.Diagnostico);
                comando.Parameters.AddWithValue("@_observacao", laudo.Observacao);
                comando.Parameters.AddWithValue("@_status", laudo.Status);
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
