//using fisioClin.Configs;

//namespace fisioClin.Models
//{
//    public class FuncionariosDAO
//    {
//        private readonly Conexao _conexao;

//        public FuncionariosDAO(Conexao conexao)
//        {
//            _conexao = conexao;
//        }

//        public List<Funcionarios> ListarTodos()
//        {
//            var lista = new List<Funcionarios>();

//            var comando = _conexao.CreateCommand("SELECT * FROM funcionarios;");
//            var leitor = comando.ExecuteReader();

<<<<<<< HEAD
//            while (funcionarios.Read())
//            {
//                var funcionarios = new Funcionarios();
//                funcionarios.Id = leitor.GetInt32("id_fucionarios");
//                funcionarios. = DAOHelper.GetString(leitor, "tipo_exame");
//                funcionarios.Diagnostico = DAOHelper.GetString(leitor, "diagnostico_laudo");
//                funcionarios.Observacao = DAOHelper.GetString(leitor, "observacao_laudo");
//                funcionarios.Id_paciente_fk = leitor.GetInt32("id_paciente_fk");
=======
            while (leitor.Read())
            {
                var funcionarios = new Funcionarios();
                funcionarios.Id = leitor.GetInt32("id_fucionario");
                funcionarios.Nome = DAOHelper.GetString(leitor, "nome_func");
                funcionarios.Cpf = DAOHelper.GetString(leitor, "cpf_func");
                funcionarios.Rg = DAOHelper.GetString(leitor, "rg_func");
                funcionarios.Email = DAOHelper.GetString(leitor, "email_func");
                funcionarios.DataNascimento = DAOHelper.GetString(leitor, "data_nascmento_func");
                funcionarios.Especialidade = DAOHelper.GetString(leitor, "especialidade_func");
                funcionarios.Registro = DAOHelper.GetString(leitor, "registro_profissional_func");
                funcionarios.DataContratacao = DAOHelper.GetString(leitor, "data_contratacao_func");
                funcionarios.TipoVinculo = DAOHelper.GetString(leitor, "tipo_vinculo_func");
                funcionarios.Certificados = DAOHelper.GetString(leitor, "certificados_func");
                funcionarios.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
                funcionarios.Senha = DAOHelper.GetString(leitor, "senha_func");
>>>>>>> df22ba050ed51e90ff5066b69003cf81fbc5db88

//                lista.Add(funcionarios);
//            }
//            return lista;
//        }

<<<<<<< HEAD
//        public void Inserir(Laudo laudo)
//        {
//            try
//            {
//                var comando = _conexao.CreateCommand("INSERT INTO laudo VALUES (@_id, @_exame, @_diagnostico, @_observacao, @_id_fk)");

//                comando.Parameters.AddWithValue("@_id", laudo.Id);
//                comando.Parameters.AddWithValue("@_exame", laudo.Exame);
//                comando.Parameters.AddWithValue("@_diagnostico", laudo.Diagnostico);
//                comando.Parameters.AddWithValue("@_observacao", laudo.Observacao);
//                comando.Parameters.AddWithValue("@_id_fk", laudo.Id_paciente_fk);
=======
        public void Inserir(Funcionarios funcionarios)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO funcionarios VALUES (@_id, @_nome @_cpf, @_rg, @_email, @_datanascimento, @_especialidade, @_registro, @_datacontratacao, @_tipovinculo, @_certificados, @_telefone, @_senha)");

                comando.Parameters.AddWithValue("@_id", funcionarios.Id);
                comando.Parameters.AddWithValue("@_exame", funcionarios.Nome);
                comando.Parameters.AddWithValue("@_diagnostico", funcionarios.Cpf);
                comando.Parameters.AddWithValue("@_observacao", funcionarios.Rg);
                comando.Parameters.AddWithValue("@_email", funcionarios.Email);
                comando.Parameters.AddWithValue("@_datanascimento", funcionarios.DataNascimento);
                comando.Parameters.AddWithValue("@_especialidade", funcionarios.Especialidade);
                comando.Parameters.AddWithValue("@_registro", funcionarios.Registro);
                comando.Parameters.AddWithValue("@_datacontratacao", funcionarios.DataContratacao);
                comando.Parameters.AddWithValue("@_tipovinculo", funcionarios.TipoVinculo);
                comando.Parameters.AddWithValue("@_certificados", funcionarios.Certificados);
                comando.Parameters.AddWithValue("@_telefone", funcionarios.Telefone);
                comando.Parameters.AddWithValue("@_senha", funcionarios.Senha);
>>>>>>> df22ba050ed51e90ff5066b69003cf81fbc5db88

//                comando.ExecuteNonQuery();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}
