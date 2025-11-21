using FisioClin.Configs;

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

                sessao.Id = leitor.GetInt32("id_ses");
                sessao.Data = DAOHelper.GetDateTime(leitor, "data_ses");
                sessao.Horario = DAOHelper.GetString(leitor, "horario_ses");
                sessao.Tipo = DAOHelper.GetString(leitor, "tipo_ses");
                sessao.Observacao = DAOHelper.GetString(leitor, "observacao_ses");

                // **usando exatamente o nome da coluna do banco: id_sal_fk**
                sessao.Id_Paciente_fk = leitor.GetInt32("id_pac_fk");
                sessao.Id_Funcionario_fk = leitor.GetInt32("id_fun_fk");
               
                lista.Add(sessao);
            }

            leitor.Close();
            return lista;
        }

        public void Inserir(Sessao sessao)
        {
            try
            {
                // Inserindo com lista explícita de colunas, usando NULL para id_ses (auto_increment)
                var comando = _conexao.CreateCommand(@"
                    INSERT INTO sessao
                    (data_ses, horario_ses, tipo_ses, observacao_ses, id_pac_fk, id_fun_fk, id_sal_fk)
                    VALUES
                    (@_data, @_horario, @_tipo, @_observacao, @_id_pac, @_id_fun, @_id_sal);
                ");

                comando.Parameters.AddWithValue("@_data", sessao.Data);
                comando.Parameters.AddWithValue("@_horario", sessao.Horario);
                comando.Parameters.AddWithValue("@_tipo", sessao.Tipo);
                comando.Parameters.AddWithValue("@_observacao", sessao.Observacao);

                comando.Parameters.AddWithValue("@_id_pac", sessao.Id_Paciente_fk);
                comando.Parameters.AddWithValue("@_id_fun", sessao.Id_Funcionario_fk);
              
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
