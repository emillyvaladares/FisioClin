using FisioClin.Configs;
using MySqlX.XDevAPI;

namespace fisioClin.Models
{
    public class AgendaDAO
    {
        private readonly Conexao _conexao;

        public AgendaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Agenda> ListarTodos()
        {
            var lista = new List<Agenda>();

            var comando = _conexao.CreateCommand("SELECT * FROM agenda;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var agenda = new Agenda();
                agenda.Id = leitor.GetInt32("id_agenda");
                agenda.Data = DAOHelper.GetDateTime(leitor, "data_ag");
                agenda.Horario = DAOHelper.GetDateTime(leitor, "horario_ag");
                agenda.Id_Sala_fk = leitor.GetInt32("id_sala_fk");
                agenda.Id_Funcionario_fk = leitor.GetInt32("id_funcionario_fk");
                agenda.Id_Sessao_fk = leitor.GetInt32("id_sessao_fk");
                agenda.Id_Paciente_fk = leitor.GetInt32("id_paciente_fk");
                agenda.Observacao = DAOHelper.GetString(leitor, "observacao_ag");

                lista.Add(agenda);
            }
            return lista;
        }

        public void Inserir(Agenda agenda)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO sessao VALUES (@_id, @_data, @_horario, @_id_sala_fk, @_id_funcionario_fk, @_id_sessao_fk, @_id_paciente_fk, @_observacao)");

                comando.Parameters.AddWithValue("@_id", agenda.Id);
                comando.Parameters.AddWithValue("@_data", agenda.Data);
                comando.Parameters.AddWithValue("@_horario", agenda.Horario);
                comando.Parameters.AddWithValue("@_id_sala_fk", agenda.Id_Sala_fk);
                comando.Parameters.AddWithValue("@_id_funcionario_fk", agenda.Id_Funcionario_fk);
                comando.Parameters.AddWithValue("@_id_sessao_fk", agenda.Id_Sessao_fk);
                comando.Parameters.AddWithValue("@_id_paciente_fk", agenda.Id_Paciente_fk);
                comando.Parameters.AddWithValue("@_observacao", agenda.Observacao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
