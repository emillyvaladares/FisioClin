using fisioClin.Configs;
using fisioClin.Models;

namespace fisioClin.Models
{
    public class EnderecoDAO
    {
        private readonly Conexao _conexao;

        public EnderecoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Endereco> ListarTodos()
        {
            var lista = new List<Endereco>();

            var comando = _conexao.CreateCommand("SELECT * FROM endereco;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var endereco = new Endereco();
                endereco.Id = leitor.GetInt32("id_end");
                endereco.Cep = DAOHelper.GetString(leitor, "cep_end");
                endereco.Bairro = DAOHelper.GetString(leitor, "bairro_end");
                endereco.Rua = DAOHelper.GetString(leitor, "rua_end");
                endereco.Numero = DAOHelper.GetString(leitor, "numero_end");

                lista.Add(endereco);
            }
            return lista;
        }

        public void Inserir(Endereco endereco)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO endereco VALUES (@_id, @_cep, @_bairro, @_rua, @_numero)");

                comando.Parameters.AddWithValue("@_id", endereco.Id);
                comando.Parameters.AddWithValue("@_cep", endereco.Cep);
                comando.Parameters.AddWithValue("@_bairro", endereco.Bairro);
                comando.Parameters.AddWithValue("@_rua", endereco.Rua);
                comando.Parameters.AddWithValue("@_numero", endereco.Numero);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}