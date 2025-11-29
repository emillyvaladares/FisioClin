using FisioClin.Configs;

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
                cargo.Id = leitor.GetInt32("id_car");
                cargo.Nome = DAOHelper.GetString(leitor, "nome_car");
                cargo.Departamento = DAOHelper.GetString(leitor, "departamento_car");
                cargo.Descricao = DAOHelper.GetString(leitor, "descricao_car");
                cargo.Carga = leitor.GetInt32("carga_horaria_car");
                cargo.DataCriacao = DAOHelper.GetDateTime(leitor, "data_criacao_car");
                cargo.DataAtualizacao = DAOHelper.GetDateTime(leitor, "data_atualizacao_car");
                cargo.Observacao = DAOHelper.GetString(leitor, "observacoes_car");

                lista.Add(cargo);
            }

            return lista;
        }

        public void Inserir(Cargo cargo)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    INSERT INTO cargo 
                    (nome_car, departamento_car, descricao_car, carga_horaria_car, data_criacao_car, data_atualizacao_car, observacoes_car)
                    VALUES
                    (@_nome, @_departamento, @_descricao, @_carga, @_data_criacao, @_data_atualizacao, @_observacoes);
                ");

                comando.Parameters.AddWithValue("@_nome", cargo.Nome);
                comando.Parameters.AddWithValue("@_departamento", cargo.Departamento);
                comando.Parameters.AddWithValue("@_descricao", cargo.Descricao);
                comando.Parameters.AddWithValue("@_carga", cargo.Carga);
                comando.Parameters.AddWithValue("@_data_criacao", cargo.DataCriacao);
                comando.Parameters.AddWithValue("@_data_atualizacao", cargo.DataAtualizacao);
                comando.Parameters.AddWithValue("@_observacoes", cargo.Observacao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Atualizar(Cargo cargo)
        {
            var comando = _conexao.CreateCommand(@" UPDATE cargo
            SET nome_car = @_nome,
            departamento_car = @_departamento,
            descricao_car = @_descricao,
            carga_horaria_car = @_carga,
            data_atualizacao_car = @_data_atualizacao,
            observacoes_car = @_observacoes
            WHERE id_car = @_id; ");

            comando.Parameters.AddWithValue("@_nome", cargo.Nome);
            comando.Parameters.AddWithValue("@_departamento", cargo.Departamento);
            comando.Parameters.AddWithValue("@_descricao", cargo.Descricao);
            comando.Parameters.AddWithValue("@_carga", cargo.Carga);
            comando.Parameters.AddWithValue("@_data_atualizacao", cargo.DataAtualizacao);
            comando.Parameters.AddWithValue("@_observacoes", cargo.Observacao);
            comando.Parameters.AddWithValue("@_id", cargo.Id);

            comando.ExecuteNonQuery();
        }

     
        public Cargo BuscarPorId(int id)
        {
            var cargo = new Cargo();

            var comando = _conexao.CreateCommand("SELECT * FROM cargo WHERE (id_car = @_id);");
            comando.Parameters.AddWithValue("@_id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                cargo.Id = leitor.GetInt32("id_car");
                cargo.Nome = DAOHelper.GetString(leitor, "nome_car");
                cargo.Departamento = DAOHelper.GetString(leitor, "departamento_car");
                cargo.Descricao = DAOHelper.GetString(leitor, "descricao_car");
                cargo.Carga = leitor.GetInt32("carga_horaria_car");
                cargo.DataCriacao = DAOHelper.GetDateTime(leitor, "data_criacao_car");
                cargo.DataAtualizacao = DAOHelper.GetDateTime(leitor, "data_atualizacao_car");
                cargo.Observacao = DAOHelper.GetString(leitor, "observacoes_car");


                leitor.Close();
                return cargo;
            }

            leitor.Close();
            return null;
        }
        public void Excluir(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand("DELETE FROM cargo WHERE id_car = @_id;");
                comando.Parameters.AddWithValue("@_id", id);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir cargo", ex);
            }
        }


    }
}
