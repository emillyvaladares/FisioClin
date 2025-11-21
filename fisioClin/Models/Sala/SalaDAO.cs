using FisioClin.Configs;

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
                sala.Id = leitor.GetInt32("id_sal");
                sala.Nome = DAOHelper.GetString(leitor, "nome_sal");
                sala.Numero = DAOHelper.GetString(leitor, "numero_sal");
                sala.Capacidade = leitor.GetInt32("capacidade_sal");
                sala.Tipo = DAOHelper.GetString(leitor, "tipo_sal");
                sala.Disponibilidade = DAOHelper.GetString(leitor, "disponibilidade_sal");
                sala.Observacao = DAOHelper.GetString(leitor, "observacao_sal");

                lista.Add(sala);
            }

            return lista;
        }

        public void Inserir(Sala sala)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    INSERT INTO sala 
                    (nome_sal, numero_sal, capacidade_sal, tipo_sal, disponibilidade_sal, observacao_sal)
                    VALUES (@_nome, @_numero, @_capacidade, @_tipo, @_disponibilidade, @_observacao);
                ");

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
