using fisioClin.Configs;

namespace fisioClin.Models
{
    public class Cargo_FuncionarioDAO
    {
        private readonly Conexao _conexao;

        public Cargo_FuncionarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cargo_FuncionarioDAO> ListarTodos()
        {
            var lista = new List<Cargo_Funcionario>();

            var comando = _conexao.CreateCommand("SELECT * FROM cargo_funcionario;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cargo_funcionario = new Cargo_Funcionario();
                cargo_funcionario.Id = leitor.GetInt32("id_cargo_funcionario");
                cargo_funcionario.Id_Cargo_fk = leitor.GetInt32("id_cargo_fk");
                cargo_funcionario.Id_Funcionario_fk = leitor.GetInt32("id_funcionario_fk");

                lista.Add(cargo_funcionario);
            }
            return lista;
        }

        public void Inserir(Cargo_Funcionario cargo_funcionario)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cargo_funcionario VALUES (@_id, @_id_cargo_fk, @_id_funcionario_fk)");

                comando.Parameters.AddWithValue("@_id", cargo_funcionario.Id);
                comando.Parameters.AddWithValue("@_id_cargo_fk", cargo_funcionario.Id_Cargo_fk);
                comando.Parameters.AddWithValue("@_id_funcionario_fk", cargo_funcionario.Id_Funcionario_fk);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
}
