using fisioClin.Components.Pages.Paciente;
using FisioClin.Configs;

namespace fisioClin.Models
{
    public class TipoDAO
    {
        private readonly Conexao _conexao;

        public TipoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Tipo> ListarTodos()
        {
            var lista = new List<Tipo>();

            var comando = _conexao.CreateCommand("SELECT * FROM tipo;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var tipo = new Tipo();
                tipo.Id = leitor.GetInt32("id_tip");
                tipo.Nome = DAOHelper.GetString(leitor, "nome_tip");
              

                lista.Add(tipo);
            }

            return lista;
        }

        public void Inserir(Tipo tipo)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    INSERT INTO tipo 
                    (nome_tip)
                    VALUES (@_nome);
                ");

                comando.Parameters.AddWithValue("@_nome", tipo.Nome);
             

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tipo BuscarPorId(int id)
        {
            var tipo = new Tipo();

            var comando = _conexao.CreateCommand("SELECT * FROM tipo WHERE (id_tip = @_id);");

            comando.Parameters.AddWithValue("@_id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                tipo.Id = leitor.GetInt32("id_tip");
                tipo.Nome = DAOHelper.GetString(leitor, "nome_tip");              
            }

            return tipo;
        }
        public void Excluir(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand("DELETE FROM tipo WHERE id_tip = @_id;");
                comando.Parameters.AddWithValue("@_id", id);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir tipo", ex);
            }
        }

        public void Atualizar(Tipo tipo)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    UPDATE tipo
                    SET nome_tip = @_nome                       
                    WHERE id_tip = @_id;
                ");

                comando.Parameters.AddWithValue("@_nome", tipo.Nome);
                comando.Parameters.AddWithValue("@_id", tipo.Id);
               

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar tipo", ex);
            }
        }
    }
}
