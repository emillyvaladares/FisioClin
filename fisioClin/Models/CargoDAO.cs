using fisioClin.Configs;

namespace fisioClin.Models
{
    public class CargoDAO
    {
        private readonly Conexao _conexao;

        public CargoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cargo> ListarTodos()
        {
            var lista = new List<Cargo>();

            var comando = _conexao.CreateCommand("SELECT * FROM cargo;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cargo = new Cargo();
                cargo.Id = leitor.GetInt32("id_cargo");
                cargo.Nome = DAOHelper.GetString(leitor, "nome_cargo");
                cargo.Departamento = DAOHelper.GetString(leitor, "departamento_cargo");
                cargo.Descricao = DAOHelper.GetString(leitor, "descricao_cargo");
                cargo.Carga = leitor.GetInt32("carga_horaria");
                cargo.DataCriacao = DAOHelper.GetDateTime(leitor, "data_criacao");
                cargo.DataAtualizacao = DAOHelper.GetDateTime(leitor, "data_atualizacao)");
                cargo.Observacao = DAOHelper.GetString(leitor, "observacoes_cargo");

                lista.Add(cargo);
            }
            return lista;
        }

        public void Inserir(Cargo cargo)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cargo VALUES (@_id, @_nome, @_departamento, @_descricao, @_carga_horaria, @_data_criacao, @_dataatualizacao, @_observacoes)");

                comando.Parameters.AddWithValue("@_id", cargo.Id);
                comando.Parameters.AddWithValue("@_nome", cargo.Nome);
                comando.Parameters.AddWithValue("@_departamento", cargo.Departamento);
                comando.Parameters.AddWithValue("@_descricao", cargo.Descricao);
                comando.Parameters.AddWithValue("@_carga_horaria", cargo.Carga);
                comando.Parameters.AddWithValue("@_data_criacao", cargo.DataCriacao);
                comando.Parameters.AddWithValue("@_dataatualizacao", cargo.DataAtualizacao);
                comando.Parameters.AddWithValue("@_observacoes", cargo.Observacao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
