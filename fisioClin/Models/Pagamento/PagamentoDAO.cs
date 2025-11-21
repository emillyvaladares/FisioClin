using FisioClin.Configs;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace fisioClin.Models
{
    public class PagamentosDAO
    {
        private readonly Conexao _conexao;

        public PagamentosDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // Listar todos os pagamentos
        public List<Pagamento> ListarTodos()
        {
            var lista = new List<Pagamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM Pagamento;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var pagamento = new Pagamento
                {
                    Id = leitor.GetInt32("id_pagamento"),
                    DataPagamento = DAOHelper.GetString(leitor, "data_pagamento"),
                    NumeroParcelas = DAOHelper.GetString(leitor, "numero_parcelas"),
                    ValorPagamento = DAOHelper.GetString(leitor, "valor_pagamento"),
                    FormaPagamento = DAOHelper.GetString(leitor, "forma_pagamento"),
                    Status = DAOHelper.GetString(leitor, "status_pagamento"),
                    Observacao = DAOHelper.GetString(leitor, "observacao_pagamento"),
                    IdPacienteFk = leitor.GetInt32("id_paciente_fk")
                };

                lista.Add(pagamento);
            }

            leitor.Close();
            return lista;
        }

        // Inserir um novo pagamento
        public void Inserir(Pagamento p)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    INSERT INTO Pagamento 
                    (data_pagamento, numero_parcelas, valor_pagamento, forma_pagamento, status_pagamento, observacao_pagamento, id_paciente_fk)
                    VALUES 
                    (@dataPagamento, @numeroParcelas, @valorPagamento, @formaPagamento, @status, @observacao, @idPacienteFk);
                ");

                comando.Parameters.AddWithValue("@dataPagamento", p.DataPagamento);
                comando.Parameters.AddWithValue("@numeroParcelas", p.NumeroParcelas);
                comando.Parameters.AddWithValue("@valorPagamento", p.ValorPagamento);
                comando.Parameters.AddWithValue("@formaPagamento", p.FormaPagamento);
                comando.Parameters.AddWithValue("@status", p.Status);
                comando.Parameters.AddWithValue("@observacao", p.Observacao);
                comando.Parameters.AddWithValue("@idPacienteFk", p.IdPacienteFk);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir pagamento: " + ex.Message);
            }
        }

        // Buscar pagamento por ID
        public Pagamento BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand("SELECT * FROM Pagamento WHERE id_pagamento = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var pagamento = new Pagamento
                {
                    Id = leitor.GetInt32("id_pagamento"),
                    DataPagamento = DAOHelper.GetString(leitor, "data_pagamento"),
                    NumeroParcelas = DAOHelper.GetString(leitor, "numero_parcelas"),
                    ValorPagamento = DAOHelper.GetString(leitor, "valor_pagamento"),
                    FormaPagamento = DAOHelper.GetString(leitor, "forma_pagamento"),
                    Status = DAOHelper.GetString(leitor, "status_pagamento"),
                    Observacao = DAOHelper.GetString(leitor, "observacao_pagamento"),
                    IdPacienteFk = leitor.GetInt32("id_paciente_fk")
                };
                leitor.Close();
                return pagamento;
            }

            leitor.Close();
            return null;
        }
    }
}
