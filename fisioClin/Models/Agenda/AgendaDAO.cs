using fisioClin.Models;
using FisioClin.Configs;
using System.Data;

namespace fisioClin.Models
{
    public class AgendaDAO
    {
        private readonly Conexao _conexao;

        public AgendaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // LISTAR TODAS AS AGENDAS
        public List<Agenda> ListarTodos()
        {
            var lista = new List<Agenda>();

            var comando = _conexao.CreateCommand("SELECT * FROM agenda;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var agenda = new Agenda();
                agenda.Id = leitor.GetInt32("id_age");
                agenda.Data = DAOHelper.GetDateTime(leitor, "data_age");
                agenda.Horario = leitor.GetTimeSpan("horario_age").ToString(@"hh\:mm");                
                agenda.Observacao = DAOHelper.GetString(leitor, "observacao_age");
                agenda.Id_Tipo_fk = leitor.IsDBNull(leitor.GetOrdinal("id_tip_fk")) ? 0 : leitor.GetInt32("id_tip_fk");
                agenda.Id_Sala_fk = leitor.IsDBNull(leitor.GetOrdinal("id_sal_fk")) ? 0 : leitor.GetInt32("id_sal_fk");
                agenda.Id_Funcionario_fk = leitor.IsDBNull(leitor.GetOrdinal("id_fun_fk")) ? 0 : leitor.GetInt32("id_fun_fk");
                agenda.Id_Paciente_fk = leitor.IsDBNull(leitor.GetOrdinal("id_pac_fk")) ? 0 : leitor.GetInt32("id_pac_fk");
               

                lista.Add(agenda);
            }
            return lista;
        }

        // BUSCAR POR ID
        public Agenda? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand("SELECT * FROM agenda WHERE id_age = @_id;");
            comando.Parameters.AddWithValue("@_id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var agenda = new Agenda();
                agenda.Id = leitor.GetInt32("id_age");
                agenda.Data = DAOHelper.GetDateTime(leitor, "data_age");
                agenda.Horario = leitor.GetTimeSpan("horario_age").ToString(@"hh\:mm");
            
                agenda.Observacao = DAOHelper.GetString(leitor, "observacao_age");
                agenda.Id_Tipo_fk = leitor.IsDBNull(leitor.GetOrdinal("id_tip_fk")) ? 0 : leitor.GetInt32("id_tip_fk");
                agenda.Id_Sala_fk = leitor.IsDBNull(leitor.GetOrdinal("id_sal_fk")) ? 0 : leitor.GetInt32("id_sal_fk");
                agenda.Id_Funcionario_fk = leitor.IsDBNull(leitor.GetOrdinal("id_fun_fk")) ? 0 : leitor.GetInt32("id_fun_fk");
                agenda.Id_Paciente_fk = leitor.IsDBNull(leitor.GetOrdinal("id_pac_fk")) ? 0 : leitor.GetInt32("id_pac_fk");
                return agenda;
            }

            return null;
        }

        // INSERIR
        public void Inserir(Agenda agenda)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                INSERT INTO agenda 
                (data_age, horario_age, id_sal_fk, id_fun_fk, observacao_age, id_pac_fk, id_tip_fk)
                VALUES (@_data, @_horario, @_sala, @_func, @_obs, @_id_pac, @_id_tip);
            ");

                comando.Parameters.AddWithValue("@_data", agenda.Data);
                comando.Parameters.AddWithValue("@_horario", agenda.Horario);
                comando.Parameters.AddWithValue("@_sala", agenda.Id_Sala_fk);
                comando.Parameters.AddWithValue("@_func", agenda.Id_Funcionario_fk);
                comando.Parameters.AddWithValue("@_obs", agenda.Observacao);
                comando.Parameters.AddWithValue("@_id_pac", agenda.Id_Paciente_fk);
                comando.Parameters.AddWithValue("@_id_tip", agenda.Id_Tipo_fk);


                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); 
             }
         
        }

        // ATUALIZAR
        public void Atualizar(Agenda agenda)
        {
            var comando = _conexao.CreateCommand(@"
                UPDATE agenda SET
                    data_age = @_data,
                    horario_age = @_horario,
                    id_sal_fk = @_sala,
                    id_fun_fk = @_func,
                    observacao_age = @_obs,
                    id_pac_fk = @_id_pac,
                    id_tip_fk = @_id_tip,
                WHERE id_age = @_id;
            ");
            
            comando.Parameters.AddWithValue("@_id", agenda.Id);
            comando.Parameters.AddWithValue("@_data", agenda.Data);
            comando.Parameters.AddWithValue("@_horario", agenda.Horario);
            comando.Parameters.AddWithValue("@_sala", agenda.Id_Sala_fk);
            comando.Parameters.AddWithValue("@_func", agenda.Id_Funcionario_fk);
            comando.Parameters.AddWithValue("@_obs", agenda.Observacao);
            comando.Parameters.AddWithValue("@_id_pac", agenda.Id_Paciente_fk);
            comando.Parameters.AddWithValue("@_id_tip", agenda.Id_Tipo_fk);

            comando.ExecuteNonQuery();
        }

        // EXCLUIR
        public void Excluir(int id)
        {
            var comando = _conexao.CreateCommand("DELETE FROM agenda WHERE id_age = @_id;");
            comando.Parameters.AddWithValue("@_id", id);

            comando.ExecuteNonQuery();
        }
        public List<Sala> ListarSalas()
        {
            var lista = new List<Sala>();

            var comando = _conexao.CreateCommand("SELECT * FROM sala;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(new Sala
                {
                    Id = leitor.GetInt32("id_sal"),
                    Nome = DAOHelper.GetString(leitor, "nome_sal"),
                    Numero = DAOHelper.GetString(leitor, "numero_sal"),
                    Tipo = DAOHelper.GetString(leitor, "tipo_sal"),
                    Observacao = DAOHelper.GetString(leitor, "observacao_sal"),
                    Capacidade = leitor.GetInt32("capacidade_sal"),
                    Disponibilidade = DAOHelper.GetString(leitor, "disponibilidade_sal")
                });
            }

            return lista;
        }
    }
}
