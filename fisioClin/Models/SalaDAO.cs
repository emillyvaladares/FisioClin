using fisioClin.Configs;

namespace fisioClin.Models
{
    public class SalaDAO
    {
        private readonly Conexao _conexao;

        public SalaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Sala> ListarTodos()
        {
            var lista = new List<Sala>();

            var comando = _conexao.CreateCommand("SELECT * FROM sala;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var sala = new Sala();
                sala.Id = leitor.GetInt32("id_sala");
                sala.Nome = leitor.GetString("nome_sala");
                sala.Numero = DAOHelper.GetString(leitor, "numero_sala");
                sala.Capacidade = DAOHelper.GetString(leitor, "capacidade_sala");
                sala.Tipo = DAOHelper.GetString(leitor, "tipo_sala");
                sala.Disponibilidade = DAOHelper.GetString(leitor, "disponibilidade_sala");
                sala.Observacao = DAOHelper.GetString(leitor, "observacao_sala");
       
                lista.Add(sala);
            }
            return lista;
        }

        public void Inserir(Sala sala)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO sala VALUES (@_id,@_nome, @_numero, @_capacidade, @_tipo, @_disponibilidade, @_observacao)");

                comando.Parameters.AddWithValue("@_id", sala.Id);
                comando.Parameters.AddWithValue("@_nome", sala.Nome);
                comando.Parameters.AddWithValue("@_numero", sala.Numero);
                comando.Parameters.AddWithValue("@_capacidade", sala.Capacidade);
                comando.Parameters.AddWithValue("@_tipo", sala.Tipo);
                comando.Parameters.AddWithValue("@_disponibilidade", sala.Disponibilidade);
                comando.Parameters.AddWithValue("@_observacao", sala.Observacao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
