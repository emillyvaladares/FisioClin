using fisioClin.Components.Pages;
using FisioClin.Configs;

namespace fisioClin.Models
{
    public class ProntuarioDAO
    {
        private readonly Conexao _conexao;

        public ProntuarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Prontuario> ListarTodos()
        {
            var lista = new List<Prontuario>();

            var comando = _conexao.CreateCommand("SELECT * FROM prontuario;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var prontuario = new Prontuario();
                prontuario.Id = leitor.GetInt32("id_prontuario");
                prontuario.Data = DAOHelper.GetDateTime(leitor, "data_pront");
                prontuario.Alergia = DAOHelper.GetString(leitor, "alergia_pront");
                prontuario.Comorbidade = DAOHelper.GetString(leitor, "comorbidade_pront");
                prontuario.Doenca = DAOHelper.GetString(leitor, "doenca_previa_pront");
                prontuario.Hostorico = DAOHelper.GetString(leitor, "historico_familiar_pront");
                prontuario.Habito = DAOHelper.GetString(leitor, "habito_vida_pront");
                prontuario.Avaliacao = DAOHelper.GetString(leitor, "avaliacao_pront");
                prontuario.Id_Paciente_Fk = leitor.GetInt32("id_paciente_fk");

                lista.Add(prontuario);
            }
            return lista;
        }

        public void Inserir(Prontuario prontuario)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO prontuario VALUES (@_id, @_data, @_alergia, @_comorbidade, @_doenca, @_historico, @_habito, @_avaliacao, @_id_paciente_fk)");

                comando.Parameters.AddWithValue("@_id", prontuario.Id);
                comando.Parameters.AddWithValue("@_data", prontuario.Data);
                comando.Parameters.AddWithValue("@_alergia", prontuario.Alergia);
                comando.Parameters.AddWithValue("@_comorbidade", prontuario.Comorbidade);
                comando.Parameters.AddWithValue("@_doenca", prontuario.Doenca);
                comando.Parameters.AddWithValue("@_historico", prontuario.Hostorico);
                comando.Parameters.AddWithValue("@_habito", prontuario.Habito);
                comando.Parameters.AddWithValue("@_avaliacao", prontuario.Avaliacao);
                comando.Parameters.AddWithValue("@_id_paciente_fk", prontuario.Id_Paciente_Fk);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
