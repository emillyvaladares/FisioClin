using fisioClin.Configs;

namespace fisioClin.Models
{
    public class FinanceiroDAO
    {
        private readonly Conexao _conexao;

        public FinanceiroDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Financeiro> ListarTodos()
        {
            var lista = new List<Financeiro>();

            var comando = _conexao.CreateCommand("SELECT * FROM financeiro;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var financeiro = new Financeiro();
                financeiro.Id = leitor.GetInt32("id_financeiro");
                financeiro.Periodo = leitor.GetFloat("periodo_fin");
                financeiro.Id_Funcionario_Fk = leitor.GetInt32("id_funcionario_fk");

                lista.Add(financeiro);
            }
            return lista;
        }

        public void Inserir(Financeiro financeiro)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO prontuario VALUES (@_id, @_periodo, @_id_funcionario_fk)");

                comando.Parameters.AddWithValue("@_id", financeiro.Id);
                comando.Parameters.AddWithValue("@_data", financeiro.Periodo);
                comando.Parameters.AddWithValue("@_id_paciente_fk", financeiro.Id_Funcionario_Fk);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
