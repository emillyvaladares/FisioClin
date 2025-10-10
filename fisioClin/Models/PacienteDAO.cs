using fisioClin.Configs;

namespace fisioClin.Models
{
    public class PacienteDAO
    {
        private readonly Conexao _conexao;

        public PacienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Paciente> ListarTodos()
        {
            var lista = new List<Paciente>();

            var comando = _conexao.CreateCommand("SELECT * FROM paciente;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var paciente = new Paciente();
                paciente.Id = leitor.GetInt32("id_paciente");
                paciente.Nome = DAOHelper.GetString(leitor, "nome_pac");
                paciente.Cpf = DAOHelper.GetString(leitor, "cpf_pac");
                paciente.Rg = DAOHelper.GetString(leitor, "rg_pac");
                paciente.DataNascimento = DAOHelper.GetString(leitor, "data_nascmento_pac");
                paciente.Sexo = DAOHelper.GetString(leitor, "sexo_pac");
                paciente.Email = DAOHelper.GetString(leitor, "email_pac");
                paciente.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
                paciente.Id_end_fk = leitor.GetInt32("id_end_fk");

                lista.Add(paciente);
            }
            return lista;
        }

        public void Inserir(Paciente paciente)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO paciente VALUES (@_id, @_nome, @_cpf, @_rg, @_datanascimento, @_sexo, @_email, @_telefone, @_id_fk)");

                comando.Parameters.AddWithValue("@_id", paciente.Id);
                comando.Parameters.AddWithValue("@_nome", paciente.Nome);
                comando.Parameters.AddWithValue("@_cpf", paciente.Cpf);
                comando.Parameters.AddWithValue("@_rg", paciente.Rg);
                comando.Parameters.AddWithValue("@_datanascimento", paciente.DataNascimento);
                comando.Parameters.AddWithValue("@_sexo", paciente.Sexo);
                comando.Parameters.AddWithValue("@_email", paciente.Email);
                comando.Parameters.AddWithValue("@_telefone", paciente.Telefone);
                comando.Parameters.AddWithValue("@_id_fk", paciente.Id_end_fk);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
