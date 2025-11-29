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
                agenda.Id_Sala_fk = leitor.GetInt32("id_sal_fk");
                agenda.Id_Funcionario_fk = leitor.GetInt32("id_fun_fk");
                agenda.Observacao = DAOHelper.GetString(leitor, "observacao_age");

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
                agenda.Id_Sala_fk = leitor.GetInt32("id_sal_fk");
                agenda.Id_Funcionario_fk = leitor.GetInt32("id_fun_fk");
                agenda.Observacao = DAOHelper.GetString(leitor, "observacao_age");

                return agenda;
            }

            return null;
        }

        // INSERIR
        public void Inserir(Agenda agenda)
        {
            var comando = _conexao.CreateCommand(@"
                INSERT INTO agenda 
                (data_age, horario_age, id_sal_fk, id_fun_fk, observacao_age)
                VALUES (@_data, @_horario, @_sala, @_func, @_obs);
            ");

            comando.Parameters.AddWithValue("@_data", agenda.Data);
            comando.Parameters.AddWithValue("@_horario", agenda.Horario);
            comando.Parameters.AddWithValue("@_sala", agenda.Id_Sala_fk);
            comando.Parameters.AddWithValue("@_func", agenda.Id_Funcionario_fk);
            comando.Parameters.AddWithValue("@_obs", agenda.Observacao);

            comando.ExecuteNonQuery();
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
                    observacao_age = @_obs
                WHERE id_age = @_id;
            ");

            comando.Parameters.AddWithValue("@_id", agenda.Id);
            comando.Parameters.AddWithValue("@_data", agenda.Data);
            comando.Parameters.AddWithValue("@_horario", agenda.Horario);
            comando.Parameters.AddWithValue("@_sala", agenda.Id_Sala_fk);
            comando.Parameters.AddWithValue("@_func", agenda.Id_Funcionario_fk);
            comando.Parameters.AddWithValue("@_obs", agenda.Observacao);

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
